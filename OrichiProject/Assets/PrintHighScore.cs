using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class PrintHighScore : MonoBehaviour {

	public float totalscore;
	// Use this for initialization
	void Start () {
		DontDestroyOnLoad (gameObject);
			
	}


	void StoreHighscore(float newHighscore)
	{
		newHighscore = HighScoreMode.timerscore;
		float oldHighscore = PlayerPrefs.GetFloat("highscore", 0);    
		if (newHighscore > oldHighscore) {
			PlayerPrefs.SetFloat ("highscore", newHighscore);
			PlayerPrefs.Save();
		}
		
	}
	
	// Update is called once per frame
	void Update () {
	
	
}
}