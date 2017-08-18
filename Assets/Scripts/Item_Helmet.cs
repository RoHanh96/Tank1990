using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_Helmet : MonoBehaviour {

	public int duration;

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
				other.GetComponent<PlayerController> ().isImmortal = true;
				yield return new WaitForSeconds (duration);
				other.GetComponent<PlayerController> ().isImmortal = false;
			} else {
				EnemyController[] enemyList = FindObjectsOfType<EnemyController> ();
				for (int i = 0; i < enemyList.Length; i++) {
					enemyList [i].GetComponent<EnemyController> ().level = 4;
				}

				yield return new WaitForSeconds (0f);
			}

			Destroy (gameObject);
		}
	}
}
