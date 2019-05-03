using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace RxNetForms.ViewModels
{
    public abstract class BaseViewModel : INotifyPropertyChanged
    {
        public BaseViewModel()
        {
            LabelText = "Initial value";
        }

        public abstract void Subscribe();
        public abstract void Dispose();

        private string _labelText;
        public string LabelText
        {
            get => _labelText;
            set
            {
                _labelText = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
