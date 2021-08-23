using UnityEngine;
using System.IO;
using Newtonsoft.Json;
using System.Collections.Generic;

public static class SaveManager
{
    public static string directory = "SaveData";
    public static string fileName = "Savefile.oko";

    public static void Save(List<Symbol> saveSymbolsList)
    {
        if (!DirectoryExists())
            Directory.CreateDirectory(Application.persistentDataPath + "/" + directory);

        string json = JsonConvert.SerializeObject(saveSymbolsList, Formatting.Indented);

        File.WriteAllText(GetFullPath(), json);
    }

    public static List<Symbol> Load()
    {
        if (SaveExists())
        {           
            string json = File.ReadAllText(GetFullPath());
            List<Symbol> saveSymbolsList = JsonConvert.DeserializeObject<List<Symbol>>(json);
            Debug.Log("File was saved");
            return saveSymbolsList;
        }
        else
        {
            Debug.Log("Save file doesn't exist");
        }

        return null;
    }

    private static bool SaveExists()
    {
        return File.Exists(GetFullPath());
    }

    private static bool DirectoryExists()
    {
        return Directory.Exists(Application.persistentDataPath + "/" + directory);
    }

    private static string GetFullPath()
    {
        return Application.persistentDataPath + "/" + directory + "/" + fileName;
    }
}

