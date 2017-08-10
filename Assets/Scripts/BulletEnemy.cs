using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEnemy : MonoBehaviour {
	public EnemyController controller;
	// Use this for initialization
	public int speed;
	public float lifeTime;
	//public bool canDestroyStone = false;
	public SpriteRenderer base_death;
	private GameObject base_;
	void Start () {
		controller = FindObjectOfType<EnemyController> ();
	}
	
	// Update is called once per frame
	void Update () {
		GetComponent<Rigidbody2D> ().velocity = transform.up.normalized * speed;
		Destroy (gameObject, lifeTime);
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
			if(controller.type == 4){
				Destroy (c.gameObject);
				Destroy (gameObject);
				//canDestroyStone = false;
			}
			else{
				Destroy (gameObject);
			}
		}
	}
}
