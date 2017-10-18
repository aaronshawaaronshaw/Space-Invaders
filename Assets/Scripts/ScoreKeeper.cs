using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreKeeper : MonoBehaviour {

	public Text score;
	
	private int shipVal;
	// Use this for initialization
	void Start () {
		score.text = "score " + PlayerController.playerScore.ToString();
		//GameObject.DontDestroyOnLoad(gameObject);
	}
	
	public void increase(){
		EnemyBehavior enemy = GameObject.FindObjectOfType<EnemyBehavior>();
		shipVal = enemy.value;
		PlayerController.playerScore += shipVal;
		score.text = "score " + PlayerController.playerScore.ToString();
	}
	
	public static void reset(){
		//score.text = "score " + scoreVal.ToString();
		PlayerController.playerScore = 0;
	}
}
