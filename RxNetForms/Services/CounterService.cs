using System;
using System.Collections.Generic;
using System.Reactive.Disposables;
using Xamarin.Forms;

namespace RxNetForms.Services
{
    public class CounterService : IObservable<int>
    {
        private int counter;
        private readonly List<IObserver<int>> observers;

        public CounterService()
        {
            observers = new List<IObserver<int>>();
        }

        public void Start()
        {
            Device.StartTimer(TimeSpan.FromSeconds(1), () =>
            {
                counter++;

                foreach(var observer in observers)
                {
                    observer.OnNext(counter);
                }

                return true;
            });
        }

        public IDisposable Subscribe(IObserver<int> observer)
        {
            if (IsNotNullAndIsNotRegistered(observer))
            {
                observers.Add(observer);
                return Disposable.Create(() =>
                {
                    observers.Remove(observer);
                });
            }
            return Disposable.Empty;
        }

        private bool IsNotNullAndIsNotRegistered(IObserver<int> observer) => observer != null && !observers.Contains(observer);
    }
}
