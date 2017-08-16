using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanTravelWater : MonoBehaviour {

	private Transform parent;

	// Use this for initialization
	void Start () {
		parent = transform.parent;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "Water" && parent.tag == "Player") {
			if (!parent.GetComponent<PlayerController> ().canTravelWater) {
				parent.GetComponent<PlayerController> ().speed = 0f;
			}
		} else {
			if (other.tag == "Water" && parent.tag == "Enemy") {
				parent.GetComponent<EnemyController> ().speed = 0f;
			}
		}
	}

	void OnTriggerExit2D(Collider2D other){
		if (other.tag == "Water" && parent.tag == "Player") {
			parent.GetComponent<PlayerController> ().speed = parent.GetComponent<PlayerController> ().storeSpeed;
		} else {
			if (other.tag == "Water" && parent.tag == "Enemy") {
				parent.GetComponent<EnemyController> ().speed = parent.GetComponent<EnemyController> ().storeSpeed;
			}
		}
	}
}
