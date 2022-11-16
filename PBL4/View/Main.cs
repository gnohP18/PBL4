using PBL4.Model;
using PBL4.Resources.Language;
using PBL4.View;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Net.Sockets;
using System.Resources;
using System.Threading;
using System.Windows.Forms;

namespace PBL4
{
    public partial class Main : Form
    {
        #region Service
        private string _ipAddress;
        private string _computerName;
        private string _port;
        private TcpClient _tcpClient;
        private Stream _stream;
        private StreamReader _streamReader;
        private StreamWriter _streamWriter;
        #endregion

        #region Global variable
        //Ma trận với kiểu dữ liệu ValueUC được nhập từ User
        private ValueUC[,] ListValueUC { get; set; }

        //Danh sách tên điểm dựa vào số lượng điểm 
        private List<string> NamePoint { get; set; }

        //Ma trận trọng số lấy từ ma trận ListValueUC trên View
        private long[,] MatrixDijktra { get; set; }

        //Số lượng điểm của ma trận
        private int NumberOfPoint { get; set; }

        //Dữ liệu trả về từ server
        private string DataFromServer { get; set; }
        //Luồng nhận dữ liệu
        private Thread receiveThread;
        private delegate void SafeCallDelegate(string text);
        private ResourceManager _resourceManager;
        private CultureInfo cultureInfo;

        #endregion

        public Main(string computerName, string hostName, string port)
        {
            _port = port;
            _ipAddress = hostName;
            _computerName = computerName;
            InitializeComponent();
            InitDataForCBB();
            SetupLanguage(InitLanguage.CurrentLanguage);
        }

        #region InitData
        private void InitDataForCBB()
        {
            NamePoint = MatrixService.Instance.GetPointNameByNumberOfPoint(NumberOfPoint);
            foreach (int i in MatrixService.Instance.GetNumberOfPoint())
            {
                cbbNumberOfPoints.Items.Add(i);
            }
            btnDrawTheGraph.Visible = false;
            lblDrawGraph.Visible = false;
        }
        #endregion

        #region Function
        private void SetupLanguage(string language)
        {
            _resourceManager = new ResourceManager("PBL4.Resources.Language.Resource", typeof(InitLanguage).Assembly);
            cultureInfo = CultureInfo.InvariantCulture;
            cultureInfo = CultureInfo.CreateSpecificCulture(language);
            InitLanguage.Instance.ChangeLanguage(language);
            lblDrawGraph.Text = _resourceManager.GetString("DrawGraph", cultureInfo);
            lblNameOfPoint.Text = _resourceManager.GetString("NumberOfPoint", cultureInfo);
            lblResetMatrix.Text = _resourceManager.GetString("ResetMatrix", cultureInfo);
            lblTitle.Text = _resourceManager.GetString("Title", cultureInfo);
            lblSubmitMatrix.Text = _resourceManager.GetString("SubmitMatrix", cultureInfo);
            btnBF.Text = _resourceManager.GetString("BrowserFile", cultureInfo);
        }
        //Delegate update dữ liệu
        private void UpdateDataFromServer(string log)
        {
            if (btnOK.InvokeRequired)
            {
                var dele = new SafeCallDelegate(UpdateDataFromServer);
                btnOK.Invoke(dele, new object[] { log });
            }
            else
            {
                DataFromServer = log;
            }
        }

        //Luồng nhận dữ liệu được gửi từ server
        private void ReceiveDataFromServer()
        {
            while (true)
            {
                try
                {
                    _streamReader = new StreamReader(_stream);
                    string dataFromServer = _streamReader.ReadLine();
                    if (dataFromServer != null) UpdateDataFromServer(dataFromServer);
                }
                catch (Exception ex)
                {
                    NoticeBox box = new NoticeBox(ex.ToString());
                    box.Show();
                    break;
                }
            }
        }

        //Xóa item mỗi lần chuyển cbb
        private void ClearMatrixItem()
        {
            pnMatrix.Controls.Clear();
        }
        //thêm ô của ma trận vào panel
        private void SetupItem(ValueUC valueUC)
        {
            pnMatrix.Controls.Add(valueUC);
        }

        //Kiểm tra ma trận có hợp lệ hay không, với điều kiện là trọng số không âm, không bỏ trống ô 
        private bool IsAvailableMatrix(long[,] matrix, int numberOfPoint)
        {
            for (int i = 0; i < numberOfPoint; i++)
            {
                for (int j = 0; j < numberOfPoint; j++)
                {
                    if (matrix[i, j] < 0) return false;
                }
            }
            return true;
        }

        //Khởi tạo ma trận nhập UI từ số lượng điểm
        private void InitMatrixWithNumberOfPoint(int numberOfPoint)
        {
            ListValueUC = new ValueUC[numberOfPoint, numberOfPoint];
            int locaX = EnumMatrix.DefaultItemMatrixX;
            int locaY = EnumMatrix.DefaultItemMatrixY;
            for (int i = 0; i < numberOfPoint; i++)
            {
                locaY = EnumMatrix.ValueUCHeight * i + EnumMatrix.DistanceBetween2Points;
                for (int j = 0; j < numberOfPoint; j++)
                {
                    ListValueUC[i, j] = new ValueUC();
                    ListValueUC[i, j].Leave += ValueUC_Text_Leave;
                    Point point = new Point(locaX + EnumMatrix.ValueUCWidth * j + EnumMatrix.DistanceBetween2Points, locaY);
                    var coordinates = ((i + 1) + "," + (j + 1)).ToString();
                    ListValueUC[i, j].SetCoordinates(coordinates);
                    ListValueUC[i, j].SetLocation(point);
                    SetupItem(ListValueUC[i, j]);
                    if (i == j)
                    {
                        ListValueUC[i, j].SetValueEqualZero();
                    }
                }
            }
        }

        //Lấy tất cả giá trị từ ô ma trận
        private long[,] GetMatrixFromView(ValueUC[,] listValueUC, int numberOfPoint)
        {
            long[,] matrix = new long[numberOfPoint, numberOfPoint];
            for (int i = 0; i < numberOfPoint; i++)
            {
                for (int j = 0; j < numberOfPoint; j++)
                {
                    listValueUC[i, j].SetInitValue();
                    if (i != j)
                    {
                        matrix[i, j] = listValueUC[i, j].Value;
                    }
                }
            }
            MatrixDijktra = matrix;
            return matrix;
        }
        private void SetValueUCFromBrowserFile(long[,] matrix, int numberOfPoint)
        {
            MatrixDijktra = matrix;
            NumberOfPoint = numberOfPoint;
            int locaX = EnumMatrix.DefaultItemMatrixX;
            int locaY = EnumMatrix.DefaultItemMatrixY;
            for (int i = 0; i < numberOfPoint; i++)
            {
                locaY = EnumMatrix.ValueUCHeight * i + EnumMatrix.DistanceBetween2Points;
                for (int j = 0; j < numberOfPoint; j++)
                {
                    ListValueUC[i, j] = new ValueUC();
                    ListValueUC[i, j].SetValue(matrix[i, j]);
                    ListValueUC[i, j].Load += ValueUC_Text_Load;

                    Point point = new Point(locaX + EnumMatrix.ValueUCWidth * j + EnumMatrix.DistanceBetween2Points, locaY);
                    var coordinates = ((i + 1) + "," + (j + 1)).ToString();
                    ListValueUC[i, j].SetCoordinates(coordinates);
                    ListValueUC[i, j].SetLocation(point);
                    SetupItem(ListValueUC[i, j]);
                    if (i == j)
                    {
                        ListValueUC[i, j].SetValueEqualZero();
                    }

                }
            }
        }
        private void DisconnectFromServer()
        {
            _tcpClient.Close();
            _stream.Close();
        }
        #endregion

        #region Event handle
        private void Main_Load(object sender, EventArgs e)
        {
            try
            {
                _tcpClient = new TcpClient();
                _tcpClient.Connect(_ipAddress, Convert.ToInt32(_port));
                _stream = _tcpClient.GetStream();
            }
            catch (Exception ex)
            {
                NoticeBox box = new NoticeBox(ex.ToString());
                box.Show();
            }

        }
        private void ValueUC_Text_Leave(object sender, EventArgs e)
        {
            for (int i = 0; i < NumberOfPoint; i++)
            {
                for (int j = 0; j < NumberOfPoint; j++)
                {
                    if (i < j && ListValueUC[i, j].GetValue() != "")
                    {
                        ListValueUC[j, i].SetValue((long)(Convert.ToInt32(ListValueUC[i, j].GetValue())));
                        ListValueUC[j, i].SetEnableTextBox();
                    }
                }
            }
        }
        private void ValueUC_Text_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < NumberOfPoint; i++)
            {
                for (int j = 0; j < NumberOfPoint; j++)
                {
                    ListValueUC[i, j].SetValue(MatrixDijktra[i, j]);
                }
            }
            for (int i = 0; i < NumberOfPoint; i++)
            {
                for (int j = 0; j < NumberOfPoint; j++)
                {
                    if (i < j && ListValueUC[i, j].GetValue() != "")
                    {
                        ListValueUC[j, i].SetValue((long)(Convert.ToInt32(ListValueUC[i, j].GetValue())));
                        ListValueUC[j, i].SetEnableTextBox();
                    }
                }
            }
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbbNumberOfPoints_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClearMatrixItem();
            NumberOfPoint = cbbNumberOfPoints.SelectedIndex + 1;
            InitMatrixWithNumberOfPoint(NumberOfPoint);
        }


        private void btnOK_Click(object sender, EventArgs e)
        {
            if (!IsAvailableMatrix(GetMatrixFromView(ListValueUC, NumberOfPoint), NumberOfPoint))
            {
                String noticeMessage = _resourceManager.GetString("MsgValueMatrix", cultureInfo);
                NoticeBox noticeBox = new NoticeBox(noticeMessage);
                noticeBox.Show();
            }  
            else
            {
                //1.Lấy ma trận từ UI nhập vào
                MatrixDijktra = GetMatrixFromView(ListValueUC, NumberOfPoint);

                //2.Chuyển ma trận từ dạng số sang chuỗi để gửi
                string data = MatrixService.Instance.ConvertMatrixToMatrixString(NumberOfPoint, MatrixDijktra);

                //3.Gửi dữ liệu đi
                try
                {
                    _streamWriter = new StreamWriter(_stream);
                    _streamWriter.AutoFlush = true;
                    var packingData = _computerName + '@' + data;
                    _streamWriter.WriteLine(packingData);
                }
                catch (Exception ex)
                {
                    NoticeBox box = new NoticeBox(ex.ToString());
                    box.Show();
                }

                //4. Tạo luồng mới nhận dữ liệu
                if (receiveThread == null)
                {
                    receiveThread = new Thread(ReceiveDataFromServer);
                    receiveThread.Start();
                }
                btnDrawTheGraph.Visible = true;
                lblDrawGraph.Visible = true;
                btnOK.Visible = false;
                lblSubmitMatrix.Visible = false;
            };

        }

        private void btnDrawTheGraph_Click(object sender, EventArgs e)
        {
            //5.Sau khi nhận dữ liệu và kết thúc luồng lúc này mới cho hiện bảng kết quả và vẽ đồ thị
            ResultGraph resultGraph = new ResultGraph(NumberOfPoint, MatrixDijktra, DataFromServer);
            resultGraph.StartPosition = FormStartPosition.CenterScreen;
            resultGraph.Show();
            btnOK.Visible = true;
            lblSubmitMatrix.Visible = true;
            btnDrawTheGraph.Visible = false;
            lblDrawGraph.Visible = false;
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < NumberOfPoint; i++)
            {
                for (int j = 0; j < NumberOfPoint; j++)
                {
                    ListValueUC[i, j].ClearValue();
                }
            }
            String noticeMessage = _resourceManager.GetString("MsgClearValue", cultureInfo);
            NoticeBox noticeBox = new NoticeBox(noticeMessage);
            noticeBox.Show();
        }

        private void btnDisConnectToServer_Click(object sender, EventArgs e)
        {
            DisconnectFromServer();
            this.Close();
        }
        private void btnBF_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            DialogResult result = openFileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                string file = openFileDialog.FileName;
                string fileExtension = file.Substring(file.LastIndexOf('.') + 1).ToLower();
                txtbBF.Text = file;
                try
                {
                    string[] lines = System.IO.File.ReadAllLines(file);
                    if (lines.Length <= 0 || fileExtension != "txt")
                    {
                        String noticeMessage = _resourceManager.GetString("MsgFile", cultureInfo);
                        NoticeBox noticeBox = new NoticeBox(noticeMessage);
                        noticeBox.Show();
                    }
                    else
                    {
                        string lineNumberOfPoint = lines[0];
                        int numberOfPoint = MatrixService.Instance.GetNumberOfPointFromBrowseFile(lineNumberOfPoint);
                        cbbNumberOfPoints.SelectedIndex = numberOfPoint - 1;
                        string[] temp = new string[numberOfPoint];
                        for (int i = 0; i < lines.Length - 1; i++)
                        {
                            temp[i] = lines[i + 1];
                        }
                        long[,] matrix = MatrixService.Instance.GetMatrixFromBrowseFile(numberOfPoint, temp);
                        SetValueUCFromBrowserFile(matrix, numberOfPoint);
                    }
                }
                catch (IOException)
                {

                }
            }
        }


        #endregion


    }
}
