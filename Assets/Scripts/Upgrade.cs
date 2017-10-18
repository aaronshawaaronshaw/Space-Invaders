using UnityEngine;
using System.Collections;

public class Upgrade : MonoBehaviour {
	
	public void upgradeGun(){
		PlayerController.gunUpgrade = true;
	}
	
	public void upgradeShield(){
		PlayerController.shieldUpgrade = true;
	}
	
	public void upgradePassiveFire(){
		PlayerController.passiveUpgrade = true;
	}
}
