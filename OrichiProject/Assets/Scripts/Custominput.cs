using UnityEngine;
using System.Collections;
using UnityEngine.UI;
//Input to slider script
public class Custominput : MonoBehaviour {
	public GameObject textobject;
	public Text execrisetext;
	public static float exercises = 10;
	//public GameObject timeinput;
	public static bool tutorial;
	// Use this for initialization
	void Start ()
	{
		tutorial = true;
	}
	
	// Update is called once per frame
	void Update () {
		//float TimeTextScript = timeinput.GetComponent<CustomSetTime>();
		string text = GetComponent<Text> ().text;

		if (text == "") {
			text = "10";
			
		}

		exercises = float.Parse (text);

		if(Input.GetKey("space")){
			Debug.Log(exercises);
			Application.LoadLevel("Evolution");

		}
	}

	public void switchTutorial()
	{
		if(tutorial)
		{
			tutorial = false;
		}
		else
		{
			tutorial = true;
		}
	}

}
