using System.Runtime.InteropServices;

namespace AssignWeight
{
    public class CatConnect
    {
        public bool IsConnected { get; set; }
        public INFITF.Application Catia { get; set; }
        private static CatConnect _instance;
        public static CatConnect Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new CatConnect();
                }
                return _instance;
            }
        }

        public CatConnect()
        {
            Connect();
        }

        public void Refresh()
        {
            _instance = new CatConnect();
        }

        private bool Connect()
        {
            try
            {
                Catia = (INFITF.Application)Marshal.GetActiveObject("Catia.Application");
                IsConnected = true;
                return true;
            }
            catch (COMException)
            {
                IsConnected = false;
                return false;
                //throw new CatiaNotFoundException();
            }
        }

        public bool IsDocumentLoaded()
        {
            try
            {
                _ = Instance.Catia.ActiveDocument;
                return true;
            }
            catch (COMException)
            {
                return false;
            }
        }
    }
}
