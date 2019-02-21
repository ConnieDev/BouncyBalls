using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Advertisements;

public class EndPlay : MonoBehaviour {

	public GameObject highScoreScreen;
	public Text HighScoreText;
	public Button pauseButton;

	void OnCollisionEnter2D(Collision2D colObj){
		if(colObj.gameObject.tag == "Ball"){
			if (GameController.controller.taps > GameData.data.highScore) {
				GameData.data.highScore = GameController.controller.taps;
				GameData.data.money += GameController.controller.taps;
				highScoreScreen.SetActive(true);
				HighScoreText.text = "" + GameData.data.highScore;
				GameController.controller.isPaused = true;
				Time.timeScale = 0;
				pauseButton.interactable = false;
				GameData.data.Save ();
			} else {
				GameData.data.money += GameController.controller.taps;
				SceneManager.LoadScene ("GameScene");
			}
		}
	}
}
