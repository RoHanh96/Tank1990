using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelect : MonoBehaviour {

	public string level1;
	public string level2;

	public void Level1(){
		Application.LoadLevel (level1);
	}

	public void Level2(){
		Application.LoadLevel (level2);
	}
}
