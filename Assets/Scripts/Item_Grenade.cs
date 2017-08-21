using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_Grenade : MonoBehaviour {
	private LifeManager lifeSystem;
	public GameObject explosion;

	// Use this for initialization
	void Start () {
		lifeSystem = FindObjectOfType<LifeManager> ();
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
					Instantiate (explosion, enemyList[i].transform.position, enemyList[i].transform.rotation);
					Destroy (enemyList[i].gameObject);
				}
			} else {
				PlayerController[] playerList = FindObjectsOfType<PlayerController> ();
				for (int i = 0; i < playerList.Length; i++) {
					Instantiate (explosion, playerList [i].transform.position, playerList [i].transform.rotation);
					Destroy (playerList[i].gameObject);
				}
				lifeSystem.TakeLife ();
				lifeSystem.RespawnPlayer ();
			}
			Destroy (gameObject);
		}
	}
}
