using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using Directory = System.IO.Directory;
using File = System.IO.File;

namespace SaveAndLoadModule
{ 
    public class Storage
    {
        private BinaryFormatter _formatter = null;

        public Storage()
        {
            _formatter = new BinaryFormatter();
        }

        public object Load(object saveDataByDefault)
        {
            //if (File.Exists(_dataStoragePath) == false)
            //{
            //    if (saveDataByDefault != null)
            //        Save(saveDataByDefault);

            //    return saveDataByDefault;
            //}

            //object loaded = null;

            //using (FileStream fs = new FileStream(_dataStoragePath, FileMode.Open))
            //{
            //    loaded = _formatter.Deserialize(fs);
            //}

            //return loaded;
            return null;
        }

        public void Save(object saveData)
        {
            //using (FileStream fs = new FileStream(_dataStoragePath, FileMode.OpenOrCreate))
            //{
            //    _formatter.Serialize(fs, saveData);
            //}
        }

        //New realisation
        public T Load<T>(string fileName) where T : BaseData
        {
            T result = null;

            if (File.Exists(fileName) == false)
            {
                result = Activator.CreateInstance(typeof(T)) as T;

                SaveData(fileName, result);
            }
            else 
            {
                using (FileStream fs = new FileStream(fileName, FileMode.Open))
                {
                    result = _formatter.Deserialize(fs) as T; 
                }
            }

            return result;
        }

        public void Save(string fileName, ISavableData data) => SaveData(fileName, data);

        private void SaveData(string fileName, ISavableData data)
        {
            using (FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                _formatter.Serialize(fs, data);
            }
        }
    }

    public interface ILoadableData { }
    public interface ISavableData { }

    [System.Serializable]
    public class BaseData : ILoadableData, ISavableData 
    {
        public BaseData() { }
    }

    //Test
    [System.Serializable]
    public class TestLoadableData : BaseData
    {
        public TestLoadableData() { }
    }

    [System.Serializable]
    public class TestSavableData : BaseData
    {
        public TestSavableData() { }
    }
}


