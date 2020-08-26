using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Collections;
using UnityEngine;

[System.Serializable]
public static class LoadDate {

	public static void Load() {
		if (File.Exists( Application.persistentDataPath + "/savedGames.gd" )) {
			BinaryFormatter bf = new BinaryFormatter();
			FileStream file = File.Open( Application.persistentDataPath + "/savedGames.gd", FileMode.Open );
			SaveDate.ForSaveGame.AddRange(( List<DateGame>)bf.Deserialize( file ));
			file.Close();
		}
	}
}