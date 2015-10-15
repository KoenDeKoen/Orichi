using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.IO;
public class HighScore : MonoBehaviour {
	public Text highscoretext;
	public float highscore;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (PlayerPrefs.HasKey ("highscore")) {
			highscore = PlayerPrefs.GetFloat ("highscore");
			highscoretext.text = "Highscore: " + highscore.ToString ("f1") + " seconds";
		}
	}
}
