using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

	// Use this for initialization
	public float speed;
	//public Transform shootPosition;
	public GameObject bullet;
	public float shotDelay;
	const int STATE_UP = 0;
	const int STATE_DOWN = 1;
	const int STATE_LEFT = 2;
	const int STATE_RIGHT = 3;
	private int currentState = STATE_UP;
	private float timeMove = 1.00f;
	private static float timeCounter = 0.00f;

	IEnumerator Start(){
		while(true){
			FireBullet ();
			yield return new WaitForSeconds (shotDelay);
		}
	}
	// Update is called once per frame
	void Update () {
		//GoUp ();
		timeCounter += Time.deltaTime;
		if(timeCounter > timeMove){
			currentState = RandomState ();
			Move ();
			timeCounter = 0f;
		}
		else{
			Move ();
		}
	}

	int RandomState(){
		int number;
		do {
			number = Random.Range (-1,4);
		} while(number == currentState);
		return number;
	}
	 
	void Move(){
		//bool isHorizontal;
		switch(currentState){
		case STATE_UP: {
				//isHorizontal = false;
				Vector3 angle = Vector3.zero;
				Vector3 moveVector = Vector3.zero;
				angle.z = 0;
				moveVector = Vector3.up;
				transform.eulerAngles = angle;
				transform.position += moveVector * Time.deltaTime * speed;
				break;
			}
		case STATE_DOWN:{
				Vector3 angle = Vector3.zero;
				Vector3 moveVector = Vector3.zero;
				angle.z = 180;
				moveVector = Vector3.up * -1;
				transform.eulerAngles = angle;
				transform.position += moveVector * Time.deltaTime * speed;
				break;
			}
		case STATE_LEFT: {
				Vector3 angle = Vector3.zero;
				Vector3 moveVector = Vector3.zero;
				angle.z = -90;
				moveVector = Vector3.right * 1;
				transform.eulerAngles = angle;
				transform.position += moveVector * Time.deltaTime * speed;
				break;
			}
		case STATE_RIGHT: {
				Vector3 angle = Vector3.zero;
				Vector3 moveVector = Vector3.zero;
				angle.z = 90;
				moveVector = Vector3.right * -1;
				transform.eulerAngles = angle;
				transform.position += moveVector * Time.deltaTime * speed;
				break;
			}
		}
	}

	void FireBullet(){
		Instantiate(bullet, transform.GetChild(0).position, transform.GetChild(0).rotation);
	}
}
