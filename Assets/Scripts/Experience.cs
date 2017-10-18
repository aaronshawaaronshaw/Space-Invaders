using UnityEngine;
using System.Collections;

public class Experience : MonoBehaviour {
	public Sprite[] scoreBars;
	
	private int scoreCount;
	private ScoreKeeper score;
	private LevelManager levelManager;
	
	// Use this for initialization
	void Start () {
		score = GameObject.FindObjectOfType<ScoreKeeper>();
		scoreCount = PlayerController.playerScore;
		print (scoreCount);
		this.GetComponent<SpriteRenderer>().sprite = scoreBars[0];
		
	}
	
	// Update is called once per frame
	void Update () {
		scoreCount = PlayerController.playerScore;
		
	}
	

	
}
