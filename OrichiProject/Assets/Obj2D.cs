using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Obj2D : MonoBehaviour {

	// Use this for initialization
	public Sprite grass1;
	public RuntimeAnimatorController grass1RT;
	public Sprite grass2;
	public RuntimeAnimatorController grass2RT;
	public Sprite grass3;
	public RuntimeAnimatorController grass3RT;
	public Sprite bush1;
	public RuntimeAnimatorController bush1RT;
	public Sprite bush2;
	public RuntimeAnimatorController bush2RT;
	public Sprite bush3;
	public RuntimeAnimatorController bush3RT;
	private List<Sprite> sprites;
	private List<RuntimeAnimatorController> controllers;

	public void Initialise () 
	{
		sprites = new List<Sprite> ();
		controllers = new List<RuntimeAnimatorController> ();
		sprites.Add (grass1);
		controllers.Add (grass1RT);
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	public List<Sprite> returnSprites()
	{
		return sprites;
	}

	public List<RuntimeAnimatorController> returnControllers()
	{
		return controllers;
	}


}
