using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class CustomSelect : MonoBehaviour {
	public static float currenttimer = 2;
	public static float currentspeed = 5;
	public GameObject textobject;
	public Text execrisetext;
	public string stringToEdit = "0";
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	if(Input.GetKey("space")){
			Application.LoadLevel("Evolution");
		}
	}

	public void CurrentBeatRate(){
		float val = GetComponent<UnityEngine.UI.Slider> ().value;

		currenttimer = val;
	}
	public void CurrentSpeedRate(){
		float valspeed = GetComponent<UnityEngine.UI.Slider> ().value;
		
		currentspeed = valspeed;
		Debug.Log (currentspeed);
	}

	public void Amountofexercises(){


		float exercises = GetComponent<UnityEngine.UI.Slider> ().value;
		string text = textobject.GetComponent<Text> ().text;
		if (text == "") {
			text = "0";

		}
		exercises = float.Parse(text);
		GetComponent<UnityEngine.UI.Slider> ().value = exercises;
	//	float.Parse (text) = exercises;

	}

}
