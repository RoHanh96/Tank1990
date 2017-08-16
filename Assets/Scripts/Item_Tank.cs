using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_Tank : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D other){

		if (other.tag == "Player" || other.tag == "Enemy") {
			if (other.tag == "Player") {
				
			} else {
				other.GetComponent<EnemyController> ().level = 4;
			}

			Destroy (gameObject);
		}
	}
}
