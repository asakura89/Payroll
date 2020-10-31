using Emi;

namespace Payroll.Helpers {
    public static class GlobalContext {
        public static Emitter Emitter { get; private set; }

        public static void Initialize() =>
            Emitter = new XmlConfigEmitterLoader().Load();
    }
}