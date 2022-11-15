using System.Collections.Generic;

namespace PBL4.Resources.Language
{
    public class InitLanguage
    {
        #region Instance
        private static InitLanguage _initLanguage;
        public static InitLanguage Instance
        {
            get
            {
                if (_initLanguage == null) _initLanguage = new InitLanguage();
                return _initLanguage;
            }
            private set { }
        }
        #endregion
        public static string CurrentLanguage { get; set; }

        public InitLanguage()
        {

        }
        public void ChangeLanguage(string newLanguage)
        {
            CurrentLanguage = newLanguage;
        }
        public List<string> KeyLanguage()
        {
            List<string> list = new List<string>();
            list.Add("vi-VN");
            list.Add("en-US");
            list.Add("de-DE");
            list.Add("pt-PT");
            list.Add("es-ES");
            list.Add("fr-FR");
            return list;
        }

        public List<string> Language()
        {
            List<string> list = new List<string>();
            list.Add("Tiếng Việt");
            list.Add("English");
            list.Add("Deutsch");
            list.Add("Português");
            list.Add("Español");
            list.Add("Français");
            return list;
        }
    }
}
