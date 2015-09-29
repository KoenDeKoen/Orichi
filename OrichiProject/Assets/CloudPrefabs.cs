using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CloudPrefabs : MonoBehaviour {

	// Use this for initialization
	public GameObject cloud1;
	public GameObject cloud2;
	public GameObject cloud3;
	private List<GameObject> clouds;

	public void Initialise () 
	{
		clouds = new List<GameObject> ();
		if(cloud1 != null)
		{
			clouds.Add (cloud1);
		}
		if(cloud2 != null)
		{
			clouds.Add (cloud2);
		}
		if(cloud3 != null)
		{
			clouds.Add (cloud3);
		}

	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	public List<GameObject> returnClouds()
	{
		return clouds;
	}
}
