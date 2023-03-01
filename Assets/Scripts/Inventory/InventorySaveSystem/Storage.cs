using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.Windows;
using Directory = System.IO.Directory;
using File = System.IO.File;

public class Storage
{
    private string _filePath = string.Empty;
    private string _fileName = string.Empty;
    private BinaryFormatter _formatter = null;

    public Storage() { }

    public Storage(string path, string file)
    {
        _filePath = path;
        _fileName = file;

        var directory = Path.Combine(Application.persistentDataPath, _filePath);

        CheckDirectoryAtExisting(directory);

        _filePath = Path.Combine(directory, _fileName);

        _formatter = new BinaryFormatter();
    }

    private void CheckDirectoryAtExisting(string directory)
    {
        if (Directory.Exists(directory) == false)
            Directory.CreateDirectory(directory);
    }

    public object Load(object saveDataByDefault)
    {
        if (File.Exists(_filePath) == false)
        {
            if (saveDataByDefault != null)
                Save(saveDataByDefault);

            return saveDataByDefault;
        }

        object loaded = null;

        using (FileStream fs = new FileStream(_filePath, FileMode.Open))
        {
            loaded = _formatter.Deserialize(fs);
        }

        return loaded;
    }

    public void Save(object saveData)
    {
        using (FileStream fs = new FileStream(_filePath, FileMode.OpenOrCreate))
        {
            _formatter.Serialize(fs, saveData);
        }
    }
}
