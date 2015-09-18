using UnityEngine;
using System.Collections;
using UnityEngine.UI;
//Input to slider script
public class Custominput : MonoBehaviour {
	public GameObject textobject;
	public Text execrisetext;
	public static float exercises;
	public GameObject timeinput;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		//float TimeTextScript = timeinput.GetComponent<CustomSetTime>();
		string text = GetComponent<Text> ().text;

		if (text == "") {
			text = "1";
			
		}

		exercises = float.Parse (text);

		if(Input.GetKey("space")){
			Debug.Log(exercises);
			Debug.Log(CustomSetTime.amttime);
			Application.LoadLevel("Evolution");

		}
	}

}
