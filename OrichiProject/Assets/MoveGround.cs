using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MoveGround : MonoBehaviour {

	// Use this for initialization
	//public GameObject floorandshizzle;
	//public SpawnGroundAndProps spawngroundandprops;
	private bool hastolerp;
	private GameObject parent;
	/*private List<float> endpositions;*/
	/*private int currentground;*/
	//private Vector3 position;
	private Vector3 position;
	void Start () 
	{
		position = new Vector3 (0, 0, 0);
		/*endpositions = new List<float> ();
		endpositions.Add (0);
		endpositions.Add (0);
		position = new Vector3 (0, 0, 0);*/
		/*hastolerp = false;
		currentground = 0;
		position = new Vector3 (0, 0, 0);*/
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(hastolerp)
		{
			parent.transform.position = Vector3.MoveTowards(parent.transform.position.x, position.x, Time.deltaTime * 2f);
		}

		if(parent.transform.position.x <= position.x)
		{
			hastolerp = false;
		}
		//if pos < targetpos
			//moveground1
			//moveground2
		/*if(hastolerp)
		{
			//lerpPls(currentground, position);
			position.x = endpositions[0];
			spawngroundandprops.returnFloors()[0].transform.position = Vector3.MoveTowards(spawngroundandprops.returnFloors()[0].transform.position, position, Time.deltaTime * (float)2);
			if(spawngroundandprops.returnFloors().Count == 2)
			{
				position.x = endpositions[1];
				spawngroundandprops.returnFloors()[1].transform.position = Vector3.MoveTowards(spawngroundandprops.returnFloors()[1].transform.position, position, Time.deltaTime * (float)2);
			}

			if(spawngroundandprops.returnFloors()[0].transform.position.x <= endpositions[0])
			{
				if(spawngroundandprops.returnFloors().Count == 2)
				{
					if(spawngroundandprops.returnFloors()[1].transform.position.x <= endpositions[1] && spawngroundandprops.returnFloors()[1].transform.position.x <= endpositions[1])
					{
						hastolerp = false;
					}
				}
				else
				{
					hastolerp = false;
				}
			}
		}*/
		//moveGround ();
		//Debug.Log (floorandshizzle.transform.position.x + floorandshizzle.transform.localScale.x / 2);
	}

	/*public void moveGround()
	{
		hastolerp = true;
		for(int i = 0; i < spawngroundandprops.returnFloors().Count; i++)
		{
			Vector3 tempvector;
			endpositions[i] = 
			//currentground = i;
			position.y = spawngroundandprops.returnFloors()[i].transform.position.y;
			position.z = spawngroundandprops.returnFloors()[i].transform.position.z;
			endpositions[i] = spawngroundandprops.returnFloors()[i].transform.position.x - 1;

			//hastolerp = true;
		}

	}*/

	public void moveGround(GameObject p)
	{
		hastolerp = true;
		parent = p;
		position.z = parent.transform.position.z;
		position.y = parent.transform.position.y;
		position.x = parent.transform.position.x - 1;
	}


	/*public void lerpPls(int i, Vector3 vectorke)
	{
		spawngroundandprops.returnFloors()[i].transform.position = Vector3.MoveTowards(spawngroundandprops.returnFloors()[i].transform.position, vectorke, Time.deltaTime * (float)2);
	}*/

}
