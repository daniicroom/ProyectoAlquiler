using AppAlquiler.BaseDatos;

namespace AppAlquiler
{
    public partial class App : Application
    {
        public static clsBaseDatos _baseDatos;
        public static clsBaseDatos BaseDatos
        {
            get
            {
                if (_baseDatos == null)
                {
                    _baseDatos = new clsBaseDatos(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "dbAppAlquiler2023.db3"));
                }
                return _baseDatos;
            }
        }
        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
        }
        protected override void OnStart()
        {
            BaseDatos.CrearTablas();
        }
    }
}