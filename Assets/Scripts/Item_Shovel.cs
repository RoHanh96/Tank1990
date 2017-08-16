using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_Shovel : MonoBehaviour {

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

				yield return new WaitForSeconds (duration);

			} else {
				yield return new WaitForSeconds (0f);
			}

			Destroy (gameObject);
		}
	}
}
