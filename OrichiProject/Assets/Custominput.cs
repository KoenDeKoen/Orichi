using UnityEngine;
using System.Collections;
using UnityEngine.UI;
//Input to slider script
public class Custominput : MonoBehaviour {
	public GameObject textobject;
	public Text execrisetext;
	public float exercises;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		string text = GetComponent<Text> ().text;

		if (text == "") {
			text = "1";
			
		}

		exercises = float.Parse (text);

		if(Input.GetKey("space")){
			Debug.Log(exercises);
			Application.LoadLevel("Evolution");

		}
	}

}
