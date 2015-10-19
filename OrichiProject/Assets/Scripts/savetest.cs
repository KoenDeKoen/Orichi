using UnityEngine;
using System.Collections;

public class savetest : MonoBehaviour {

	// Use this for initialization
	void Start () {
		if (PlayerPrefs.HasKey ("test"))
			Debug.Log (PlayerPrefs.GetInt ("test"));
		else
			Debug.Log ("No save data");

		PlayerPrefs.SetInt ("test", 1000);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
