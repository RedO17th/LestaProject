using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SaveAndLoadModule;
using System.IO;
using Directory = System.IO.Directory;

namespace SaveAndLoadModule
{
    public interface ILoadableData { }
    public interface ISavableData { }

    //Базовый тип данных, используемый как пустышка:
    //Наследовать - можно.
    //Исправлять - нельзя.

    [System.Serializable]
    public class BaseData : ILoadableData, ISavableData
    {
        public BaseData() { }
    }
    //..

    public interface ILoader
    {
        void Load();
    }
    public interface ISaver
    {
        void Save();
    }

    public interface ISaveLoadSystem
    {
        T Load<T>() where T : BaseData;

        void Save(ISavableData data);
    }

    public class SaveAndLoadSubSystem : BaseSubSystem, ISaveLoadSystem
    {
        [SerializeField] private string _dataStorageFolder = string.Empty;
        [SerializeField] private string _dataFileFormat = string.Empty;
        [SerializeField] private string _separator = string.Empty;

        private Storage _storage = null;

        private string _fullDataStoragePath = string.Empty;

        protected override void Awake()
        {
            _storage = new Storage();

            _fullDataStoragePath = Path.Combine(Application.persistentDataPath, _dataStorageFolder);

            CheckDirectoryAtExisting(_fullDataStoragePath);
        }

        private void CheckDirectoryAtExisting(string directory)
        {
            if (Directory.Exists(directory) == false)
                Directory.CreateDirectory(directory);
        }

        public override void Initialize() { }
        public override void Prepare() { }
        public override void StartSystem() { }

        //Указываем необходимый тип для получения
        public T Load<T>() where T : BaseData
        {
            var fileName = GenerateFileName(typeof(T).Name);

            return _storage.Load<T>(fileName);
        }

        private string GenerateFileName(string fileName)
        {
            fileName = fileName + _separator + _dataFileFormat;

            return Path.Combine(_fullDataStoragePath, fileName);
        }

        //Передаем сохраняемый контейнер наследованный от "BaseData"
        public void Save(ISavableData data)
        {
            var fileName = GenerateFileName(data.GetType().Name);

            _storage.Save(fileName, data);
        }

        public override void Clear()
        {

        }
    }
}