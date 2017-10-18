using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {
	public Sprite[] healtBars;
	
	private int healthCount, oldCount;
	private PlayerController player;

	// Use this for initialization
	void Start () {
		player = GameObject.FindObjectOfType<PlayerController>();
		healthCount = player.health / 100;
		oldCount = healthCount;	
	}
	
	// Update is called once per frame
	void Update () {
		healthCount = player.health / 100;
		
		if (healthCount != oldCount)	{loadSprites(); oldCount = healthCount;}	
	}
	
	
	/* 
	 * Loads the next available sprite from a sprite list. Used in updating the look of 
	 * a multi-hit block that has been "damaged". Called by handleHits()
	 * 
	 * Modifies: Updates the sprite of a damaged brick
	 * 
	 * Logs: Error if no sprite found
	 */
	void loadSprites(){
		//verify there is a sprite at the next index
		//loads the next sprite if there is a sprite there
		if(healtBars[healthCount]) 	{this.GetComponent<SpriteRenderer> ().sprite = healtBars[healthCount];} 
		else 						{Debug.LogError("No health bar sprite found");}
	}
	
	
	
	
	
	
	
	
}
