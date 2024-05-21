namespace Xadrez_TIC
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage(new ViewModels.MainViewModel()));
            //MainPage = new AppShell(); this is the original 
        }
    }
}
