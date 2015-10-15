using UnityEngine;
using System.Collections;
using Pillo;

public class EvoSystemHiScore : MonoBehaviour {

	public ScreenShake screenshaker;
	public Animator blob;
	
	private bool hastoshake;
	public static int evolevel;
	public float points;
	public float progresspercentage;
	public Transform particle;
	public Transform prefab;
	
	void Start()
	{
		hastoshake = false;
	}
	
	void Update () {
		points = MechanicControllerHiScore.stepstaken / Custominput.exercises;
		
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
		progresspercentage = MechanicControllerHiScore.stepstaken / Custominput.exercises;
	}
}