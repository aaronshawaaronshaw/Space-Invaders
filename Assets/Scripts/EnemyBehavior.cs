using UnityEngine;
using System.Collections;

public class EnemyBehavior : MonoBehaviour {

	public AudioClip dieAudio, laserFireAudio;
	public GameObject projectile;	
	public float health = 200f, shotsPerSec = .75f;
	public Vector2 velocity, velocity2, velocity3;
	public int fireCount, value;
	
	private ScoreKeeper score;

	void Start(){
		score = GameObject.FindObjectOfType<ScoreKeeper>();
	}
	
	void Update(){
		float probability = Time.deltaTime * shotsPerSec;
		if (Random.value < probability) {
			fireLaser ();
		}
		
	}
	
	
	/*
	 * Removes any object that comes in contact with the shredder trigger
	 */
	void OnTriggerEnter2D(Collider2D collider){
		Projectile laser = collider.gameObject.GetComponent<Projectile>();
		if (laser){	
			laser.hit();
			health -= laser.getDamage();
			if (health <= 0f)	{die();}		
		}
	}
	
	/*
	 * Handles laser firing for the enemy unit
	 */
	void fireLaser(){		
		if (fireCount == 1)		{fire(velocity);}
		if (fireCount == 2)		{fire(velocity2); fire(velocity3);}
		if (fireCount == 3) 	{fire(velocity); fire(velocity2); fire(velocity3);}
		//AudioSource.PlayClipAtPoint(laserFireAudio, transform.position);
		//Vector3 startPos = transform.position + new Vector3(0f, -.25f, 0f);
		//GameObject missile = Instantiate(projectile, startPos, Quaternion.identity) as GameObject;
		//missile.rigidbody2D.velocity = velocity;
	}
	
	void fire(Vector2 vel){
		Vector2 randomVel = new Vector2(0, Random.Range(-1f, .5f));
		AudioSource.PlayClipAtPoint(laserFireAudio, transform.position);
		Vector3 startPos = transform.position + new Vector3(0f, -.25f, 0f);
		GameObject missile = Instantiate(projectile, startPos, Quaternion.identity) as GameObject;
		missile.rigidbody2D.velocity = vel + randomVel;
	}
	
	void die(){
		AudioSource.PlayClipAtPoint(dieAudio, transform.position);
		Destroy(gameObject);
		score.increase();
		PlayerController.playerScore += value;
	}
	
	
}
