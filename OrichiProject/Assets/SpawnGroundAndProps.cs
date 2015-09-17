using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpawnGroundAndProps : MonoBehaviour 
{

	private List<GameObject> floors;
	public Sprite floorsprite;
	// Use this for initialization
	void Start () 
	{
		spawnFloor ();
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	public void  spawnFloor()
	{
		GameObject floor = new GameObject();
		floor.AddComponent<SpriteRenderer> ();
		floor.GetComponent<SpriteRenderer> ().sprite = floorsprite;
		Vector3 spawnposition = new Vector3 (0, (float)-2.23, 0);
		floor.transform.position = spawnposition;
	}

	public void checkForNextSpawn()
	{
		foreach(GameObject g in floors)
		{

		}
	}
}
