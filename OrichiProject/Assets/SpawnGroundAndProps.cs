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

	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	public void  spawnFloor()
	{
		GameObject floor;
		floor.AddComponent<SpriteRenderer> ();
		floor.GetComponent<SpriteRenderer> ().sprite = floor;

	}
}
