using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPlayer : MonoBehaviour {
	public float speed;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		GetComponent<Rigidbody2D> ().velocity = transform.up.normalized * speed;
	}
		
	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "Brick") {
			Destroy (gameObject);
			Destroy (other.gameObject);
		}

		if (other.tag == "Stone") {
			Destroy (gameObject);
		}

		if (other.tag == "Enemy") {
			Destroy (gameObject);
			Destroy (other.gameObject);
		}
	}
}
