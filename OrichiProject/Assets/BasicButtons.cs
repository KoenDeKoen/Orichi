using UnityEngine;
using System.Collections;

public class BasicButtons : MonoBehaviour 
{

	// Use this for initialization
	public SceneLoader sceneloader;
	public bool ismenu;
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		checkForButtonPresses ();
	}

	private void checkForButtonPresses()
	{
		if(Input.GetKeyDown("q"))
		{
			MechanicController.stepstaken = 0;
			Application.Quit();
		}

		if(Input.GetKeyDown(KeyCode.Escape) && !ismenu)
		{
			MechanicController.stepstaken = 0;
			sceneloader.loadScene("MainMenu");
		}
	}
}
