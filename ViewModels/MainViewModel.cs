using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.ComponentModel;
using static Microsoft.Maui.Controls.NavigableElement;

namespace Xadrez_TIC.ViewModels
{
    public partial class MainViewModel : ObservableObject
    {
        [RelayCommand]
        async Task Play(object obj)
        {
            //await Shell.Current.GoToAsync(nameof(ChessPage));
            await Application.Current.MainPage.Navigation.PushAsync(new ChessPage(new ChessViewModel()));
        }
    }
}
