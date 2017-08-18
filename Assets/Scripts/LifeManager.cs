using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeManager : MonoBehaviour {

	private Text lifeText;
	public int lifeCounter;

	public GameObject gameOverScreen;
	public PlayerController player;

	public GameObject respawnPoint;
	public GameObject playerRespawn;

	// Use this for initialization
	void Start () {
		lifeText = GetComponent<Text> ();
		lifeCounter = 3;
		player = FindObjectOfType<PlayerController> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (lifeCounter == 0) {
			gameOverScreen.SetActive (true);
			//player.gameObject.SetActive (false);
		}

		lifeText.text = "x " + lifeCounter;
	}

	public void GiveLife(){
		lifeCounter++;
	}

	public void TakeLife(){
		lifeCounter--;
	}

	public void RespawnPlayer(){
		Instantiate (playerRespawn, respawnPoint.transform.position, respawnPoint.transform.rotation);
	}
}
