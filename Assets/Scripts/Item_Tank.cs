using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_Tank : MonoBehaviour {

	private LifeManager lifeSystem;

	// Use this for initialization
	void Start () {
		lifeSystem = FindObjectOfType<LifeManager> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D other){

		if (other.tag == "Player" || other.tag == "Enemy") {
			if (other.tag == "Player") {
				lifeSystem.GiveLife ();
			} else {
				other.GetComponent<EnemyController> ().level = 4;
			}

			Destroy (gameObject);
		}
	}
}
