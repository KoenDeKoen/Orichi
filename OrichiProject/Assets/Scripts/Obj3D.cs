using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Obj3D : MonoBehaviour 
{
	public GameObject flower1;
	public GameObject flower2;
	public GameObject flower3;
	public GameObject bush1;
	public GameObject bush2;

	private List<GameObject> objects;
	// Use this for initialization
	public void Initialise () 
	{
		objects = new List<GameObject> ();
		objects.Add (flower1);
		objects.Add (flower2);
		objects.Add (flower3);
		//martijn
		objects.Add (bush1);
		objects.Add (bush2);
	}

	public List<GameObject> returnObjects()
	{
		return objects;
	}
}
