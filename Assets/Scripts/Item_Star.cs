using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_Star : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D other){

		if (other.tag == "Player" || other.tag == "Enemy") {
			if (other.tag == "Player") {
				if(other.GetComponent<PlayerController> ().level < 4)
					other.GetComponent<PlayerController> ().level++;
			} else {
				if(other.GetComponent<EnemyController> ().level < 4)
					other.GetComponent<EnemyController> ().level++;
			}
			Destroy (gameObject);
		}
	}
}
