using UnityEngine;
using System.Collections;

public class ResetHiScore : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void ResetHighScore(){
		PlayerPrefs.SetFloat ("highscore", 0);
		PlayerPrefs.SetFloat ("secondplace", 0);
		PlayerPrefs.SetFloat ("thirdplace", 0);

	}
}
