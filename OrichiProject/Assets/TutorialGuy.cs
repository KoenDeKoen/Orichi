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
		size += 0.005f;
		x -= 0.013f;
		y -= 0.018f;

		if(time >= 1){
			size = 0.4f;
			x = 6.5f;
			y = 2.3f;
		}
		oldGuy.transform.localScale = new Vector3(size,size);
		oldGuy.transform.localPosition = new Vector3(x,y);
	}

	public void DispelOldGuy (){
		time += Time.deltaTime;
		size -= 0.005f;
		x += 0.013f;
		y += 0.018f;
		
		if(time >= 1){
			size = 0.2f;
			x = 7f;
			y = 3f;
		}
		oldGuy.transform.localScale = new Vector3(size,size);
		oldGuy.transform.localPosition = new Vector3(x,y);
	}

	public void Popup () {

	}
}