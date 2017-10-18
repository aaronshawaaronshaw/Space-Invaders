using UnityEngine;
using System.Collections;

public class StarField : MonoBehaviour {

	static StarField instance = null;
	static int count = 0;
	
	// Use this for initialization
	void Start () {
		//if (instance != null && instance != this && count < 4) {
		if (instance != null && count >= 3) {
			Destroy (gameObject);
			print ("Duplicate starfield player self-destructing!");
		} else {
			int temp = count;
			temp++;
			count = temp;
			//count++
			instance = this;
			GameObject.DontDestroyOnLoad(gameObject);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
