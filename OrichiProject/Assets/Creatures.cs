using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Creatures : MonoBehaviour 
{

	// Use this for initialization
	private List<string> imagenames;
	void Start () 
	{
		imagenames = new List<string> ();
		imagenames.Add ("Koala");
		imagenames.Add ("Derp");
	}
	
	// Update is called once per frame
	void Update () 
	{
	}

	public List<string> returnImageNames()
	{
		return imagenames;
	}
}
