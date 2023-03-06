namespace SaveAndLoadModule
{
    public interface ILoadableData { }
    public interface ISavableData { }
    public interface IData : ILoadableData, ISavableData { }

    [System.Serializable]
    public class BaseData : IData
    {
        public BaseData() { }
    }
}