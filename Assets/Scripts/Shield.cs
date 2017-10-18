using UnityEngine;
using System.Collections;

public class Shield : MonoBehaviour {
	
	public Sprite[] shieldStates;
	
	/* 
	 * Loads the next available sprite from a sprite list. Used in updating the look of 
	 * a multi-hit block that has been "damaged". Called by handleHits()
	 * 
	 * Modifies: Updates the sprite of a damaged brick
	 * 
	 * Logs: Error if no sprite found
	 */
	public void loadSprites(int idx){
		this.GetComponent<SpriteRenderer>().sprite = shieldStates[idx];
	}
	
}
