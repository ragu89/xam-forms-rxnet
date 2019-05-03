using System;
using RxNetForms.Services;

namespace RxNetForms.ViewModels
{
    public class DedicatedServiceAsObservableViewModel : BaseViewModel
    {
        private readonly CounterService counterService;
        private IDisposable counterServiceDisposal;

        public DedicatedServiceAsObservableViewModel()
        {
            counterService = new CounterService();
            counterService.Start();
        }

        public override void Subscribe()
        {
            counterServiceDisposal = counterService.Subscribe(x => { LabelText = $"Count: {x.ToString("N0")}"; });
        }

        public override void Dispose()
        {
            counterServiceDisposal.Dispose();
        }
    }
}
