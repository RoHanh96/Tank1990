using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEnemy : MonoBehaviour {
	public EnemyController controller;
	// Use this for initialization
	private float speed;
	public float lifeTime;
	//public bool canDestroyStone = false;
	private LifeManager lifeSystem;
	public GameObject explosion;

	void Start () {
		controller = FindObjectOfType<EnemyController> ();
		lifeSystem = FindObjectOfType<LifeManager>();
		speed = controller.bulletSpeed;
	}
	
	// Update is called once per frame
	void Update () {
		GetComponent<Rigidbody2D> ().velocity = transform.up.normalized * speed;
		Destroy (gameObject, lifeTime);
	}

	void OnTriggerEnter2D(Collider2D c){
		if(c.tag == "Player"){
			if (!c.GetComponent<PlayerController> ().isImmortal) {
				lifeSystem.TakeLife ();
				Destroy (c.gameObject);
				Destroy (gameObject);
				Instantiate (explosion, c.transform.position, c.transform.rotation);
				if (lifeSystem.lifeCounter > 0) {
					lifeSystem.RespawnPlayer ();
				}
			} else {
				Destroy (gameObject);
			}
		}
		else if(c.tag == "Brick"){
			Destroy (c.gameObject);
			Destroy (gameObject);
		}
		else if(c.tag == "Stone"){
			if(controller.type == 5){
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
