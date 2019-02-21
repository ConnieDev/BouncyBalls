using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData : MonoBehaviour {
	public static GameData data;
	public bool hasGameData;
	public int highScore;
	public int money;
	public float adCounter;

	void Awake(){
		if (data == null) {
			DontDestroyOnLoad (gameObject);
			data = this;
		}else if(data != this){
			Destroy (gameObject);
		}
	}

	public void Save(){
		PlayerPrefs.SetInt ("hasGameData", (hasGameData ? 1 : 0));
		PlayerPrefs.SetInt ("HighScore", highScore);
		PlayerPrefs.SetInt ("Money", money);
	}

	public void Load(){
		hasGameData = (PlayerPrefs.GetInt ("hasGameData") != 0);
		highScore = PlayerPrefs.GetInt ("HighScore", highScore);
		money = PlayerPrefs.GetInt ("Money", money);
	}

}
