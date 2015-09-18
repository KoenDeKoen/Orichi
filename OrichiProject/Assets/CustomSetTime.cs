using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class CustomSetTime : MonoBehaviour {
	public GameObject textobject;
	public Text execrisetext;
	public static float amttime;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		string text = GetComponent<Text> ().text;
		
		if (text == "") {
			text = "1";
			
		}

		
		amttime = float.Parse (text);


	}
}
