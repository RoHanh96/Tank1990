using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseDeathByPlayerBullet : MonoBehaviour {
	public Sprite base_death;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D c){
		if(c.tag == "PlayerBullet"){
			gameObject.GetComponent<SpriteRenderer> ().sprite = base_death;
			Destroy (c.gameObject);
		}
	}
}
