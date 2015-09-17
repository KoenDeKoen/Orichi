using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpawnGroundAndProps : MonoBehaviour 
{

	private List<GameObject> floors;
	public Sprite floorsprite;
	Vector3 position;
	// Use this for initialization
	void Start () 
	{
		floors = new List<GameObject> ();
		position = new Vector3 (0, (float)-2.23, 0);
		spawnFloor (position);
	}
	
	// Update is called once per frame
	void Update () 
	{
		checkForNextSpawn ();
	}

	public void  spawnFloor(Vector3 spawnpos)
	{
		GameObject floor = new GameObject();
		floor.AddComponent<SpriteRenderer> ();
		floor.GetComponent<SpriteRenderer> ().sprite = floorsprite;
		Vector3 spawnposition = spawnpos;
		floor.transform.position = spawnposition;
		floors.Add (floor);
	}

	public void despawnFloor(GameObject floortodespawn)
	{
		floors.Remove (floortodespawn);
		Destroy (floortodespawn);
	}

	public void checkForNextSpawn()
	{
		Vector3 endofspriteposleft = new Vector3 (0, 0, 0);
		Vector3 endofspriteposright = new Vector3 (0, 0, 0);
		for(int i = 0; i < floors.Count; i++)
		{
			endofspriteposleft.x = floors[i].GetComponent<SpriteRenderer>().bounds.min.x;
			endofspriteposright.x = floors[i].GetComponent<SpriteRenderer>().bounds.max.x;
			if(endofspriteposright.x <= (float)9 && floors.Count < 2)
			{
				position.x = endofspriteposright.x + (floors[i].GetComponent<SpriteRenderer>().bounds.extents.x)-(float)+0.1;//+0.1 omdat LOGICS
				spawnFloor(position);

			}
			if(endofspriteposright.x <= (float)-9)
			{
				despawnFloor(floors[i]);
			}
		}
	}

	public List<GameObject> returnFloors()
	{
		return floors;
	}
}