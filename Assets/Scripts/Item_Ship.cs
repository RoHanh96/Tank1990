using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_Ship : MonoBehaviour {

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
				other.GetComponent<PlayerController> ().canTravelWater = true;
				yield return new WaitForSeconds (duration);
				if(other != null)
					other.GetComponent<PlayerController> ().canTravelWater = false;
			} else {
				other.GetComponent<EnemyController> ().canTravelWater = true;
				yield return new WaitForSeconds(duration);
				if(other != null)
					other.GetComponent<EnemyController> ().canTravelWater = false;
			}

			Destroy (gameObject);
		}
	}
}
