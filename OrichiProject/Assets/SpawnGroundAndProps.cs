using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpawnGroundAndProps : MonoBehaviour {

	// Use this for initialization
	private List<GameObject> floors;
	private GameObject parent;
	private GameObject lastspawnedfloor;
	public Sprite floorsprite;
	private List<Vector3> decorationspawn2dpositions;
	private List<Vector3> decorationspawn3dpositions;
	private List<Vector3> tree3dspots;
	public Obj2D obj2d;
	public Obj3D obj3d;
	public Trees3D trees;

	public Sprite femaleSprite;
	public RuntimeAnimatorController movingFemale;
	public bool arrive;
	public MechanicController mc;
	public ParticleTrigger pt;
	public GameObject player;
	private GameObject female;
	public float time = 5f;
	private bool particleswitch;

	void Start () 
	{
		female = null;
		decorationspawn2dpositions = new List<Vector3> ();
		decorationspawn3dpositions = new List<Vector3> ();
		tree3dspots = new List<Vector3> ();
		trees.Initialise ();
		obj2d.Initialise ();
		obj3d.Initialise ();
		floors = new List<GameObject> ();
		Vector3 spawnpos = new Vector3 (0, -4, 0);
		parent = new GameObject ();
		parent.transform.position = spawnpos;
		parent.name = "GroundParent";
		spawnFloor (parent.transform.position);
		arrive = false;
		particleswitch = true;
	}
	
	// Update is called once per frame
	void Update () 
	{
		checkForNextSpawn ();
		CheckFemale();
	}

	public void  spawnFloor(Vector3 spawnpos)
	{
		GameObject floor = new GameObject();
		floor.AddComponent<SpriteRenderer> ();
		floor.GetComponent<SpriteRenderer> ().sprite = floorsprite;
		Vector3 spawnposition = spawnpos;
		floor.transform.position = spawnposition;
		addSpawnable2DDecorationSpots ();
		addSpawnable3DDecorationSpots ();
		addSpawnableTree3DSpots ();
		placeSprites (floor);
		placeObjects (floor);
		placeTrees (floor);
		if(arrive){
			placeFemale (floor);
		}
		lastspawnedfloor = floor;
		floor.transform.SetParent (parent.transform);
		floors.Add (floor);
		floor.name = "Ground";
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
		Vector3 position = new Vector3(parentground.transform.position.x,parentground.transform.position.y + (float)4.9,0);
		Vector3 positiontoremove = new Vector3 (0, 0, 0);
		int amountofprops = Random.Range (3, decorationspawn2dpositions.Count);
		
		for(int i = 0; i < amountofprops; i++)
		{
			int spritenumber = 0;
			spritenumber = Random.Range(0, obj2d.returnSprites().Count);
			GameObject sprite = new GameObject();
			sprite.AddComponent<SpriteRenderer>();
			sprite.GetComponent<SpriteRenderer>().sprite = obj2d.returnSprites()[spritenumber];
			positiontoremove = decorationspawn2dpositions[Random.Range(0,decorationspawn2dpositions.Count)];
			position.x = positiontoremove.x;
			sprite.name = position.x.ToString();
			decorationspawn2dpositions.Remove(positiontoremove);
			sprite.transform.parent = parentground.transform;
			sprite.transform.localPosition = position;
			Vector3 tempscale = new Vector3(0.5F,0.5F,0.5F);
			sprite.GetComponent<SpriteRenderer>().sortingOrder = 1;
			if(spritenumber == 6)
			{
				sprite.GetComponent<SpriteRenderer>().sortingOrder = -1;
				tempscale = new Vector3(0.2F,0.2F,0.2F);
				int value = Random.Range(1,3);
				Debug.Log(value);
				if(value == 1)
				{
					sprite.transform.rotation = Quaternion.Euler(0,0,0);

				}
				if(value == 2)
				{
					sprite.transform.rotation = Quaternion.Euler(0,-180,0);
				}
			}

			if(spritenumber >= 7)
			{
				sprite.transform.position = new Vector3(sprite.transform.position.x, sprite.transform.position.y + 0.26F, sprite.transform.position.z);
			}
			sprite.transform.localScale = tempscale;

			if(obj2d.returnControllers()[spritenumber] != null)
			{
				sprite.AddComponent<Animator>();
				sprite.GetComponent<Animator>().runtimeAnimatorController = obj2d.returnControllers()[spritenumber];
			}
		}
	}
	//////////////////////////
	public void placeFemale(GameObject parentground)
	{
		Vector3 position = new Vector3(0F,(float)0.748,0);
		GameObject sprite = new GameObject();
		sprite.AddComponent<SpriteRenderer>();
		sprite.GetComponent<SpriteRenderer>().sprite = femaleSprite;
		sprite.AddComponent<Animator>();
		sprite.GetComponent<Animator>().runtimeAnimatorController = movingFemale;
		sprite.name = "Female";
		sprite.transform.parent = parentground.transform;
		sprite.transform.localPosition = position;
		arrive = false;
		female = sprite;
	}
	//////////////////////////

	public void CheckFemale() {
		if(female != null && female.transform.position.x <= 5.2f){
			mc.done = true;
			if(particleswitch){
				pt.Heartsparticle(female);
				pt.Heartsparticle(player);
				particleswitch = false;
			}
			time -= Time.deltaTime;
		}
	}

	public void placeObjects(GameObject parentground)
	{
		Vector3 position = new Vector3(parentground.transform.position.x,parentground.transform.position.y + (float)4.2, parentground.transform.position.z + 2);
		Vector3 positiontoremove = new Vector3 (0, 0, 0);
		int amountofprops = Random.Range (3,decorationspawn3dpositions.Count);
		
		for(int i = 0; i < amountofprops; i++)
		{
			int objectnumber = 0;
			objectnumber = Random.Range(0, obj3d.returnObjects().Count);
			positiontoremove = decorationspawn3dpositions[Random.Range(0,decorationspawn3dpositions.Count)];
			position.x = positiontoremove.x;
			decorationspawn3dpositions.Remove(positiontoremove);
			GameObject object3d = Instantiate(obj3d.returnObjects()[objectnumber],position, Quaternion.identity) as GameObject;
			object3d.transform.parent = parentground.transform;
			object3d.transform.localPosition = position;
		}
	}

	public void placeTrees(GameObject parentground)
	{
		Vector3 position = new Vector3(parentground.transform.position.x,parentground.transform.position.y + (float)4.2, parentground.transform.position.z + 2);
		Vector3 positiontoremove = new Vector3 (0, 0, 0);
		int amountofprops = Random.Range (2, tree3dspots.Count);

		for(int i = 0; i < amountofprops; i++)
		{
			int objectnumber = 0;
			objectnumber = Random.Range(0, trees.returnObjects().Count);
			positiontoremove = tree3dspots[Random.Range(0,tree3dspots.Count)];
			position.x = positiontoremove.x;
			tree3dspots.Remove(positiontoremove);
			GameObject tree = Instantiate(trees.returnObjects()[objectnumber],position, Quaternion.identity) as GameObject;
			tree.transform.parent = parentground.transform;
			tree.transform.localPosition = position;

		}
	}

	public void addSpawnable2DDecorationSpots()
	{
		decorationspawn2dpositions = new List<Vector3> ();
		Vector3 spot = new Vector3 (0, 0, 0);
		for(int i = -5; i <= 5; i += 2)
		{
			spot.x = i;
			decorationspawn2dpositions.Add (spot);
		}	
	}

	public void addSpawnable3DDecorationSpots()
	{
		decorationspawn3dpositions = new List<Vector3> ();
		Vector3 spot = new Vector3 (0, 0, 0);
		for(int i = -5; i <= 5; i += 2)
		{
			spot.x = i;
			decorationspawn3dpositions.Add (spot);
		}	
	}

	public void addSpawnableTree3DSpots()
	{
		tree3dspots = new List<Vector3> ();
		Vector3 spot = new Vector3 (0, 0, 0);
		for(int i = -8; i <= 8; i += 4)
		{
			spot.x = i;
			tree3dspots.Add (spot);
		}	
	}
	
	public GameObject getParent()
	{
		return parent;
	}
}
