﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_Piston : MonoBehaviour {

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
				other.GetComponent<EnemyController> ().type = 5;
			}

			Destroy (gameObject);
		}
	}
}
