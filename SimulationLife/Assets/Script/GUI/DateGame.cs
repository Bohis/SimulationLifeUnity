using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Collections;
using UnityEngine;
												   
public class DateGame {
	public string Name;
	public List<GameObject> BotList { get; set; }
	public List<GameObject> OrganicList { get; set; }
	public GameObject Sun { get; set; }
	public int GenerationCount { get; set; }
	public int MaxLifeCount { get; set; }

	public DateGame() {
		BotList = null;
		OrganicList = null;
		Sun = null;
		Name = null;
		GenerationCount = 0;
	}

	public static DateGame Current;
}
