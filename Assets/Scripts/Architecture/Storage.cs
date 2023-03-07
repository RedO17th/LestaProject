using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

namespace SaveAndLoadModule
{
    public class Storage
    {
        private BinaryFormatter _formatter = null;

        public Storage()
        {
            _formatter = new BinaryFormatter();
        }

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
}


