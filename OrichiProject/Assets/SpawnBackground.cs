using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpawnBackground : MonoBehaviour {

	private List<GameObject> fastMountains;
	private List<GameObject> slowMountains;
	private GameObject fastParent;
	private GameObject slowParent;
	private GameObject lastslowmountain;
	private GameObject lastfastmountain;
	private GameObject slowMountain;
	private GameObject fastMountain;
	public Sprite fastMountainsprite;
	public Sprite slowMountainsprite;


	// Use this for initialization
	void Start () {
		fastMountains = new List<GameObject> ();
		slowMountains = new List<GameObject> ();

		Vector3 spawnposfastMountain = new Vector3 (0, -3.25f, 15f);
		Vector3 spawnposslowMountain = new Vector3 (0, -2.25f, 17f);

		fastParent = new GameObject ();
		slowParent = new GameObject ();

		fastParent.transform.position = spawnposfastMountain;
		slowParent.transform.position = spawnposslowMountain;

		fastParent.name = "FastParent";
		slowParent.name = "SlowParent";

		spawnFastMountain (fastParent.transform.position);
		spawnSlowMountain (slowParent.transform.position);
	}
	
	// Update is called once per frame
	void Update () {
		checkForNextFastMountain();
		checkForNextSlowMountain();

	}

	public void  spawnSlowMountain(Vector3 spawnpos)
	{
		GameObject Smountain = new GameObject();
		Smountain.AddComponent<SpriteRenderer> ();
		Smountain.GetComponent<SpriteRenderer> ().sprite = slowMountainsprite;
		Vector3 SMspawnposition = spawnpos;
		Smountain.transform.position = SMspawnposition;
		lastslowmountain = Smountain;
		Smountain.transform.SetParent (slowParent.transform);
		slowMountains.Add (Smountain);
		Smountain.name = "Slow";
		Smountain.GetComponent<SpriteRenderer> ().sortingOrder = -1;
	}

	public void  spawnFastMountain(Vector3 spawnpos)
	{
		GameObject Fmountain = new GameObject();
		Fmountain.AddComponent<SpriteRenderer> ();
		Fmountain.GetComponent<SpriteRenderer> ().sprite = fastMountainsprite;
		Vector3 FMspawnposition = spawnpos;
		Fmountain.transform.position = FMspawnposition;
		lastfastmountain = Fmountain;
		Fmountain.transform.SetParent (fastParent.transform);
		fastMountains.Add (Fmountain);
		Fmountain.name = "Fast";
		Fmountain.GetComponent<SpriteRenderer> ().sortingOrder = 0;
	}


	public void despawnFMountain(GameObject despawn)
	{
		Destroy (despawn);
		fastMountains.Remove (despawn);
	}

	public void despawnSMountain(GameObject despawn)
	{
		Destroy (despawn);
		slowMountains.Remove (despawn);
	}


	public void checkForNextFastMountain()
	{
		Vector3 fMountainEdgeRight = new Vector3 (0, 0, 0);
		for(int i = 0; i < fastMountains.Count; i++)
		{
			fMountainEdgeRight.x = fastMountains[i].GetComponent<SpriteRenderer>().bounds.max.x;
			if(fMountainEdgeRight.x <= (float)-22)
			{
				despawnFMountain(fastMountains[i]);
			}
		}
		
		if (lastfastmountain.GetComponent<SpriteRenderer>().bounds.max.x <= (float)22) 
		{
			Vector3 tempvector = lastfastmountain.transform.position;
			tempvector.x = lastfastmountain.GetComponent<SpriteRenderer>().bounds.max.x + (lastfastmountain.GetComponent<SpriteRenderer> ().bounds.extents.x - (float)0.05);
			spawnFastMountain (tempvector);
		}
	}

	public void checkForNextSlowMountain()
	{
		Vector3 sMountainEdgeRight = new Vector3 (0, 0, 0);
		for(int i = 0; i < slowMountains.Count; i++)
		{
			sMountainEdgeRight.x = slowMountains[i].GetComponent<SpriteRenderer>().bounds.max.x;
			if(sMountainEdgeRight.x <= (float)-22)
			{
				despawnSMountain(slowMountains[i]);
			}
		}
		
		if (lastslowmountain.GetComponent<SpriteRenderer>().bounds.max.x <= (float)22) 
		{
			Vector3 tempvector = lastslowmountain.transform.position;
			tempvector.x = lastslowmountain.GetComponent<SpriteRenderer>().bounds.max.x + (lastslowmountain.GetComponent<SpriteRenderer> ().bounds.extents.x - (float)0.05);
			spawnSlowMountain (tempvector);
		}
	}

	public List<GameObject> getParents()
	{
		List<GameObject> parents = new List<GameObject>();
		parents.Add(fastParent);
		parents.Add(slowParent);
		return parents;
	}



}
