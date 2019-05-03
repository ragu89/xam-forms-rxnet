using System;
using System.Reactive;
using System.Reactive.Linq;
using RxNetForms.Model;

namespace RxNetForms.ViewModels
{
    public class EventAsObservableViewModel : BaseViewModel
    {
        private MainModel mainModel;
        private readonly IObservable<EventPattern<object>> eventAsObservable;
        private IDisposable eventAsObservableDisposable;

        public EventAsObservableViewModel()
        {
            mainModel = new MainModel();
            mainModel.StartCounter();

            eventAsObservable = Observable.FromEventPattern(ev => mainModel.UpdatedData += ev,
                                                            ev => mainModel.UpdatedData -= ev);
                                          //.Where(x => ((DataEventArgs)x.EventArgs).Count > 5);
        }

        public override void Subscribe()
        {
            eventAsObservableDisposable = eventAsObservable.Subscribe(x => { LabelText = $"Count: {((DataEventArgs)x.EventArgs).Count.ToString("N0")}"; });
        }

        public override void Dispose()
        {
            eventAsObservableDisposable.Dispose();
        }
    }
}
