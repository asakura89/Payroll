using System;
using System.Collections.Generic;
using System.Linq;
using Arvy;
using Emi;
using Payroll.Helpers;
using Ria;

namespace Payroll.Pipeline {
    public class PipelineResultHandler : IPipelineResultHandler {
        public event EventHandler<EmitterEventArgs> ResultContainsInfo;
        public event EventHandler<EmitterEventArgs> ResultContainsWarn;
        public event EventHandler<EmitterEventArgs> ResultContainsError;
        public event EventHandler<EmitterEventArgs> PipelineExecutionFailed;
        public event EventHandler<EmitterEventArgs> PipelineExecutionSuccess;

        public void Handle(PipelineContext result) {
            var eventRegistrar = GlobalContext.ServiceRegistry.GetService<IEventRegistrar>();
            eventRegistrar.Register(this);

            if (result.ActionMessages.Any()) {
                IList<String> infos = result.ActionMessages
                    .Where(resultItem => resultItem.ResponseType == ActionResponseViewModel.Info)
                    .Select(resultItem => resultItem.Message)
                    .ToList();

                ResultContainsInfo?.Invoke(this, new EmitterEventArgs(
                    nameof(PipelineResultHandler.ResultContainsInfo),
                    new Dictionary<String, Object> {
                        ["ActionMessages"] = infos,
                        ["PipelineContext"] = result
                    }));

                IList<String> warns = result.ActionMessages
                    .Where(resultItem => resultItem.ResponseType == ActionResponseViewModel.Warning)
                    .Select(resultItem => resultItem.Message)
                    .ToList();

                ResultContainsWarn?.Invoke(this, new EmitterEventArgs(
                    nameof(PipelineResultHandler.ResultContainsWarn),
                    new Dictionary<String, Object> {
                        ["ActionMessages"] = warns,
                        ["PipelineContext"] = result
                    }));

                IList<String> errors = result.ActionMessages
                    .Where(resultItem => resultItem.ResponseType == ActionResponseViewModel.Error)
                    .Select(resultItem => resultItem.Message)
                    .ToList();

                if (errors.Any()) {
                    ResultContainsError?.Invoke(this, new EmitterEventArgs(
                        nameof(PipelineResultHandler.ResultContainsError),
                        new Dictionary<String, Object> {
                            ["ActionMessages"] = errors,
                            ["PipelineContext"] = result
                        }));

                    PipelineExecutionFailed?.Invoke(this, new EmitterEventArgs(nameof(PipelineResultHandler.PipelineExecutionFailed)));
                }
            }

            PipelineExecutionSuccess?.Invoke(this, new EmitterEventArgs(nameof(PipelineResultHandler.PipelineExecutionSuccess)));
        }
    }
}