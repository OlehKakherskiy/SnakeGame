using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary; 
using System.IO;

public class FileGameProceedStrategy : GameProceedingStrategy {

	public void Save(GameData gameData) {
		string saveToFile = Application.persistentDataPath + "/savedGame.gd";
		Debug.Log("Save game to file = "+saveToFile);
		BinaryFormatter bf = new BinaryFormatter();
		FileStream file = File.Create (saveToFile);
		bf.Serialize(file, gameData);
		file.Close();

		Debug.Log ("Game Data was saved");
	}

	public GameData Load() {
		GameData gameData = null;
		string loadFromFile = Application.persistentDataPath + "/savedGame.gd";
		if(File.Exists(loadFromFile)) {
			Debug.Log("File '"+loadFromFile+"' exist, so loading game");
			BinaryFormatter bf = new BinaryFormatter();
			FileStream file = File.Open(Application.persistentDataPath + "/savedGame.gd", FileMode.Open);
			gameData = (GameData) bf.Deserialize(file);
			file.Close();
			return gameData;
		}
		Debug.Log("File '"+loadFromFile+"' doesn't exist, so load from stub");
		return new GameData ();
	}

	public void RemoveSavedGame()
	{
		string loadFromFile = Application.persistentDataPath + "/savedGame.gd";
		if (File.Exists (loadFromFile)) {
			File.Delete (loadFromFile);
		}
	}
}
