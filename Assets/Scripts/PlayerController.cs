using UnityEngine;

using System.Collections;

public class PlayerController : MonoBehaviour {
	public AudioClip laserFireAudio, dieAudio;
	public int health = 500;
	public float speed, fireRate;
	public GameObject laser;
	public Vector2 laserVel1, laserVel2, laserVel3;
	[HideInInspector] public static bool gunUpgrade = false;
	[HideInInspector] public static bool passiveUpgrade = false;
	[HideInInspector] public static bool shieldUpgrade = false;
	[HideInInspector] public static int playerScore;

	private int shieldValue = 2;
	private float  xmin, xmax, shieldDownTime = 0, padding = 1f, passiveFireTime = 0;
	private Shield shield;
	
	// Use this for initialization
	void Start () {
		float zdistance = transform.position.z - Camera.main.transform.position.z;
		Vector3 leftMostPos = Camera.main.ViewportToWorldPoint(new Vector3(0,0,zdistance));
		Vector3 rightMostPos = Camera.main.ViewportToWorldPoint(new Vector3(1,0,zdistance));
		
		xmin = leftMostPos.x + padding;
		xmax = rightMostPos.x - padding;
		shield = GameObject.FindObjectOfType<Shield>();
		shield.loadSprites(0);
		}
	
	// Update is called once per frame
	void Update () {
		handleMovement();
		handleLaser();
		handleUpgrades();
	}
	
	
	/*
	 * Handles movement left or right for the user. Prevents user from exiting play space using mathF.clamp
	 */ 
	void handleMovement(){
		if (Input.GetKey(KeyCode.LeftArrow)){
			//Restricts player to game space
			float xnew = Mathf.Clamp(transform.position.x + -speed * Time.deltaTime, xmin, xmax);
			transform.position = new Vector3(xnew, transform.position.y, transform.position.z);
		} else if (Input.GetKey(KeyCode.RightArrow)) {	
			//Restricts player to game space		
			float xnew = Mathf.Clamp(transform.position.x + speed * Time.deltaTime, xmin, xmax);
			transform.position = new Vector3(xnew, transform.position.y, transform.position.z);
		}
	}
	
	void handleUpgrades(){
		if(passiveUpgrade && Time.time - passiveFireTime > fireRate){
			fire (laserVel1);
			passiveFireTime = Time.time;
		}
		if(shieldUpgrade) {handleShield(); shield.loadSprites(shieldValue); print ("shield true");}
	}
	
	/*
	 * Handles user firing laser. Adjustable fire rate in unity editor.
	 */
	void handleLaser(){
		if (Input.GetKeyDown(KeyCode.Space)){InvokeRepeating("fireLaser", 0.0001f, fireRate);}
		if (Input.GetKeyUp(KeyCode.Space))	{
			CancelInvoke(); 
			//if (passiveUpgrade) {InvokeRepeating("fireRepeat", 0.0001f, fireRate);}
		}
		
	}
	
	/*
	 * Controlls laser shots from the player ship. Has default fire rate assigned by programmer in unity.
	 */
	void fireLaser() {
		//print (gunUpgrade);
		if (gunUpgrade) {fire (laserVel2);fire (laserVel3);}
		else 			{fire (laserVel1);}
	}
	
	void fire(Vector2 vel){
		Vector2 randomVel = new Vector2(0, Random.Range(-1f, .5f));
		AudioSource.PlayClipAtPoint(laserFireAudio, transform.position);
		Vector3 startPos = transform.position + new Vector3(0f, -.25f, 0f);
		GameObject missile = Instantiate(laser, startPos, Quaternion.identity) as GameObject;
		missile.rigidbody2D.velocity = vel + randomVel;
	}
	
	
	void handleShield(){
		if(shieldValue == 0 && Time.time - shieldDownTime >= 5.0f){shield.loadSprites(2); shieldValue = 2;}
	}
	
	/*
	 * Removes any object that comes in contact with the shredder trigger
	 */
	void OnTriggerEnter2D(Collider2D collider){
		Projectile laser = collider.gameObject.GetComponent<Projectile>();
		
		if (laser){
			laser.hit();
			if(shieldUpgrade && shieldValue > 0){
				shieldValue--;
				shield.loadSprites(shieldValue);
				if (shieldValue == 0)	{shieldDownTime = Time.time;}
			} else{
				health -= laser.getDamage();
				if (health <= 0f)	{die();}	
			}
				
		}
	}

	void die(){
		AudioSource.PlayClipAtPoint(dieAudio, transform.position);
		Application.LoadLevel("Lose Screen"); 
		Destroy(gameObject);
	}
	
	
	
}
