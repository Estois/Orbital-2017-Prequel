using UnityEngine;
using System.Collections;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public static class SaveLoadManager
{
	public static void Save (Player player)
	{
		BinaryFormatter bf = new BinaryFormatter ();

		FileStream fs = new FileStream (Application.persistentDataPath + "/player.sav", FileMode.Create);

		SavedData savedData = new SavedData (player);

		bf.Serialize (fs, savedData);

		Debug.Log ("Game Saved!");

		fs.Close ();
	}

	public static int Load ()
	{
		if (File.Exists (Application.persistentDataPath + "/player.sav")) {
			BinaryFormatter bf = new BinaryFormatter ();
			FileStream fs = new FileStream (Application.persistentDataPath + "/player.sav", FileMode.Open);

			SavedData data = bf.Deserialize (fs) as SavedData;

			fs.Close ();
			return data.currentLevel;
		} else {
			Debug.LogError ("File does not exist");
			return 0;
		}
	}
}

[System.Serializable]
public class SavedData
{

	public int currentLevel;

	public SavedData (Player player)
	{
		currentLevel = player.currentLevel;
	}
}
