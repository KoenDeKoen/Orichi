using UnityEngine;
using System.Collections;

public class MoveGroundAndDespawn : MonoBehaviour {

	// Use this for initialization
	public GameObject floorandshizzle;
	//private float pct1;
	//private float pct2;

	void Start () 
	{
		//pct1 = PilloController.GetSensor (Pillo.PilloID.Pillo1);
		//pct2 = PilloController.GetSensor (Pillo.PilloID.Pillo1);
	}
	
	// Update is called once per frame
	void Update () 
	{
		moveGround ();
		checkForDespawn ();
		Debug.Log (floorandshizzle.transform.position.x + floorandshizzle.transform.localScale.x / 2);
	}

	public void moveGround()
	{
		if(Input.GetKeyDown("a"))
		{
			Vector3 tempvector;
			tempvector.y = floorandshizzle.transform.position.y;
			tempvector.z = floorandshizzle.transform.position.z;
			tempvector.x = floorandshizzle.transform.position.x - 5;

			floorandshizzle.transform.position = Vector3.MoveTowards(floorandshizzle.transform.position, tempvector, Time.deltaTime * 5);
		}
	}

	public void checkForDespawn()
	{
		if((floorandshizzle.transform.position.x + floorandshizzle.GetComponent<SpriteRenderer>().bounds.extents.x) < 0)
		{
			Destroy(floorandshizzle);

		}
	}
}
