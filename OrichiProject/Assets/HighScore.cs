using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class HighScore : MonoBehaviour {
	public Text highscoretext;
	public float highscore;
	// Use this for initialization
	void Start () {
	highscore =	PlayerPrefs.GetFloat ("highscore");
	}
	
	// Update is called once per frame
	void Update () {

		highscoretext.text = highscore.ToString ("f1");
	}
}
