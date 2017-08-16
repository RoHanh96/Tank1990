using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_Clock : MonoBehaviour {

	public float duration;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	IEnumerator OnTriggerEnter2D(Collider2D other){

		if (other.tag == "Player" || other.tag == "Enemy") {

			GetComponent<Renderer> ().enabled = false;

			if (other.tag == "Player") {
				EnemyController[] enemyList = FindObjectsOfType<EnemyController> ();
				for (int i = 0; i < enemyList.Length; i++) {
					enemyList [i].enabled = false;
					enemyList [i].GetComponent<ShootPlayerInRange> ().enabled = false;
					enemyList [i].GetComponent<Animator> ().enabled = false;
				}
				yield return new WaitForSeconds (duration);
				for (int i = 0; i < enemyList.Length; i++) {
					if (enemyList [i] != null) {
						enemyList [i].enabled = true;
						enemyList [i].GetComponent<ShootPlayerInRange> ().enabled = true;
						enemyList [i].GetComponent<Animator> ().enabled = true;
					}
				}
			} else {
				PlayerController[] playerList = FindObjectsOfType<PlayerController> ();
				for (int i = 0; i < playerList.Length; i++) {
					playerList [i].enabled = false;
					playerList [i].GetComponent<Animator> ().enabled = false;
				}
				yield return new WaitForSeconds (duration);
				for (int i = 0; i < playerList.Length; i++) {
					if (playerList [i] != null) {
						playerList [i].enabled = true;
						playerList [i].GetComponent<Animator> ().enabled = true;
					}
				}
			}

			Destroy (gameObject);
		}
	}
}
