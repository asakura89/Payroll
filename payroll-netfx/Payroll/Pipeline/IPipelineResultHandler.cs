using System;
using Emi;
using Ria;

namespace Payroll.Pipeline {
    public interface IPipelineResultHandler {
        event EventHandler<EmitterEventArgs> ResultContainsInfo;
        event EventHandler<EmitterEventArgs> ResultContainsWarn;
        event EventHandler<EmitterEventArgs> ResultContainsError;
        event EventHandler<EmitterEventArgs> PipelineExecutionFailed;
        event EventHandler<EmitterEventArgs> PipelineExecutionSuccess;

        void Handle(PipelineContext result);
    }
}
