using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour {

	public string levelSelect;
	public string mainMenu;
	public bool isPaused;
	public GameObject pauseGameScreen;

	void Update(){
		if (isPaused) {
			pauseGameScreen.SetActive (true);
			Time.timeScale = 0f;
		} else {
			pauseGameScreen.SetActive (false);
			Time.timeScale = 1f;
		}

		if (Input.GetKeyDown (KeyCode.Escape)) {
			isPaused = !isPaused;
		}
	}

	public void Resume(){
		isPaused = false;
	}

	public void LevelSelect(){
		Application.LoadLevel (levelSelect);
	}

	public void QuitToMainMenu(){
		Application.LoadLevel (mainMenu);
	}
}
