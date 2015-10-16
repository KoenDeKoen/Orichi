using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.IO;
public class HighScore : MonoBehaviour {
	public Text highscoretext;
	public Text secondplacetext;
	public Text thirdplacetext;
	public float highscore;
	public float secondplace;
	public float thirdplace;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (PlayerPrefs.HasKey ("highscore") && PlayerPrefs.HasKey ("secondplace") && PlayerPrefs.HasKey ("thirdplace") ) {
			highscore = PlayerPrefs.GetFloat ("highscore");
			secondplace = PlayerPrefs.GetFloat("secondplace");
			thirdplace = PlayerPrefs.GetFloat("thirdplace");

			highscoretext.text = "Highscore: " + highscore.ToString ("f1") + " seconds";
			secondplacetext.text = "Second: " + secondplace.ToString ("f1") + " seconds";
			thirdplacetext.text = "Third: " + thirdplace.ToString ("f1") + " seconds";
		}
	}
}
