using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour {

	public GameObject platform;
	Vector3 lastPos;
	float size;
	public bool gameOver;
	public GameObject smallCube;

	// Use this for initialization
	void Start () {
		lastPos = platform.transform.position;
		size = platform.transform.localScale.x;
		gameOver = false;

		for (int i = 0; i < 20; i++) {
			PlatformSpawn ();
		}


			
	}

	public void StartSpawning() {
		InvokeRepeating ("PlatformSpawn", 1f, 0.25f);
	}

	void PlatformSpawn() {
		int rand = Random.Range (0, 6);

		if (rand < 3) {
			SpawnX ();
		} else if (rand >= 3) {
			SpawnZ ();
		}

	}
	
	// Update is called once per frame
	void Update () {
		if (GameManager.instance.gameOver) {
			CancelInvoke("PlatformSpawn");
		}
	}

	void SpawnX() {
		Vector3 pos = lastPos;
		pos.x += size;
		lastPos = pos;
		Instantiate (platform, pos, Quaternion.identity);

		int rand = Random.Range (0, 12);
		if (rand < 3 && rand > 0) {
			Instantiate (smallCube, new Vector3(pos.x, pos.y+1, pos.z), Quaternion.identity);
		}
	}

	void SpawnZ() {
		Vector3 pos = lastPos;
		pos.z += size;
		lastPos = pos;
		Instantiate (platform, pos, Quaternion.identity);

		int rand = Random.Range (0, 12);
		if (rand < 3 && rand > 0) {
			Instantiate (smallCube, new Vector3(pos.x, pos.y+1, pos.z), Quaternion.identity);
		}
	}
}
