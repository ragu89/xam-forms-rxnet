using System;
using Xamarin.Forms;

namespace RxNetForms.Model
{
    public class MainModel
    {
        public event EventHandler UpdatedData;
        private int count;

        public void StartCounter()
        {
            Device.StartTimer(TimeSpan.FromSeconds(1), () =>
            {
                UpdatedData?.Invoke(this, new DataEventArgs() { Count = count });
                count++;
                return true;
            });
        }
    }

    public class DataEventArgs : EventArgs
    {
        public int Count { get; set; }
    }
}
