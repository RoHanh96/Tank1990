using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEnemy : MonoBehaviour {

	// Use this for initialization
	public int speed;
	public float lifeTime;
	public SpriteRenderer base_death;
	private GameObject base_;
	void Start () {
		GetComponent<Rigidbody2D> ().velocity = transform.up.normalized * speed;
		Destroy (gameObject, lifeTime);
	}
	
	// Update is called once per frame
	void Update () {
	}

	void OnTriggerEnter2D(Collider2D c){
		if(c.tag == "Player"){
			Destroy (c.gameObject);
			Destroy (gameObject);
		}
		else if(c.tag == "Brick"){
			Destroy (c.gameObject);
			Destroy (gameObject);
		}
		else if(c.tag == "Stone"){
			Destroy (gameObject);
		}
	}
}
