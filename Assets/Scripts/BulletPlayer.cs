using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPlayer : MonoBehaviour {
	public float speed;
	public GameObject explosion;
	public PlayerController player;
	public int power = 1;
	private Emitter emitter;


	// Use this for initialization
	void Start () {
		player = FindObjectOfType<PlayerController> ();
		emitter = FindObjectOfType<Emitter> ();
		player = FindObjectOfType<PlayerController> ();
	}
	
	// Update is called once per frame
	void Update () {
		GetComponent<Rigidbody2D> ().velocity = transform.up.normalized * speed;
	}
		
	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "Stone") {
			if(player.level == 4){
				Destroy (other.gameObject);
			}
			Destroy (gameObject);
		}
		if (other.tag == "EnemyBullet" || other.tag == "Brick") {
			Destroy (gameObject);
			Destroy (other.gameObject);
		}
		if (other.tag == "Enemy") {
			player.exp += 100;
			//emitter.numberEnemyOnDisplay--;
			Destroy (gameObject);
			//Destroy (other.gameObject);
			//Instantiate (explosion, other.transform.position, other.transform.rotation);
		}
	}
}
