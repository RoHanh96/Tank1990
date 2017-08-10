using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
	public float speed = 5;

	public Transform firePoint;
	public GameObject bullet;

	public float shootDelay;
	public float shootDelayCounter;

	public int level;

	// Use this for initialization
	void Start () {
		shootDelayCounter = 0;
	}
	
	// Update is called once per frame
	void Update () {
		float x = Input.GetAxisRaw ("Horizontal");
		float y = Input.GetAxisRaw ("Vertical");

		bool isHorizontal = Mathf.Abs (x) - Mathf.Abs (y) > 0.1f;

		Vector3 angle = Vector3.zero;
		Vector3 moveVector = Vector3.zero;
		if (isHorizontal) {
			angle.z = -90 * Mathf.Sign (x);
			moveVector = Vector3.right * Mathf.Sign (x);
		} else {
			angle.z =  y > 0 ? 0 : 180;
			moveVector = Vector3.up * Mathf.Sign (y);
		}
		if (x != 0 || y != 0) {
			transform.eulerAngles = angle;
			//Debug.Log (moveVector);
			transform.position += (moveVector * Time.deltaTime * speed);
		}

		Clamp ();

//		if (Input.GetKeyDown (KeyCode.Space)) {
//			shootDelayCounter = shootDelay;
//			Shot ();
//		}
		if(shootDelayCounter > 0)
			shootDelayCounter -= Time.deltaTime;

		if (Input.GetKey (KeyCode.Space) && shootDelayCounter <= 0) {
			Shot ();
			shootDelayCounter = shootDelay;
		}
	}

	public void Shot (){
		Instantiate (bullet, firePoint.transform.position, firePoint.transform.rotation);
	}

	void Clamp(){
		Vector2 min = Camera.main.ViewportToWorldPoint (new Vector2(0, 0));
		Vector2 max = Camera.main.ViewportToWorldPoint (new Vector2(1, 1));

		Vector2 pos = transform.position;

		float width = GetComponent<BoxCollider2D> ().bounds.size.x;
		float height = GetComponent<BoxCollider2D> ().bounds.size.y;

		pos.x = Mathf.Clamp (pos.x, min.x + width/2, max.x - width/2);
		pos.y = Mathf.Clamp (pos.y, min.y + height/2, max.y - height/2);

		transform.position = pos;
	}
}
