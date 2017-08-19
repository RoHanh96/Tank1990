using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Emitter : MonoBehaviour {
	private static int numberOfEnemy = 0;
	public int numberEnemyOnDisplay =0;
	const int MAX_ENEMY = 15;
	public GameObject[] enemies;

	//public EnemyController enemyController;
	// Use this for initialization
	IEnumerator Start () {
		while(true){
			int currentEnemy = RandomEnemy ();
			print (numberEnemyOnDisplay);
			if(numberEnemyOnDisplay < 4){
				GameObject enemy = (GameObject)Instantiate (enemies[currentEnemy], enemies[currentEnemy].transform.position, Quaternion.identity);
				enemy.SetActive (true);
				numberEnemyOnDisplay++;
				numberOfEnemy++; 
				yield return new WaitForSeconds (2f);

			}
			//print (numberOfEnemy);
			if(numberOfEnemy == MAX_ENEMY){
				numberOfEnemy = 0;
				yield break;
			}
			else{
				yield return new WaitForSeconds (2f);
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	int RandomEnemy(){
		return Random.Range (0, 19);
	}
}
