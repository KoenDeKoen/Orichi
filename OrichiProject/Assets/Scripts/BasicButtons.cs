using UnityEngine;
using System.Collections;

public class BasicButtons : MonoBehaviour 
{

	// Use this for initialization
	//public SceneLoader sceneloader;
	public bool ismenu;
	public Shutter shutter;
	public bool isstartscene;
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

			shutter.closeGameAfterClosing();
			//Application.Quit();
		}

		if(Input.GetKeyDown(KeyCode.Escape) && !ismenu)
		{
			EvoSystem.evolevel = 0;
			shutter.loadSceneAfterClosing("MainMenu");
			//sceneloader.loadScene("MainMenu");
		}

		if(Input.GetKeyDown(KeyCode.Space) && isstartscene)
		{
			shutter.loadSceneAfterClosing("Evolution");
		}
	}
}
