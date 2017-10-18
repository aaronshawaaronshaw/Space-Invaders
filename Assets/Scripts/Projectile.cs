using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {
	
	public int damage = 100;
	
	public int getDamage(){
		return damage;
	}
	
	public void hit(){
		Destroy(gameObject);
	}
}
