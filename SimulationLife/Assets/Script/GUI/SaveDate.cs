using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Collections;
using UnityEngine;

[System.Serializable]
public static class SaveDate {

	public static List<DateGame> ForSaveGame = new List<DateGame>();

	public static void Save() {
		ForSaveGame.Add(DateGame.Current);
		BinaryFormatter bf = new BinaryFormatter();
		FileStream file = new FileStream( Application.persistentDataPath + "/savedGame.gd", FileMode.Create );
		bf.Serialize( file, SaveDate.ForSaveGame );
		file.Close();
	}
	
}																							  