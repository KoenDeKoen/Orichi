﻿using UnityEngine;
using System.Collections;

public class Shutter : MonoBehaviour {

	// Use this for initialization
	public GameObject leftdoor;
	public GameObject rightdoor;
	private float timeclose;
	private float timeopen;
	private float time;
	private bool donelerpingopen;
	private bool donelerpingclose;
	private Vector3 leftdoorclosepos;
	private Vector3 rightdoorclosepos;
	private Vector3 leftdooropenpos;
	private Vector3 rightdooropenpos;
	private bool timerclosefinished;
	private bool timeropenfinished;
	private bool openandclosed;

	void Start () 
	{
		donelerpingclose = true;
		donelerpingopen = false;
		openandclosed = false;
		time = 0;
		timeclose = 1F;
		timeopen = 1F;
		leftdoorclosepos = new Vector3 (0 - leftdoor.GetComponent<SpriteRenderer>().bounds.extents.x * 3.56F, leftdoor.transform.localPosition.y, leftdoor.transform.localPosition.z);
		rightdoorclosepos = new Vector3 (0 + rightdoor.GetComponent<SpriteRenderer>().bounds.extents.x * 3.56F, rightdoor.transform.localPosition.y, rightdoor.transform.localPosition.z);
		leftdooropenpos = new Vector3 (-570, leftdoor.transform.localPosition.y, leftdoor.transform.localPosition.z);
		rightdooropenpos = new Vector3 (570, rightdoor.transform.localPosition.y, rightdoor.transform.localPosition.z);
		timerclosefinished = false;
		timeropenfinished = false;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (!openandclosed) 
		{
			countDownForOpenUp ();
			//Debug.Log("Closed =" + donelerpingclose + "    " + "Open =" + donelerpingopen);
			if (timeropenfinished && donelerpingclose) 
			{			
				checkForDoneLerpOpen (leftdoor.transform.localPosition, rightdoor.transform.localPosition);
				openDoors ();
			}
			if (donelerpingopen) 
			{
				timeopen = 1F;
				countDownForShutDown ();
			}
			if (timerclosefinished && donelerpingopen) 
			{
				checkForDoneLerpClose (leftdoor.transform.localPosition, rightdoor.transform.localPosition);
				shutDoors ();
				if(donelerpingclose)
				{
					openandclosed = true;
				}
			}
		}
	}

	private void shutLeftDoor()
	{
		leftdoor.transform.localPosition = Vector3.Lerp(leftdoor.transform.localPosition, leftdoorclosepos, Time.deltaTime * 3);
	}

	private void shutRightDoor()
	{
		rightdoor.transform.localPosition = Vector3.Lerp(rightdoor.transform.localPosition, rightdoorclosepos, Time.deltaTime * 3);
	}

	private void shutDoors()
	{
		shutLeftDoor ();
		shutRightDoor ();
	}

	private void checkForDoneLerpClose(Vector3 leftdoorpos, Vector3 rightdoorpos)
	{
		if(leftdoor.transform.localPosition.x >= leftdoorclosepos.x - 0.1F && rightdoor.transform.localPosition.x <= rightdoorclosepos.x + 0.1F)
		{
			donelerpingclose = true;
			donelerpingopen = false;
		}
	}

	private void checkForDoneLerpOpen(Vector3 leftdoorpos, Vector3 rightdoorpos)
	{
		if(leftdoor.transform.localPosition.x <= leftdooropenpos.x + 0.1F && rightdoor.transform.localPosition.x >= rightdooropenpos.x - 0.1F)
		{
			donelerpingopen = true;
			donelerpingclose = false;
		}
	}

	private void openLeftDoor()
	{
		leftdoor.transform.localPosition = Vector3.Lerp(leftdoor.transform.localPosition, leftdooropenpos, Time.deltaTime * 3);
	}
		
	private void openRightDoor()
	{
		rightdoor.transform.localPosition = Vector3.Lerp(rightdoor.transform.localPosition, rightdooropenpos, Time.deltaTime * 3);
	}

	private void openDoors()
	{
		openLeftDoor ();
		openRightDoor ();
	}

	private void countDownForShutDown()
	{
		//Debug.Log (timeclose);
		timeclose -= Time.deltaTime;
		if(timeclose <= 0)
		{
			timerclosefinished = true;
		}
	}

	private void countDownForOpenUp()
	{
		timeopen -= Time.deltaTime;
		if(timeopen <= 0)
		{
			timeropenfinished = true;
			time = Time.deltaTime;
		}
	}
}
