using UnityEngine;
using System.Collections;

public class MoveGround : MonoBehaviour {

	// Use this for initialization
	//public GameObject floorandshizzle;
	public SpawnGroundAndProps spawngroundandprops;
	void Start () 
	{

	}
	
	// Update is called once per frame
	void Update () 
	{
		//moveGround ();
		//Debug.Log (floorandshizzle.transform.position.x + floorandshizzle.transform.localScale.x / 2);
	}

	public void moveGround()
	{
		for(int i = 0; i < spawngroundandprops.returnFloors().Count; i++)
		{
			Vector3 tempvector;
			tempvector.y = spawngroundandprops.returnFloors()[i].transform.position.y;
			tempvector.z = spawngroundandprops.returnFloors()[i].transform.position.z;
			tempvector.x = spawngroundandprops.returnFloors()[i].transform.position.x - 5;
			spawngroundandprops.returnFloors()[i].transform.position = Vector3.MoveTowards(spawngroundandprops.returnFloors()[i].transform.position, tempvector, Time.deltaTime * 10);
		}

	}
}
