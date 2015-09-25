using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Obj3D : MonoBehaviour 
{

	public GameObject boom1;
	public GameObject boom2;
	public GameObject boom3;
	public GameObject flower1;
	public GameObject flower2;
	public GameObject flower3;
	//martijn
	public GameObject bush1;
	public GameObject bush2;

	private List<GameObject> objects;
	// Use this for initialization
	public void Initialise () 
	{
		objects = new List<GameObject> ();
		objects.Add (boom1);
		objects.Add (boom2);
		objects.Add (flower1);
		objects.Add (flower2);
		objects.Add (flower3);
		//martijn
		objects.Add (bush1);
		objects.Add (bush2);
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	public List<GameObject> returnObjects()
	{
		return objects;
	}
}
