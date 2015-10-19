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
		time = 2F;
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
			time = 2F;
			return false;
		}

		else if(time < 0.1F)
		{
			shakeScreenRight ();
			return true;
		}

		else if(time < 0.15F)
		{
			shakeScreenLeft ();
			return true;
		}	

		else if(time < 0.2F)
		{
			shakeScreenRight ();
			return true;
		}

		else if(time < 0.25F)
		{
			shakeScreenLeft ();
			return true;
		}	

		else if(time < 0.3F)
		{
			shakeScreenRight ();
			return true;
		}

		else if(time < 0.35F)
		{
			shakeScreenLeft ();
			return true;
		}

		else if(time < 0.4F)
		{
			shakeScreenRight ();
			return true;
		}

		else if(time < 0.45F)
		{
			shakeScreenLeft ();
			return true;
		}

		else if(time < 0.5F)
		{
			shakeScreenRight ();
			return true;
		}

		else if(time < 0.55F)
		{
			shakeScreenLeft ();
			return true;
		}

		else if(time < 0.6F)
		{
			shakeScreenRight ();
			return true;
		}

		else if(time < 0.65F)
		{
			shakeScreenLeft ();
			return true;
		}

		else if(time < 0.7F)
		{
			shakeScreenRight ();
			return true;
		}

		else if(time < 0.75F)
		{
			shakeScreenLeft ();
			return true;
		}

		else if(time < 0.8F)
		{
			shakeScreenRight ();
			return true;
		}

		else if(time < 0.85F)
		{
			shakeScreenRight ();
			return true;
		}

		else if(time < 0.9F)
		{
			shakeScreenLeft ();
			return true;
		}

		else if(time < 0.95F)
		{
			shakeScreenRight ();
			return true;
		}

		else if(time < 1F)
		{
			shakeScreenRight ();
			return true;
		}
		else if(time < 1.05F)
		{
			shakeScreenLeft ();
			return true;
		}	
		
		else if(time < 1.1F)
		{
			shakeScreenRight ();
			return true;
		}
		
		else if(time < 1.15F)
		{
			shakeScreenLeft ();
			return true;
		}	
		
		else if(time < 1.2F)
		{
			shakeScreenRight ();
			return true;
		}
		
		else if(time < 1.25F)
		{
			shakeScreenLeft ();
			return true;
		}
		
		else if(time < 1.3F)
		{
			shakeScreenRight ();
			return true;
		}
		
		else if(time < 1.35F)
		{
			shakeScreenLeft ();
			return true;
		}
		
		else if(time < 1.4F)
		{
			shakeScreenRight ();
			return true;
		}
		
		else if(time < 1.45F)
		{
			shakeScreenLeft ();
			return true;
		}
		
		else if(time < 1.5F)
		{
			shakeScreenRight ();
			return true;
		}
		
		else if(time < 1.55F)
		{
			shakeScreenLeft ();
			return true;
		}
		
		else if(time < 1.6F)
		{
			shakeScreenRight ();
			return true;
		}
		
		else if(time < 1.65F)
		{
			shakeScreenLeft ();
			return true;
		}
		
		else if(time < 1.7F)
		{
			shakeScreenRight ();
			return true;
		}
		
		else if(time < 1.75F)
		{
			shakeScreenRight ();
			return true;
		}
		
		else if(time < 1.8F)
		{
			shakeScreenLeft ();
			return true;
		}
		
		else if(time < 1.85F)
		{
			shakeScreenRight ();
			return true;
		}
		
		else if(time < 1.9F)
		{
			shakeScreenLeft ();
			return true;
		}
		else if(time < 1.95F)
		{
			shakeScreenRight ();
			return true;
		}
		else if(time < 2F)
		{
			shakeScreenRight ();
			return true;
		}
		else
		{
			return true;
		}
	}
}
