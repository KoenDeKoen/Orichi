using UnityEngine;
using System.Collections;

public class AbsolutelyNoEasterEggScript : MonoBehaviour 
{

	// Use this for initialization
	private string enteredstring;
	public GameObject thomasmusicplayer;
	public GameObject orichiplayer;

	void Start () 
	{
		enteredstring = "";
	}
	
	// Update is called once per frame
	void Update () 
	{
		checkForButtonPresses ();
		checkForWords ();
		Debug.Log(enteredstring);
	}


	private void checkForWords()
	{

		if(enteredstring == "thomas")
		{

			enteredstring = "";
			thomasmusicplayer.GetComponent<AudioSource>().Play();
			orichiplayer.GetComponent<AudioSource>().Pause();
		}
		if(enteredstring.Length == 6)
		{
			enteredstring = "";
		}
	}


	private void checkForButtonPresses()
	{
		if(Input.GetKeyDown("a"))
		{
			enteredstring += "a";
		}
		if(Input.GetKeyDown("b"))
		{
			enteredstring += "b";
		}
		if(Input.GetKeyDown("c"))
		{
			enteredstring += "c";
		}
		if(Input.GetKeyDown("d"))
		{
			enteredstring += "d";
		}
		if(Input.GetKeyDown("e"))
		{
			enteredstring += "e";
		}
		if(Input.GetKeyDown("f"))
		{
			enteredstring += "f";
		}
		if(Input.GetKeyDown("g"))
		{
			enteredstring += "g";
		}
		if(Input.GetKeyDown("h"))
		{
			enteredstring += "h";
		}
		if(Input.GetKeyDown("i"))
		{
			enteredstring += "i";
		}
		if(Input.GetKeyDown("j"))
		{
			enteredstring += "j";
		}
		if(Input.GetKeyDown("k"))
		{
			enteredstring += "k";
		}
		if(Input.GetKeyDown("l"))
		{
			enteredstring += "l";
		}
		if(Input.GetKeyDown("m"))
		{
			enteredstring += "m";
		}
		if(Input.GetKeyDown("n"))
		{
			enteredstring += "n";
		}
		if(Input.GetKeyDown("o"))
		{
			enteredstring += "o";
		}
		if(Input.GetKeyDown("p"))
		{
			enteredstring += "p";
		}
		if(Input.GetKeyDown("q"))
		{
			enteredstring += "q";
		}
		if(Input.GetKeyDown("r"))
		{
			enteredstring += "r";
		}
		if(Input.GetKeyDown("s"))
		{
			enteredstring += "s";
		}
		if(Input.GetKeyDown("t"))
		{
			enteredstring += "t";
		}
		if(Input.GetKeyDown("u"))
		{
			enteredstring += "u";
		}
		if(Input.GetKeyDown("v"))
		{
			enteredstring += "v";
		}
		if(Input.GetKeyDown("w"))
		{
			enteredstring += "w";
		}
		if(Input.GetKeyDown("x"))
		{
			enteredstring += "x";
		}
		if(Input.GetKeyDown("y"))
		{
			enteredstring += "y";
		}
		if(Input.GetKeyDown("z"))
		{
			enteredstring += "z";
		}
	}
}
