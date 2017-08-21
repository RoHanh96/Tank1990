using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseDeathByBullet : MonoBehaviour {

	private LifeManager lifeSystem;
	public Sprite base_death;

	void Start () {
		lifeSystem = FindObjectOfType<LifeManager> ();
	}

	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter2D(Collider2D c){
		if(c.tag == "EnemyBullet" || c.tag == "PlayerBullet"){
			gameObject.GetComponent<SpriteRenderer> ().sprite = base_death;
			lifeSystem.GameOver ();
			Destroy (c.gameObject);
		}
	}
}
