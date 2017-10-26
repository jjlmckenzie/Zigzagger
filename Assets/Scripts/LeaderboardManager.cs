using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GooglePlayGames;
using UnityEngine.SocialPlatforms;
using GooglePlayGames.BasicApi;

public class LeaderboardManager : MonoBehaviour {


	public static LeaderboardManager instance;

	//void Awake() {
	//	if (instance == null) {
	//		instance = this;
	//	}
	//}

	void Awake() {

		if (instance == null) {
			instance = this;
		} 
	}


	// Use this for initialization
	void Start () {
		//PlayGamesClientConfiguration config = new PlayGamesClientConfiguration.Builder ().Build ();
		PlayGamesPlatform.Activate ();
		SignIn ();
	}


	public void SignIn() {
		Social.localUser.Authenticate ((bool success) => {
		});
	}

	public void AddScoreToLeaderboard() {

		Social.ReportScore(PlayerPrefs.GetInt("score"), "CgkIlbWC2OMEEAIQAA", (bool success) => {
			
		});

		Debug.Log ("Help");
			
	}

	public void ShowLeaderboard() {
		//Social.ShowLeaderboardUI ();

		if (Social.localUser.authenticated) {
			PlayGamesPlatform.Instance.ShowLeaderboardUI ("CgkIlbWC2OMEEAIQAA");
			//PlayGamesPlatform.Instance.ShowLeaderboardUI (Leaderboard.leaderboard_best_players);
			//Social.ShowLeaderboardUI ();

		} else {
			//LeaderboardManager.SignIn ();
		}





	}


	// Update is called once per frame
	void Update () {
		
	}
}
