using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Xadrez_TIC.ViewModels
{
    public partial class MainViewModel : ObservableObject
    {
        [RelayCommand]
        async Task Play(object obj)
        {
            await Shell.Current.GoToAsync(nameof(ChessPage));
        }
    }
}
