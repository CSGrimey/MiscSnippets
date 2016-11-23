namespace MiscSnippets.Code.DesignPatterns {
    public class Singleton {
        private static Singleton instance;

        private static Singleton Instance {
            get {
                if (instance == null) instance = new Singleton();

                return instance;
            }
        }

        private Singleton() { }
    }
}