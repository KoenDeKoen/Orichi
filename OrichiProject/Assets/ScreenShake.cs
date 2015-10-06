using UnityEngine;
using System.Collections;

public class ScreenShake : MonoBehaviour {

	// Use this for initialization
	public GameObject spasmcamera;
	private Vector3 startpos;
	private Vector3 rightpos;
	private Vector3 leftpos;
	private float time;

	void Start () 
	{
		startpos = spasmcamera.transform.position;
		rightpos = spasmcamera.transform.position;
		leftpos = spasmcamera.transform.position;
		rightpos.x += 0.1F;
		leftpos.x -= 0.1F;
		time = 1F;;
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	private void shakeScreenRight()
	{
		spasmcamera.transform.position = rightpos;
	}

	private void shakeScreenLeft()
	{
		spasmcamera.transform.position = leftpos;
	}

	private void shakeScreenMid()
	{
		spasmcamera.transform.position = startpos;
	}

	public bool shakeScreen()
	{
		//FOOKIN UGLY
		time -= Time.deltaTime;
		if(time < 0.05F)
		{
			shakeScreenMid ();
			time = 1F;
			Debug.Log ("1");
			return false;
		}

		else if(time < 0.1F)
		{
			shakeScreenRight ();
			Debug.Log ("2");
			return true;
		}

		else if(time < 0.15F)
		{
			shakeScreenLeft ();
			Debug.Log ("3");
			return true;
		}	

		else if(time < 0.2F)
		{
			shakeScreenRight ();
			Debug.Log ("4");
			return true;
		}

		else if(time < 0.25F)
		{
			shakeScreenLeft ();
			Debug.Log ("5");
			return true;
		}	

		else if(time < 0.3F)
		{
			shakeScreenRight ();
			Debug.Log ("6");
			return true;
		}

		else if(time < 0.35F)
		{
			shakeScreenLeft ();
			Debug.Log ("7");
			return true;
		}

		else if(time < 0.4F)
		{
			shakeScreenRight ();
			Debug.Log ("8");
			return true;
		}

		else if(time < 0.45F)
		{
			shakeScreenLeft ();
			Debug.Log ("9");
			return true;
		}

		else if(time < 0.5F)
		{
			shakeScreenRight ();
			Debug.Log ("10");
			return true;
		}

		else if(time < 0.55F)
		{
			shakeScreenLeft ();
			Debug.Log ("10");
			return true;
		}

		else if(time < 0.6F)
		{
			shakeScreenRight ();
			Debug.Log ("10");
			return true;
		}

		else if(time < 0.65F)
		{
			shakeScreenLeft ();
			Debug.Log ("10");
			return true;
		}

		else if(time < 0.7F)
		{
			shakeScreenRight ();
			Debug.Log ("10");
			return true;
		}

		else if(time < 0.75F)
		{
			shakeScreenLeft ();
			Debug.Log ("10");
			return true;
		}

		else if(time < 0.8F)
		{
			shakeScreenRight ();
			Debug.Log ("10");
			return true;
		}

		else if(time < 0.85F)
		{
			shakeScreenRight ();
			Debug.Log ("10");
			return true;
		}

		else if(time < 0.9F)
		{
			shakeScreenLeft ();
			Debug.Log ("10");
			return true;
		}

		else if(time < 0.95F)
		{
			shakeScreenRight ();
			Debug.Log ("10");
			return true;
		}

		else if(time < 1F)
		{
			shakeScreenRight ();
			Debug.Log ("10");
			return true;
		}
		else
		{
			return true;
		}
	}
}
