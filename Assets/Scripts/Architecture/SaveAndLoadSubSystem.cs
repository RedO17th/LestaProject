using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SaveAndLoadModule;
using System.IO;
using Directory = System.IO.Directory;

namespace SaveAndLoadModule
{
    public interface ISaveLoadSystem : IObservableLoaderAndSaver
    {
        IData Data { get; }
        void Load();
        void Save();
    }

    public class SaveAndLoadSubSystem : BaseSubSystem, ISaveLoadSystem
    {
        [SerializeField] private string _dataStorageFolder = string.Empty;
        [SerializeField] private string _dataFileFormat = string.Empty;
        [SerializeField] private string _separator = string.Empty;

        public IData Data { get; private set; } = null;

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

        public override void Initialize() 
        {
            _observers = new List<IObserver>();
        }
        public override void Prepare() { }
        public override void StartSystem() { }

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
            Data = Load<ProjectDataContainer>();

            NotifyObserversToLoad();

            //Data = null ?
        }
        private T Load<T>() where T : BaseData
        {
            var fileName = GenerateFileName(typeof(T).Name);

            return _storage.Load<T>(fileName);
        }
        private string GenerateFileName(string fileName)
        {
            fileName = fileName + _separator + _dataFileFormat;

            return Path.Combine(_fullDataStoragePath, fileName);
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
            Data = new ProjectDataContainer();

            NotifyObserversToSave();
            SaveData(Data);

            //Data = null ?
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
        private void SaveData(ISavableData data)
        {
            var fileName = GenerateFileName(data.GetType().Name);

            _storage.Save(fileName, data);
        }

        public override void Clear()
        {
            _storage = null;
            _fullDataStoragePath = string.Empty;

            Data = null;

            _observers.Clear();
        }
    }
}