using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Fader : MonoBehaviour {

	// Use this for initialization
	public GameObject image;
	private float time;
	private float alpha;
	void Start () 
	{
		time = 3F;
		alpha = 0F;
	}
	
	// Update is called once per frame
	void Update () 
	{
		fadeImage();
	}

	private void fadeImage()
	{
		Vector4 colors = new Vector4(image.GetComponent<Image>().color.r,image.GetComponent<Image>().color.g,image.GetComponent<Image>().color.b,alpha);
		if(time-Time.deltaTime >= 3 )
		{
			alpha = 255;
		}
		alpha += 0.01F;
		image.GetComponent<Image>().color = colors;

	}
}
