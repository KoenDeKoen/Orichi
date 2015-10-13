using UnityEngine;
using System.Collections;
using Pillo;

public class EvoSystem : MonoBehaviour {
	
	private GameObject tempobj;
	public ScreenShake screenshaker;

	public Animator blob;
	public Animator help;
	public Animator tutorial;

	public AudioClip intro;
	public AudioClip pillo;
	public AudioClip test;
	public AudioClip instruction;
	public AudioClip succes;

	private bool hastoshake;
	public static int evolevel;
	public int tips;
	public float points;
	public float HelpTime;
	public float progresspercentage;
	public Transform particle;
	public Transform prefab;

	void Start()
	{
		tutorial.SetInteger("Grow",1);
		AudioSource.PlayClipAtPoint(intro, new Vector3(0,0,0));
		hastoshake = false;
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
			blob.SetInteger("Evolve",1);
			Instantiate(prefab, new Vector3(0,-1.5F,-2), Quaternion.identity);
			Instantiate(particle, new Vector3(0,-1.5F,0), Quaternion.identity);
			hastoshake = true;
		}

		if(progresspercentage > 0.666 && evolevel < 2)
		{
			evolevel = 2;
			blob.SetInteger("Evolve",2);
			Instantiate(prefab, new Vector3(0,-1.5f,-2), Quaternion.identity);
			Instantiate(particle, new Vector3(0,-1.5F,0), Quaternion.identity);
			hastoshake = true;
		}

		if(progresspercentage == 1 && evolevel < 3)
		{
			evolevel = 3;
			blob.SetInteger("Evolve",3);
			Instantiate(prefab, new Vector3(0,-1.5f,-2), Quaternion.identity);
			Instantiate(particle, new Vector3(0,-1.5F,0), Quaternion.identity);
			hastoshake = true;
		}		

		HelpTime += Time.deltaTime;

		//5.15.35.45.55

		if(HelpTime >= 11 && tips < 1){
			help.SetInteger("HelpStep",1);
			AudioSource.PlayClipAtPoint(pillo, new Vector3(0,0,0));
			tips = 1;
		}
		if(HelpTime >= 23 && tips < 2){
			help.SetInteger("HelpStep",2);
			AudioSource.PlayClipAtPoint(test, new Vector3(0,0,0));
			tips = 2;
		}
		if(HelpTime >= 40 && tips < 3){
			help.SetInteger("HelpStep",3);
			AudioSource.PlayClipAtPoint(instruction, new Vector3(0,0,0));
			tips = 3;
		}
		if(HelpTime >= 47){
			help.SetInteger("HelpStep",4);
		}
		if(HelpTime >= 51){
			help.SetInteger("HelpStep",5);
		}
		if(HelpTime >= 52 && tips < 4){
			AudioSource.PlayClipAtPoint(succes, new Vector3(0,0,0));
			tips = 4;
		}
		if(HelpTime >= 55){
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