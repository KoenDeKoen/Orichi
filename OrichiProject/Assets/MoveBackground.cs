using UnityEngine;
using System.Collections;

public class MoveBackground : MonoBehaviour {
	
	private GameObject slowParent;
	private GameObject fastParent;
	private Vector3 slowEndPos;
	private Vector3 fastEndPos;
	private bool fastlerping;
	private bool slowlerping;
	

	// Use this for initialization
	void Start () {
		slowEndPos = new Vector3(0, 0, 0);
		fastEndPos = new Vector3(0, 0, 0);
	}
	
	// Update is called once per frame
	void Update () {
		if(slowlerping)
		{
			if(slowParent.transform.position.x <= slowEndPos.x)
			{
				slowlerping = false;
			}
			slowParent.transform.position = Vector3.Lerp(slowParent.transform.position, slowEndPos, Time.deltaTime * 0.5f);
		}

		if(fastlerping)
		{
			if(fastParent.transform.position.x <= fastEndPos.x)
			{
				fastlerping = false;
			}
			fastParent.transform.position = Vector3.Lerp(fastParent.transform.position, fastEndPos, Time.deltaTime * 1.5f);
		}
	}

	public void moveFastMountain(GameObject p)
	{
		fastlerping = true;
		fastParent = p;
		fastEndPos = fastParent.transform.position;
		fastEndPos.x = fastParent.transform.position.x - 2;
	}

	public void moveSlowMountain(GameObject q)
	{
		slowlerping = true;
		slowParent = q;
		slowEndPos = slowParent.transform.position;
		slowEndPos.x = slowParent.transform.position.x - 2;
	}
}
