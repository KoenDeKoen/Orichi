using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Ritme : MonoBehaviour {

	//public Rigidbody beat;
	public GameObject beat;
	public float speed;
	public GameObject clone;
	public GameObject heartrate;
	public float timer;
	public GameObject slider;

	void Start(){
	
		timer = 4;
	}

	// Update is called once per frame
	public void Update () {
	
	//	timer -= Time.deltaTime;
	
	//	if (timer <= 0){
	//		clone = (GameObject)Instantiate(beat, transform.position, Quaternion.identity);
		//	clone.GetComponent<Rigidbody>().velocity = transform.forward * speed;
	//		Destroy(clone, 20.0f);


		//}
	}

}