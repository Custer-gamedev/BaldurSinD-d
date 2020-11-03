using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Configuration;

public static class SaveData
{
    static string Path()
    {
        return Application.dataPath + "SavaData.json";
    }
    
   public static void Save(DataToSave saveD)
    {
        var json = JsonUtility.ToJson(saveD);
        File.WriteAllText(Path(), json);
    }
    
}
