using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using UnityEngine;
using Patterns;

public class SavingLoadingData : Singleton<SavingLoadingData>
{
    private string savePath;
    public string resourceFilePath;

    public void Awake () {
        // Save and Load Assets from the Streaming Assets folder
        //
        savePath = Application.streamingAssetsPath;
        resourceFilePath = "resources.txt";
    }

    // Saves string input data into the given file name
    //
    public void SaveDataToFile(string filename, string data)
    {
        string filePath = Path.Combine(savePath, filename);

        if (!File.Exists(filePath))
        {
            File.Create(filePath);
        }

        File.WriteAllText(filePath, data);
    }

    // Loads data in the form of a string from a given filename
    //
    public string LoadDataFromFile(string filename)
    {
        string filePath = Path.Combine(savePath, filename);

        if (File.Exists(filePath))
        {
            return File.ReadAllText(filePath);
        }
        else
        {
            throw new UnityException("Trying to load from a file that does not exist");
        }
    }

    // Saves Data to a file in JSON format
    //
    public void SaveDataToFileAsJSON<T>(string filename, T data)
    {
        string filePath = Path.Combine(savePath, filename);

        if (!File.Exists(filePath))
        {
            File.Create(filePath);
        }

        string dataToWrite = JsonUtility.ToJson(data, true);

        File.WriteAllText(filePath, dataToWrite);
    }

    // Loads data in the form of a given type from a file that contains a JSON representation of the object
    //
    public T LoadDataFromFileAsJSON<T>(string filename)
    {
        string filePath = Path.Combine(savePath, filename);

        if (File.Exists(filePath))
        {
            string JSONdata = File.ReadAllText(filePath);

            T dataAsObject = JsonUtility.FromJson<T>(JSONdata);

            return dataAsObject;
        }
        else
        {
            throw new UnityException("Trying to load from a file that does not exist");
        }
    }
}
