using UnityEngine;
using System.Collections;

public class EnemyFormation : MonoBehaviour {

	public GameObject enemyPrefab;
	public float width = 10f, height = 5f, speed, spawnDelay = 0.5f;

	private bool movingRight;
	private float padding, xmin, xmax;
	
	// Use this for initialization
	void Start () {
		spawnFormation();
		
		float zdistance = transform.position.z - Camera.main.transform.position.z; //distance between current enemy group and camera
		Vector3 leftMostPos = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, zdistance)); //left edge of screen
		Vector3 rightMostPos = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, zdistance)); //right edge of screen
		
		padding = width / 2.0f;
		//in this case padding is half our width--therefore we measure the distance to end from the edge, 
		//not center of the object;
		xmin = leftMostPos.x + padding;
		xmax = rightMostPos.x - padding;
		print (padding);
		movingRight = false;
	}
	
	// Update is called once per frame
	void Update () {
		handleMovement();
		if (countDead() == 0)	{spawnUntilFull();}
	}
	
	/*
	 * Spawns a predefined formation into the game.
	 */
	void spawnFormation(){
		foreach(Transform child in transform){ //Instantiate an enemy for every position location in this enemy formation
			GameObject enemy = Instantiate(enemyPrefab, child.transform.position, Quaternion.identity) as GameObject;
			enemy.transform.parent = child;
		}
	}
	
	/*
	 * Finds a free position in a formation and spawns an enemy at that location
	 */ 
	void spawnUntilFull(){
	
		Transform freePos = nextFreePosotion();
		if (freePos){
			GameObject enemy = Instantiate(enemyPrefab, freePos.position, Quaternion.identity) as GameObject;
			enemy.transform.parent = freePos;
		}
		//check if there is another free position to respawn into
		if (nextFreePosotion()){
			Invoke("spawnUntilFull", spawnDelay);
		}	
	}
	
	/*
	 * Checks to see how many enemy units are left in the formation
	 */
	public int countDead(){
		int count = 0;
		foreach(Transform child in transform)	{count += child.childCount;}
		return count;
	}
	
	/*
	 * Finds the next free position to spawn an enemy and spawns one there.
	 * ITerates through all positions, and finds the first free one using .childCount
	 */
	 Transform nextFreePosotion(){
	 	foreach(Transform child in transform){
	 		if (child.childCount == 0)	{return child;}
	 	}
	 	return null;
	 }
	
	/*
	 * Handles the left or right movement of the enemy formation. 
	 * Bounds their max distance to the edge of the screen
	 */
	void handleMovement(){
		// Move formation left or right depending on distance from edge
		if (!movingRight)	{ transform.position += Vector3.left * speed * Time.deltaTime;} 		
		else 				{ transform.position += Vector3.right * speed * Time.deltaTime;}
		// Updates movingLeft if we have gone beyond a x-boundary
		if 		(transform.position.x < xmin )			{ movingRight = true;} 
		else if (transform.position.x > xmax)			{ movingRight = false;}
		
	}

	/*
	 * Allows us to see the box outline of our enemy unit in the editor
	 */
	public void OnDrawGizmos(){
		Gizmos.DrawWireCube(transform.position, new Vector3(width, height));
	}

	
}
