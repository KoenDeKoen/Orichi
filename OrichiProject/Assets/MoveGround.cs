using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MoveGround : MonoBehaviour {

	// Use this for initialization
	//public GameObject floorandshizzle;
	//public SpawnGroundAndProps spawngroundandprops;
	private bool hastolerp;
	private GameObject parent;
	private Vector3 endposition;

	void Start () 
	{
		endposition = new Vector3 (0, 0, 0);
	}
	
	// Update is called once per frame
	void Update () 
	{

		if(hastolerp)
		{
			if(parent.transform.position.x <= endposition.x)
			{
				hastolerp = false;
			}
			parent.transform.position = Vector3.Lerp(parent.transform.position, endposition, Time.deltaTime * 2);
		}
	}
	
	public void moveGround(GameObject p)
	{
		hastolerp = true;
		parent = p;
		endposition = parent.transform.position;
		endposition.x = parent.transform.position.x - 2;
	}
}
