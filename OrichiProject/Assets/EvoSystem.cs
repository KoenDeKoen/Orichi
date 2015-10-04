using UnityEngine;
using System.Collections;
using Pillo;

public class EvoSystem : MonoBehaviour {


	public Transform prefab;
	public Animator m_ani;
	public Animator help;
	public TutorialGuy tg;
	private GameObject tempobj;
	public int points;
	int evolevel;
	public float HelpTime;

	void Update () {
		points = MechanicController.stepstaken;

		switch(points)
		{
		case 20:
			// Transformation 1
			if(evolevel < 1)
			{
				evolevel = 1;
				m_ani.SetInteger("Evolve",1);
				Instantiate(prefab, new Vector3(0,-1.5F,-2), Quaternion.identity);
			}
			break;
		case 40:
			// Transformation 2
			if(evolevel < 2)
			{
				evolevel = 2;
				m_ani.SetInteger("Evolve",2);
				Instantiate(prefab, new Vector3(0,-1.5f,-2), Quaternion.identity);
			}
			break;
		case 60:
			// Transformation 3
			if(evolevel < 3)
			{
				evolevel = 3;
				m_ani.SetInteger("Evolve",3);
				Instantiate(prefab, new Vector3(0,-1.5f,-2), Quaternion.identity);
			}
			break;
		}

		/*
		none  = 0
		Left  = 1
		right = 2
		both  = 3
		*/
		HelpTime += Time.deltaTime;

		if(HelpTime >= 0f){
			tg.SummonOldGuy();
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
			tg.DispelOldGuy();
		}

		float pct = PilloController.GetSensor (Pillo.PilloID.Pillo1);
		float pct2 = PilloController.GetSensor (Pillo.PilloID.Pillo2);

		if(Input.GetKeyDown("a") || pct > 0.2 && pct2 == 0){
			help.SetInteger("MoveSet",1);
		}
		if(Input.GetKeyDown("l") || pct2 > 0.2 && pct == 0 ){
			help.SetInteger("MoveSet",2);
		}
		if(Input.GetKeyDown("a") && Input.GetKeyDown("l") || pct2 > 0.2 && pct2 > 0.2){
			help.SetInteger("MoveSet",3);
		}
		if(Input.anyKey == false){
			help.SetInteger("MoveSet",0);
		}
		/*
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