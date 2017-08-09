using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseDeathByEnemyBullet : MonoBehaviour {

	// Use this for initialization
	public Sprite base_death;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D c){
		if(c.tag == "EnemyBullet"){
			gameObject.GetComponent<SpriteRenderer> ().sprite = base_death;
		}
	}
}
