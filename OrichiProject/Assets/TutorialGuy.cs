using UnityEngine;
using System.Collections;

public class TutorialGuy : MonoBehaviour {

	public GameObject oldGuy;
	private float time = 0f;
	private float size;
	private float x;
	private float y;

	// Use this for initialization
	void Start () {
		x = 7f;
		y = 3f;
		size = 0.2f;

		oldGuy.transform.localScale = new Vector3(size,size);
		oldGuy.transform.localPosition = new Vector3(x,y);
	}

	public void SummonOldGuy (){
		time += Time.deltaTime;
		size += 0.0084f;
		x -= 0.022f;
		y -= 0.059f;

		if(time >= 1){
			size = 0.6f;
			x = 6f;
			y = 0.15f;
		}
		oldGuy.transform.localScale = new Vector3(size,size);
		oldGuy.transform.localPosition = new Vector3(x,y);
	}

	public void DispelOldGuy (){
		time += Time.deltaTime;
		size -= 0.0084f;
		x += 0.022f;
		y += 0.059f;
		
		if(time >= 1){
			size = 0.2f;
			x = 7f;
			y = 3f;
		}
		oldGuy.transform.localScale = new Vector3(size,size);
		oldGuy.transform.localPosition = new Vector3(x,y);
	}
}