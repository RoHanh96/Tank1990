using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootPlayerInRange : MonoBehaviour {

	// Use this for initialization
	public float playerRange;
	public GameObject enemyBullet;
	public PlayerController thePlayer;
	public float waitBetweenShots;
	private float shotCounter;
	void Start () {
		//thePlayer = GameManager.Instance.player;
		thePlayer = FindObjectOfType<PlayerController> ();
		shotCounter = waitBetweenShots;
	}
	
	// Update is called once per frame
	void Update () {
		if (thePlayer != null) {
			Debug.DrawLine (new Vector3 (transform.position.x - playerRange, transform.position.y, transform.position.z), 
				new Vector3 (transform.position.x + playerRange, transform.position.y, transform.position.z));
			shotCounter -= Time.deltaTime;
			if (transform.localScale.x < 0 && thePlayer.transform.position.x > transform.position.x
			  && thePlayer.transform.position.x < transform.position.x + playerRange
			  && shotCounter < 0) {
				Instantiate (enemyBullet, transform.GetChild (0).position, transform.GetChild (0).rotation);
				shotCounter = waitBetweenShots;
			} else if (transform.localScale.x > 0 && thePlayer.transform.position.x < transform.position.x
			       && thePlayer.transform.position.x > transform.position.x - playerRange
			       && shotCounter < 0) {
				Instantiate (enemyBullet, transform.GetChild (0).position, transform.GetChild (0).rotation);
				shotCounter = waitBetweenShots;
			}
		}
	}
}
