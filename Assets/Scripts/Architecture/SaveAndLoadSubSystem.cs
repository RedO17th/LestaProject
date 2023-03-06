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

    public interface ISaveLoadSystem : IObservableLoaderAndSaver
    {
        //T Load<T>() where T : BaseData;
        //void Save(ISavableData data);

        void Load();
        void Save();
    }

    public class SaveAndLoadSubSystem : BaseSubSystem, ISaveLoadSystem
    {
        [SerializeField] private string _dataStorageFolder = string.Empty;
        [SerializeField] private string _dataFileFormat = string.Empty;
        [SerializeField] private string _separator = string.Empty;

        private Storage _storage = null;

        private string _fullDataStoragePath = string.Empty;

        private List<IObserver> _observers = null;

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

        //Observer functional
        public void AddObserver(IObserver o)
        {
            _observers.Add(o);
        }
        public void RemoveObserver(IObserver o)
        {
            _observers.Remove(o);
        }

        public void Load()
        {
            //PrepareData and...
            NotifyObserversToLoad();
        }
        private void NotifyObserversToLoad()
        {
            foreach (var observer in _observers)
            {
                if (observer is ILoaderObserver loader)
                { 
                    loader.NotifyAboutLoad();
                }
            }
        }

        public void Save()
        {
            NotifyObserversToSave();
            //Сохранить
        }
        private void NotifyObserversToSave()
        {
            foreach (var observer in _observers)
            {
                if (observer is ISaverObserver saver)
                {
                    saver.NotifyAboutSave();
                }
            }
        }

        public override void Clear()
        {

        }
    }
}