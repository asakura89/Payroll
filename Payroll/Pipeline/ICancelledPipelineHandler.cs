using System;
using Emi;
using Ria;

namespace Payroll.Pipeline {
    public interface ICancelledPipelineHandler {
        event EventHandler<EmitterEventArgs> PipelineExecutionCancelled;

        void Handle(PipelineContext result);
    }
}