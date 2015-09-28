using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CloudMovement : MonoBehaviour {

	// Use this for initialization
	Vector3 spawnpos = new Vector3 (0, 5, 0);
	private GameObject parent;
	public GameObject cloudprefab;
	private List<GameObject> clouds;
	//private float passedtime;
	private float countdown;
	private Vector3 endpos;

	void Start () 
	{
		countdown = 0F;
		clouds = new List<GameObject> ();
		createParentObject ();
		endpos = new Vector3 (-15F, parent.transform.position.y, parent.transform.position.z);
	}
	
	// Update is called once per frame
	void Update () 
	{
		timedSpawnCloud ();
		moveCloud ();
		checkForDespawn ();
	}

	private void createParentObject()
	{
		parent = new GameObject ();
		parent.transform.position = spawnpos;
	}

	private void spawnCloud()
	{
		Vector3 tempvector = new Vector3 (15, Random.Range (2.0F, 6.0F), 7); 
		GameObject cloud = Instantiate(cloudprefab,tempvector, Quaternion.identity) as GameObject;
		cloud.transform.parent = parent.transform;
		clouds.Add (cloud);
	}

	public void moveCloud()
	{
		endpos.x = parent.transform.position.x - 0.5F;
		parent.transform.position = Vector3.Lerp(parent.transform.position, endpos, Time.deltaTime * 2);
	}

	private void checkForDespawn()
	{
		for(int i = 0; i < clouds.Count; i++)
		{
			if (clouds[i].GetComponent<MeshRenderer>().bounds.max.x <= -15F) 
			{
				Destroy(clouds[i]);
				clouds.Remove(clouds[i]);
			}
		}
	}

	private void timedSpawnCloud()
	{
		countdown -= Time.deltaTime;
		if(countdown <= 0)
		{
			countdown = Random.Range(4,8);
			spawnCloud();
		}
	}
}
