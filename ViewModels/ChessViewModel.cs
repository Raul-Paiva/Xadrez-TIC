using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Maui;
using System.ComponentModel;
using Xadrez_TIC.Exceptions;

namespace Xadrez_TIC.ViewModels
{
    public partial class ChessViewModel : INotifyPropertyChanged
    {
        public bool PressedOn_b1
        {
            get => PressedOn_b1;
            set
            {
                if (value == true) { Pressed(nameof(PressedOn_b1)); PressActions("b1"); }
            }
        }
        public bool PressedOn_b2
        {
            get => PressedOn_b2;
            set
            {
                if (value == true) { Pressed(nameof(PressedOn_b2)); PressActions("b2"); }
            }
        }
        public bool PressedOn_b3
        {
            get => PressedOn_b3;
            set
            {
                if (value == true) { Pressed(nameof(PressedOn_b3)); PressActions("b3"); }
            }
        }
        public bool PressedOn_b4
        {
            get => PressedOn_b4;
            set
            {
                if (value == true) { Pressed(nameof(PressedOn_b4)); PressActions("b4"); }
            }
        }
        public bool PressedOn_b5
        {
            get => PressedOn_b5;
            set
            {
                if (value == true) { Pressed(nameof(PressedOn_b5)); PressActions("b5"); }
            }
        }
        public bool PressedOn_b6
        {
            get => PressedOn_b6;
            set
            {
                if (value == true) { Pressed(nameof(PressedOn_b6)); PressActions("b6"); }
            }
        }
        public bool PressedOn_b7
        {
            get => PressedOn_b7;
            set
            {
                if (value == true) { Pressed(nameof(PressedOn_b7)); PressActions("b7"); }
            }
        }
        public bool PressedOn_b8
        {
            get => PressedOn_b8;
            set
            {
                if (value == true) { Pressed(nameof(PressedOn_b8)); PressActions("b8"); }
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        void Pressed(string name) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));


        void PressActions(string position)
        {
            throw new ChessException();
        }
    }
}
