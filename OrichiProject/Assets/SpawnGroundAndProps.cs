using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpawnGroundAndProps : MonoBehaviour 
{

	private List<GameObject> floors;
	private List<Vector3> decorationpawnpositions;
	public Sprite bushsprite;
	public Sprite floorsprite;
	//public Animator grasscontroller;
	public RuntimeAnimatorController grassRTController; 	
	Vector3 position;
	// Use this for initialization
	void Start () 
	{
		decorationpawnpositions = new List<Vector3> ();
		addSpawnableDecorationSpots ();
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
		placeGrass (floor);
		addSpawnableDecorationSpots ();
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
	
	public void placeGrass(GameObject parentground)
	{
		Vector3 position = new Vector3(parentground.transform.position.x,(float)-1.08,0);
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


	//WAS WORKING ON THIS DONT REMOVE!!!

	/*private List<GameObject> floors;
	private List<Vector3> decorationpawnpositions;
	public Sprite bushsprite;
	public Sprite floorsprite;
	private GameObject parentofall;
	private GameObject lastspawnedfloor;
	Vector3 position;
	// Use this for initialization
	void Start () 
	{
		lastspawnedfloor = new GameObject ();
		parentofall = new GameObject ();
		decorationpawnpositions = new List<Vector3> ();
		addSpawnableDecorationSpots ();
		floors = new List<GameObject> ();
		position = new Vector3 (0, (float)-2.23, 0);
		parentofall.transform.position = position;
		//spawnFloor (position);
	}
	
	 Update is called once per frame
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
		placeGrass (floor);
		addSpawnableDecorationSpots ();
		lastspawnedfloor = floor;
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
			endofspriteposright.x = lastspawnedfloor.GetComponent<SpriteRenderer>().bounds.max.x;
			if(endofspriteposright.x <= (float)9 && floors.Count < 2)
			{
				position.x = lastspawnedfloor.transform.localPosition.x + (lastspawnedfloor.GetComponent<SpriteRenderer>().bounds.extents.x);//+0.1 omdat LOGICS
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

	public void placeGrass(GameObject parentground)
	{
		Vector3 position = new Vector3(parentground.transform.position.x,(float)-1.08,0);
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
			grass.GetComponent<SpriteRenderer>().sortingOrder = 2;
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
		return parentofall;
	}*/
}