using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour {

	public GameObject InstructionScreen;
	public GameObject pauseScreen;
	public GameObject HighScoreScreen;
	public Button pauseButton;


	public void SwichScene(string scene){
		Time.timeScale = 1;
		SceneManager.LoadScene (scene);
	}

	public void Quit(){
		Application.Quit ();
	}

	public void ToggleInstructionScreen(){
		if(InstructionScreen.activeSelf == false){
			InstructionScreen.SetActive (true);
		}else {
			InstructionScreen.SetActive (false);
		}
	}

	public void TogglePauseScreen(){
		if(pauseScreen.activeSelf == false){
			GameController.controller.isPaused = true;
			pauseScreen.SetActive (true);
			Time.timeScale = 0;
			pauseButton.interactable = false;
		}else {
			GameController.controller.isPaused = false;
			pauseScreen.SetActive (false);
			if(GameController.controller.isStarted == true){
				Time.timeScale = 1;
			}
			pauseButton.interactable = true;
		}
	}
	public void ToggleHighScoreScreen(){
		GameController.controller.isPaused = false;
		HighScoreScreen.SetActive (false);
		Time.timeScale = 1;
		pauseButton.interactable = true;
	}
}
