using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.ComponentModel;
using System.Xml.Linq;
using static Microsoft.Maui.Controls.NavigableElement;

namespace Xadrez_TIC.ViewModels
{   
    public partial class MainViewModel : ObservableObject
    {
        public string? NamePlayer1 { get; set; }
        public string? NamePlayer2 { get; set; }
        public string? Player1 { get; private set; }
        public string? Player2 { get; private set; }

        [RelayCommand]
        async Task Play(object obj)
        {
            Player1 = NamePlayer1;
            Player2 = NamePlayer2;
            await Shell.Current.GoToAsync($"{nameof(ChessPage)}?Mvm={this}");
            //await Application.Current.MainPage.Navigation.PushAsync(new ChessPage(new ChessViewModel()));
        }
    }
}
