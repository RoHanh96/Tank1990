using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_Grenade : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D other){

		if (other.tag == "Player" || other.tag == "Enemy") {

			GetComponent<Renderer> ().enabled = false;

			if (other.tag == "Player") {
				EnemyController[] enemyList = FindObjectsOfType<EnemyController> ();
				for (int i = 0; i < enemyList.Length; i++) {
					Destroy (enemyList[i].gameObject);
				}
			} else {
				PlayerController[] playerList = FindObjectsOfType<PlayerController> ();
				for (int i = 0; i < playerList.Length; i++) {
					Destroy (playerList[i].gameObject);
				}
			}

			Destroy (gameObject);
		}
	}
}
