namespace Xadrez_TIC
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(ChessPage), typeof(ChessPage));
        }
    }
}
