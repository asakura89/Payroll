using Emi;
using Ria;

namespace Payroll.Helpers {
    public static class GlobalContext {
        public static Emitter Emitter { get; private set; }

        public static PipelineExecutor PipelineExecutor { get; private set; }

        public static void Initialize() {
            Emitter = new XmlConfigEmitterLoader().Load();
            PipelineExecutor = new XmlConfigPipelineLoader().Load();
        }
    }
}