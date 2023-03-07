namespace SaveAndLoadModule
{
    [System.Serializable]
    public class ProjectDataContainer : BaseData
    {
        //[TODO] Ref
        public int ValueA => _valueA;
        public int ValueB => _valueB;
        public int ValueC => _valueC;

        private int _valueA = 0;
        private int _valueB = 0;
        private int _valueC = 0;

        public ProjectDataContainer() : base() { }

        public void SetValueA(int a) => _valueA = a;
        public void SetValueB(int b) => _valueB = b;
        public void SetValueC(int c) => _valueC = c;

        //[TODO] Описать контейнеры для специфических наборов данных:
        //UI, Environtment, Quest, Tasks and other...
    }
}


