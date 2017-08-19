using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Emitter1 : MonoBehaviour {
	private static int numberOfEnemy = 0;
	public int numberEnemyOnDisplay = 0;
	private EnemyController theEnemy;
	public GameObject[] enemies;
	Animator animator;
	const int MAX_ENEMY = 15;

	// Use this for initialization
	IEnumerator Start () {
		while(true){
			int currentType = Random.Range(0,5);
			if(numberEnemyOnDisplay < 4){
				GameObject enemy = (GameObject)Instantiate (enemies[currentType], enemies[currentType].transform.position, Quaternion.identity);
				int currentLevel = Random.Range (1, 5);
				//print (currentLevel);
				enemy.GetComponent<Animator>().SetInteger ("Level", currentLevel);
				enemy.GetComponent<EnemyController>().type= 1;
				enemy.GetComponent<EnemyController>().level = currentLevel;
				numberEnemyOnDisplay++;
				numberOfEnemy++; 
				yield return new WaitForSeconds (2f);
			}
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
}
