using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpawnGroundAndProps : MonoBehaviour {

	// Use this for initialization
	private List<GameObject> floors;
	private GameObject parent;
	private GameObject lastspawnedfloor;
	public Sprite bushsprite;
	public Sprite floorsprite;
	private List<Vector3> decorationpawnpositions;
	public RuntimeAnimatorController grassRTController; 

	void Start () 
	{
		floors = new List<GameObject> ();
		Vector3 spawnpos = new Vector3 (0, -4, 0);
		parent = new GameObject ();
		parent.transform.position = spawnpos;

		decorationpawnpositions = new List<Vector3> ();
		addSpawnableDecorationSpots ();

		//UGLY FIRST SPAWN
		spawnFloor (parent.transform.position);
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
		placeGrass (floor);
		addSpawnableDecorationSpots ();
		lastspawnedfloor = floor;
		floor.transform.SetParent (parent.transform);
		floors.Add (floor);
	}

	public void despawnFloor(GameObject floortodespawn)
	{
		Destroy (floortodespawn);
		floors.Remove (floortodespawn);
	}
	
	public void checkForNextSpawn()
	{
		Vector3 endofspriteposright = new Vector3 (0, 0, 0);
		for(int i = 0; i < floors.Count; i++)
		{
			endofspriteposright.x = floors[i].GetComponent<SpriteRenderer>().bounds.max.x;
			if(endofspriteposright.x <= (float)-9)
			{
				despawnFloor(floors[i]);
			}
		}

		if (lastspawnedfloor.GetComponent<SpriteRenderer>().bounds.max.x <= (float)9) 
		{
			Vector3 tempvector = lastspawnedfloor.transform.position;
			tempvector.x = lastspawnedfloor.GetComponent<SpriteRenderer>().bounds.max.x + (lastspawnedfloor.GetComponent<SpriteRenderer> ().bounds.extents.x - (float)0.05);
			spawnFloor (tempvector);
		}
	}
	
	public void placeGrass(GameObject parentground)
	{
		Vector3 position = new Vector3(parentground.transform.position.x,parentground.transform.position.y + (float)0.95,0);
		Vector3 positiontoremove = new Vector3 (0, 0, 0);
		
		for(int i = 0; i < Random.Range(3,6); i++)
		{
			GameObject grass = new GameObject();
			grass.AddComponent<SpriteRenderer>();
			grass.GetComponent<SpriteRenderer>().sprite = bushsprite;
			positiontoremove = decorationpawnpositions[Random.Range(0,decorationpawnpositions.Count)];
			position.x += positiontoremove.x;
			decorationpawnpositions.Remove(positiontoremove);
			grass.transform.parent = parentground.transform;
			grass.transform.position = position;
			Vector3 tempscale = new Vector3(0.5F,0.5F,0.5F);
			grass.transform.localScale = tempscale;
			grass.GetComponent<SpriteRenderer>().sortingOrder = 1;
			grass.AddComponent<Animator>();
			grass.GetComponent<Animator>().runtimeAnimatorController = grassRTController;
		}
	}
	
	public void addSpawnableDecorationSpots()
	{
		Vector3 spot = new Vector3 (0, (float)-2.23, 0);
		for(int i = -5; i < 5; i += 2)
		{
			spot.x = i;
			decorationpawnpositions.Add (spot);
		}	
	}
	
	public GameObject getParent()
	{
		return parent;
	}


}
