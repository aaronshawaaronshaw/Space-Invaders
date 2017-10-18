using UnityEngine;
using System.Collections;

public class Position : MonoBehaviour {

	/*
	 * Allows us to see the outline of our formation in editor mode
	 */
	void OnDrawGizmos(){
		Gizmos.DrawWireSphere(transform.position, 1);
	}
}
