using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckCollisionEnemy : MonoBehaviour {

	// Use this for initialization
	public EnemyController enemyController;
	void Start () {
		enemyController = FindObjectOfType<EnemyController> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D c){
		if(c.tag == "Enemy" || c.tag == "Water" || c.tag == "Brick" || c.tag == "Stone") {
			enemyController.collision = true;
		}
	}
}
