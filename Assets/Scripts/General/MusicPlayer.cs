using UnityEngine;
using System.Collections;

public class MusicPlayer : MonoBehaviour {
	static MusicPlayer instance = null;
	
	public AudioClip startClip, difficultyClip, gameClip, endClip;
	
	private AudioSource music;
	
	void Start () {
		if (instance != null && instance != this) {
			Destroy (gameObject);
			print ("Duplicate music player self-destructing!");
		} else {
			instance = this;
			GameObject.DontDestroyOnLoad(gameObject);
			music = GetComponent<AudioSource>();
			music.clip = startClip;
			music.loop = true;
			music.Play();
		}
		
	}
	
	void OnLevelWasLoaded(int Level){
		print (Level);
		Debug.Log("MusicPlayer loaded level " + Level.ToString());
		if (Level == 0)	{
			//music.clip = startClip;
			return;
		}
		music.Stop ();
		

		if (Level == 1){
			music.clip = difficultyClip;
		}
		if (Level == 2 || Level == 3 || Level == 4)	{
			music.clip = gameClip;
		}
		if (Level == 5)	{
			music.clip = endClip;
		}
		
		//music.clip = startClip;
		music.loop = true;
		music.Play();
	}
	
	
	
	
	
}
