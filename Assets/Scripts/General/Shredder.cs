using UnityEngine;
using System.Collections;

public class Shredder : MonoBehaviour {
	
	/*
	 * Removes any object that comes in contact with the shredder trigger
	 */
	void OnTriggerEnter2D(Collider2D collider){
		Destroy (collider.gameObject);
	}
}
