using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Configuration;

public static class SaveData
{
	public static string Path()
	{
		return Application.dataPath + "/SavaData.json";
	}

	public static void Save(DataToSave saveData)
	{
		var json = JsonUtility.ToJson(saveData);
		File.WriteAllText(Path(), json);
	}

	public static DataToSave Load()
	{
		var json = File.ReadAllText(Path());
		DataToSave loadedData = JsonUtility.FromJson<DataToSave>(json);
		return loadedData;
	}

}

