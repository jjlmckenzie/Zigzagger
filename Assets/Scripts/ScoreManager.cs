using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour {

	public static ScoreManager instance;

	public int score;
	public int highScore;
	public Text newPB;

	void Awake() {
		if (instance == null) {
			instance = this;
		}
	}


	// Use this for initialization
	void Start () {
		score = 0;
		PlayerPrefs.SetInt ("score", score);
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void IncrementScore() {
		score += 1;
	}

	public void StartScore() {
		InvokeRepeating ("IncrementScore", 0.1f, 0.5f);
	}

	public void StopScore() {
		CancelInvoke ("IncrementScore");
		PlayerPrefs.SetInt ("score", score);
		LeaderboardManager.instance.AddScoreToLeaderboard ();

		if (PlayerPrefs.HasKey ("highScore")) {
			
			if (score > PlayerPrefs.GetInt ("highScore")) {
				PlayerPrefs.SetInt ("highScore", score);
				newPB.text = "Congratulations! \n New PB!";
			} else {
				newPB.text = "Play again?";
			}
		} else {
			PlayerPrefs.SetInt ("highScore", score);
			newPB.text = "Congratulations! \n New PB!";

		}
	}


}
