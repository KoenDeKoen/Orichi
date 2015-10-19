using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Trees3D : MonoBehaviour 
{

	// Use this for initialization
	public GameObject boom1;
	public GameObject boom2;
	public GameObject boom3;
	public GameObject boom4;
	public GameObject boom5;
	//public GameObject boom6;
	private List<GameObject> trees;

	public void Initialise () 
	{
		trees = new List<GameObject> ();
		trees.Add (boom1);
		trees.Add (boom2);
		trees.Add (boom3);
		trees.Add (boom4);
		trees.Add (boom5);
		//trees.Add (boom6);
	}

	public List<GameObject> returnObjects()
	{
		return trees;
	}
}
