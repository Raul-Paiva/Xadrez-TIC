using CommunityToolkit.Mvvm.ComponentModel;
using System.ComponentModel;
namespace Xadrez_TIC.ViewModels
{
    public partial class ChessViewModel : ObservableObject, INotifyPropertyChanged
    {
        public GridLength ChessHeightDefinition { get; private set; }//tentar criar algo para deixar a largura e altura do tabuleiro iguais
        public GridLength WidthDefinition { get; private set; }
        private double screenHeight = DeviceDisplay.Current.MainDisplayInfo.Height;
        private double screenWidth = DeviceDisplay.Current.MainDisplayInfo.Width;
        public ChessViewModel()
        {
#if WINDOWS
            screenHeight = screenHeight / 2;
            WidthDefinition = screenHeight;
            ChessHeightDefinition = screenHeight;
#else
            screenWidth = screenWidth / 3;//Strange but it works
            WidthDefinition = screenWidth;
            ChessHeightDefinition = screenWidth;
#endif

        }

    }
}
