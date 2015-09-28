using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpawnGroundAndProps : MonoBehaviour {

	// Use this for initialization
	private List<GameObject> floors;
	private GameObject parent;
	private GameObject lastspawnedfloor;
	//public Sprite bushsprite;
	public Sprite floorsprite;
	private List<Vector3> decorationspawn2dpositions;
	private List<Vector3> decorationspawn3dpositions;
	public RuntimeAnimatorController grassRTController; 
	public Obj2D obj2d;
	public Obj3D obj3d;

	void Start () 
	{
		obj2d.Initialise ();
		obj3d.Initialise ();
		floors = new List<GameObject> ();
		Vector3 spawnpos = new Vector3 (0, -4, 0);
		parent = new GameObject ();
		parent.transform.position = spawnpos;

		decorationspawn2dpositions = new List<Vector3> ();
		decorationspawn3dpositions = new List<Vector3> ();
		addSpawnable2DDecorationSpots ();
		addSpawnable3DDecorationSpots ();

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
		placeSprites (floor);
		placeObjects (floor);
		addSpawnable2DDecorationSpots ();
		addSpawnable3DDecorationSpots ();
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

	public void placeSprites(GameObject parentground)
	{
		Vector3 position = new Vector3(parentground.transform.position.x,parentground.transform.position.y + (float)0.95,0);
		Vector3 positiontoremove = new Vector3 (0, 0, 0);
		
		for(int i = 0; i < Random.Range(3,6); i++)
		{
			int spritenumber = 0;
			spritenumber = Random.Range(0, obj2d.returnSprites().Count);
			GameObject sprite = new GameObject();
			sprite.AddComponent<SpriteRenderer>();
			sprite.GetComponent<SpriteRenderer>().sprite = obj2d.returnSprites()[spritenumber];
			positiontoremove = decorationspawn2dpositions[Random.Range(0,decorationspawn2dpositions.Count)];
			position.x += positiontoremove.x;
			decorationspawn2dpositions.Remove(positiontoremove);
			sprite.transform.parent = parentground.transform;
			sprite.transform.position = position;
			Vector3 tempscale = new Vector3(0.5F,0.5F,0.5F);
			sprite.transform.localScale = tempscale;
			sprite.GetComponent<SpriteRenderer>().sortingOrder = 1;
			sprite.AddComponent<Animator>();
			sprite.GetComponent<Animator>().runtimeAnimatorController = obj2d.returnControllers()[spritenumber];
		}
	}

	public void placeObjects(GameObject parentground)
	{
		Vector3 position = new Vector3(parentground.transform.position.x,parentground.transform.position.y + (float)0.2, parentground.transform.position.z + 2);
		Vector3 positiontoremove = new Vector3 (0, 0, 0);
		
		for(int i = 0; i < Random.Range(3,6); i++)
		{
			int objectnumber = 0;
			objectnumber = Random.Range(0, obj3d.returnObjects().Count);
			positiontoremove = decorationspawn3dpositions[Random.Range(0,decorationspawn3dpositions.Count)];
			position.x += positiontoremove.x;
			decorationspawn3dpositions.Remove(positiontoremove);
			GameObject object3d = Instantiate(obj3d.returnObjects()[objectnumber],position, Quaternion.identity) as GameObject;
			object3d.transform.parent = parentground.transform;
			//object3d.AddComponent<Animator>();
			//object3d.GetComponent<Animator>().runtimeAnimatorController = obj3d.returnControllers()[objectnumber];
		}
	}
	
	public void addSpawnable2DDecorationSpots()
	{
		Vector3 spot = new Vector3 (0, (float)-2.23, 0);
		for(int i = -5; i < 5; i += 2)
		{
			spot.x = i;
			decorationspawn2dpositions.Add (spot);
		}	
	}

	public void addSpawnable3DDecorationSpots()
	{
		Vector3 spot = new Vector3 (0, (float)-4.7, 0);
		for(int i = -5; i < 5; i += 2)
		{
			spot.x = i;
			decorationspawn3dpositions.Add (spot);
		}	
	}
	
	public GameObject getParent()
	{
		return parent;
	}


}
