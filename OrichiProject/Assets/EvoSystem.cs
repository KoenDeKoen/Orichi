using UnityEngine;
using System.Collections;
using Pillo;

public class EvoSystem : MonoBehaviour {


	public Transform prefab;
	public Animator m_ani;
	public Animator help;
	public Animator tutorial;
	private GameObject tempobj;
	public float points;
	public static int evolevel;
	public float HelpTime;
	public ScreenShake screenshaker;
	private bool hastoshake;
	public float progresspercentage;
	void Start()
	{
		hastoshake = false;
		tutorial.SetInteger("Grow",1);
		//Debug.Log (Custominput.exercises);
	}
	
	void Update () {
		points = MechanicController.stepstaken / Custominput.exercises;

		float pct = PilloController.GetSensor (Pillo.PilloID.Pillo1);
		float pct2 = PilloController.GetSensor (Pillo.PilloID.Pillo2);
		if(hastoshake)
		{
			hastoshake = screenshaker.shakeScreen();
		}

		if(progresspercentage > 0.333 && evolevel < 1)
		{
			evolevel = 1;
			m_ani.SetInteger("Evolve",1);
			Instantiate(prefab, new Vector3(0,-1.5F,-2), Quaternion.identity);
			hastoshake = true;
		}

		if(progresspercentage > 0.666 && evolevel < 2)
		{
			evolevel = 2;
			m_ani.SetInteger("Evolve",2);
			Instantiate(prefab, new Vector3(0,-1.5f,-2), Quaternion.identity);
			hastoshake = true;
		}

		if(progresspercentage == 1 && evolevel < 3)
		{
			evolevel = 3;
			m_ani.SetInteger("Evolve",3);
			Instantiate(prefab, new Vector3(0,-1.5f,-2), Quaternion.identity);
			hastoshake = true;
		}		
		/*switch(points)
		{
		case 0.33:
			// Transformation 1
			if(evolevel < 1)
			{
				evolevel = 1;
				m_ani.SetInteger("Evolve",1);
				Instantiate(prefab, new Vector3(0,-1.5F,-2), Quaternion.identity);
				hastoshake = true;
			}
			break;
		case 0.66:
			// Transformation 2
			if(evolevel < 2)
			{
				evolevel = 2;
				m_ani.SetInteger("Evolve",2);
				Instantiate(prefab, new Vector3(0,-1.5f,-2), Quaternion.identity);
				hastoshake = true;
			}
			break;
		case 1:
			// Transformation 3
			if(evolevel < 3)
			{
				evolevel = 3;
				m_ani.SetInteger("Evolve",3);
				Instantiate(prefab, new Vector3(0,-1.5f,-2), Quaternion.identity);
				hastoshake = true;
			}
			break;
		}*/

		/*
		none  = 0
		Left  = 1
		right = 2
		both  = 3
		*/
		HelpTime += Time.deltaTime;

		if(HelpTime >= 0f){
			//tg.SummonOldGuy();
 		}
		if(HelpTime >= 5f){
			help.SetInteger("HelpStep",1);
		}
		if(HelpTime >= 15f){
			help.SetInteger("HelpStep",2);
		}
		if(HelpTime >= 35f){
			help.SetInteger("HelpStep",3);
		}
		if(HelpTime >= 45f){
			help.SetInteger("HelpStep",4);
		}
		if(HelpTime >= 55f){
			help.SetInteger("HelpStep",5);
			tutorial.SetInteger("Grow",2);
		}

		if(Input.anyKey == false){
			help.SetInteger("MoveSet",0);
		}

	
		progresspercentage = MechanicController.stepstaken / Custominput.exercises;

		/*
		if(Input.GetKeyDown("a") || pct > 0.2 && pct2 == 0){
			help.SetInteger("MoveSet",1);
		}
		if(Input.GetKeyDown("l") || pct2 > 0.2 && pct == 0 ){
			help.SetInteger("MoveSet",2);
		}
		if(Input.GetKeyDown("a") && Input.GetKeyDown("l") || pct2 > 0.2 && pct2 > 0.2){
			help.SetInteger("MoveSet",3);
		}


		// Transformation 1
		if(points >= 20){
			if(evolevel < 1)
			{
				evolevel = 1;
				m_ani.SetInteger("Evolve",1);
				Instantiate(prefab, new Vector3(0,-1.5F,-5), Quaternion.identity);
			}
		}

		// Transformation 2
		if(points >= 40){
			if(evolevel < 2)
			{
				evolevel = 2;
				m_ani.SetInteger("Evolve",2);
				Instantiate(prefab, new Vector3(0,-1.5f,-2), Quaternion.identity);
			}
		}

		// Transformation 3
		if(points >= 60){
			if(evolevel < 3)
			{
				evolevel = 3;
				m_ani.SetInteger("Evolve",3);
				Instantiate(prefab, new Vector3(0,-1.5f,-2), Quaternion.identity);
			}
		}
		*/
	}
}