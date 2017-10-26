using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UiManager : MonoBehaviour {

	public static UiManager instance;

	public GameObject zigzaggerPanel;
	public GameObject gameOverPanel;
	public Text score;
	public Text highscoreA;
	public Text highscoreB;
	public GameObject startButton;
	public GameObject leaderboardButton;


	int i = 0;

	void Awake(){
		if (instance == null) {
			instance = this;
		}
	}

	// Use this for initialization
	void Start () {
		if (PlayerPrefs.HasKey ("highScore")) {
			highscoreA.text = "Personal Best: " + PlayerPrefs.GetInt ("highScore").ToString ();
		} else {
			highscoreA.text = "Personal Best: 0";
		}



	}

	public void GameStart(){
		startButton.SetActive (false);
		zigzaggerPanel.GetComponent<Animator> ().Play ("panelUp");
		leaderboardButton.SetActive (false);

	}

	public void GameOver() {

		score.text = PlayerPrefs.GetInt("score").ToString();
		highscoreB.text = PlayerPrefs.GetInt ("highScore").ToString ();
		gameOverPanel.SetActive(true);

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Reset() {

		UnityAdManager.instance.ShowAd();

	}

	public void ShowLeaderboard() {
		LeaderboardManager.instance.ShowLeaderboard ();
	}

}
