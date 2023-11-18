using System;
using System.Collections.Generic;
using Emi;
using Payroll.Helpers;
using Ria;

namespace Payroll.Pipeline {
    public class CancelledPipelineHandler : ICancelledPipelineHandler {
        public event EventHandler<EmitterEventArgs> PipelineExecutionCancelled;

        public void Handle(PipelineContext result) {
            var eventRegistrar = GlobalContext.ServiceRegistry.GetService<IEventRegistrar>();
            eventRegistrar.Register(this);

            if (result.Cancelled)
                PipelineExecutionCancelled?.Invoke(this, new EmitterEventArgs(
                    nameof(CancelledPipelineHandler.PipelineExecutionCancelled),
                    new Dictionary<String, Object> {
                        ["PipelineContext"] = result
                    }));
        }
    }
}