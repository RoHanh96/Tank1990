using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeManager : MonoBehaviour {

	private Text lifeText;
	public int lifeCounter;

	public GameObject gameOverScreen;


	public GameObject respawnPoint;
	public GameObject playerRespawn;

	private PlayerController player;

	// Use this for initialization
	void Start () {
		lifeText = GetComponent<Text> ();
		lifeCounter = 3;
	}
	
	// Update is called once per frame
	void Update () {
		if (lifeCounter == 0) {
			GameOver ();
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
		if (!gameOverScreen.gameObject.activeSelf) {
			Instantiate (playerRespawn, respawnPoint.transform.position, respawnPoint.transform.rotation);
		}
	}

	public void GameOver(){
		player = FindObjectOfType<PlayerController> ();
		player.gameObject.SetActive (false);
		gameOverScreen.SetActive (true);
	}
}
