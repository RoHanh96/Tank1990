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
		if (other.tag == "Water") {
			if(parent.tag == "Player"){
				if (parent.GetComponent<PlayerController> ().canTravelWater) {
					other.tag = "CanTravelWater";
					other.isTrigger = true;
				}
			} else {
				if (parent.GetComponent<EnemyController> ().canTravelWater) {
					other.tag = "CanTravelWater";
					other.isTrigger = true;
				}
			}
		}
	}

	void OnTriggerExit2D(Collider2D other){
		if ((other.tag == "Water" || other.tag == "CanTravelWater") && (parent.tag == "Player" || parent.tag == "Enemy")) {
			other.tag = "Water";
			other.isTrigger = false;
		}
	}
}
