using UnityEngine;
using System.Collections;

public class ForceToForeground : MonoBehaviour {

	// Use this for initialization
	void Start () {
		if(GetComponent<Renderer>() != null)
			GetComponent<Renderer> ().sortingLayerName = "Foreground";
		Renderer[] r = transform.GetComponentsInChildren<Renderer> ();
		foreach (Renderer re in r) {
			re.sortingLayerName = "Foreground"; 	
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
