using System;
using System.Collections.Generic;

namespace Ria {
    public interface IPipelineExecutor {
        PipelineContext Execute(String pipelineName);

        PipelineContext Execute(String pipelineName, IDictionary<String, Object> data);
    }
}
