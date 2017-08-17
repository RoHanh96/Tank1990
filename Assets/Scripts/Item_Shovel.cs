using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_Shovel : MonoBehaviour {

	public int duration;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	IEnumerator OnTriggerEnter2D(Collider2D other){

		if (other.tag == "Player" || other.tag == "Enemy") {

			GetComponent<Renderer> ().enabled = false;

			if (other.tag == "Player") {
				GameObject outerWall = GameObject.Find ("OurHomeland/Bricks/OuterWall");
				GameObject innerWall = GameObject.Find ("OurHomeland/Bricks/InnerWall");
				Transform stoneWall = GameObject.Find ("OurHomeland").transform.GetChild(2);

				outerWall.SetActive (false);
				innerWall.SetActive (false);
				stoneWall.gameObject.SetActive (true);

				yield return new WaitForSeconds (duration);

				outerWall.SetActive (true);
				innerWall.SetActive (true);
				stoneWall.gameObject.SetActive (false);

			} else {
				GameObject outerWall = GameObject.Find ("OurHomeland/Bricks/OuterWall");
				int childsNumber = outerWall.transform.childCount;
					
				if (childsNumber != 0 && outerWall.activeSelf) {
					outerWall.SetActive (false);
				} else {
					GameObject innerWall = GameObject.Find ("OurHomeland/Bricks/InnerWall");
					childsNumber = innerWall.transform.childCount;
					if (childsNumber != 0 && innerWall.activeSelf) {
						innerWall.SetActive (false);
					}
				}
			}

			Destroy (gameObject);
		}
	}
}
