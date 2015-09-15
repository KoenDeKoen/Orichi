

using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using Pillo;

public class CreatureSelect : MonoBehaviour 
{

	// Use this for initialization
	private int creaturenumber;
	public Creatures creatures;
	public GameObject imageframe;
	public GameObject previousimageframe;
	public GameObject nextimageframe;
	private string defaultimageroute;
	private float temptime;

	void Start () 
	{

		defaultimageroute = "Images/";
		creaturenumber = 1;
		imageframe.GetComponent<Image> ().sprite = Resources.Load<Sprite> (defaultimageroute + creaturenumber.ToString());
		previousimageframe.GetComponent<Image>().sprite = Resources.Load<Sprite>(defaultimageroute + (creaturenumber-1).ToString());
		nextimageframe.GetComponent<Image>().sprite = Resources.Load<Sprite>(defaultimageroute + (creaturenumber+1).ToString());
	}
	
	// Update is called once per frame
	void Update () 
	{
		float accel = PilloController.GetAcceleroX (Pillo.PilloID.Pillo1);
		float pct = PilloController.GetSensor (Pillo.PilloID.Pillo1);
		
		if (pct > 0 || Input.GetKey ("space")) 
		{
			if(temptime == 0)
			{
				temptime = Time.time;
			}
			if((Time.time - temptime) >= 3){
				temptime = 0;
				Debug.Log("next level");
			}
		} 



		if(Input.GetKeyUp("space")){
			temptime = 0;
		}
	
	//	Debug.Log (accel);
		if (accel > 100 || Input.GetKey("space") && Input.GetKey("right")) {
			nextCreature();

		}
		if (accel < -100 ||Input.GetKey("space") && Input.GetKey("left")) {
			previousCreature();
			
		}

	}

	public void nextCreature()
	{
//		float pct = PilloController.GetSensor (Pillo.PilloID.Pillo1);
	//	float accel = PilloController.GetAcceleroX (Pillo.PilloID.Pillo1);

		if(creaturenumber < creatures.returnImageNames().Count)
		{
			creaturenumber++;
			imageframe.GetComponent<Image>().sprite = Resources.Load<Sprite>(defaultimageroute + creaturenumber.ToString());
			previousimageframe.GetComponent<Image>().sprite = Resources.Load<Sprite>(defaultimageroute + (creaturenumber-1).ToString());
			nextimageframe.GetComponent<Image>().sprite = Resources.Load<Sprite>(defaultimageroute + (creaturenumber+1).ToString());
			if(creaturenumber == creatures.returnImageNames().Count)
			{
				nextimageframe.GetComponent<Image>().sprite = Resources.Load<Sprite>(defaultimageroute + "0");
			}
		}
	}

	public void previousCreature()
	{
	

		if(creaturenumber > 1)
		{
			creaturenumber--;
			imageframe.GetComponent<Image>().sprite = Resources.Load<Sprite>(defaultimageroute + creaturenumber.ToString());
			previousimageframe.GetComponent<Image>().sprite = Resources.Load<Sprite>(defaultimageroute + (creaturenumber-1).ToString());
			nextimageframe.GetComponent<Image>().sprite = Resources.Load<Sprite>(defaultimageroute + (creaturenumber+1).ToString());
		}
	}
	// Use this for initialization



}
