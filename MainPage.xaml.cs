using Xadrez_TIC.ViewModels;

namespace Xadrez_TIC
{
    public partial class MainPage : ContentPage
    {
        public MainPage(MainViewModel vm)
        {
            InitializeComponent();
            BindingContext = vm;
        }     
    }
}
