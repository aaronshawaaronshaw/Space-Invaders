using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreDisplay : MonoBehaviour {
	private ScoreKeeper keeper;
	// Use this for initialization
	void Start () {
		Text mytext = GetComponent<Text>();
		mytext.text = PlayerController.playerScore.ToString();
		ScoreKeeper.reset();
	}

}
