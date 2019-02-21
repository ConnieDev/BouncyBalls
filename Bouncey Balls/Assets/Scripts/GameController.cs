using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Advertisements;

public class GameController : MonoBehaviour {

	public static GameController controller;
	public bool lose = false;
	public bool isPaused;
	public bool isStarted;
	public int highScore;
	public int money;

	public GameObject ball;
	public float ran;
	public int addBallNum;
	private int scaler;
	public int balls;
	public int taps;

	public Text tapText;
	public Text highScoreText;
	public Text ballsText;
	public Text startText;

	public Button pauseButton;


	void Awake(){
		controller = this;
	}
		
	void Start () {
		GameData.data.adCounter += 1;
		if(GameData.data.adCounter % 5 == 0){
			ShowAd ();
		}
		GameData.data.Load ();
		if (GameData.data.hasGameData) {
			highScore = GameData.data.highScore;
			money = GameData.data.money;
		} else {
			GameData.data.hasGameData = true;
			GameData.data.highScore = 0;
			GameData.data.money = 0;
			highScore = GameData.data.highScore;
			money = GameData.data.money;
			GameData.data.Save ();
		}
		taps = 0;
		addBallNum = 4;
		Time.timeScale = 0;
		balls = 1;
		scaler = 5;
		isPaused = false;
		isStarted = false;
		highScoreText.text = ("Best: " + highScore);
	}

	void Update () {
		if(Advertisement.isShowing == false){
			if(isStarted == false && isPaused == false){
				if (Input.touchCount > 0 && Input.GetTouch (0).phase == TouchPhase.Began && Input.GetTouch(0).position.y > 200) {
					Destroy (startText);
					isStarted = true;
					Time.timeScale = 1;
				}
			}
			if (isPaused == false && isStarted == true) {
				ran = Random.Range (-3, 3);
				tapText.text = ("Taps: " + taps);
				ballsText.text = ("Balls: " + balls);
				if (taps == addBallNum || taps > addBallNum) {
					SpawnBall ();
					balls += 1;
					addBallNum += (scaler * balls);
				}
			}
		}
	}

	void SpawnBall(){
		Vector3 pos = new Vector3 (ran,10,0);
		Instantiate (ball, pos, Quaternion.identity);
	}

	public void ShowAd(){
		if (Advertisement.IsReady ()) {
			Advertisement.Show ();
		}
	}
}
