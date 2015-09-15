using UnityEngine;
using System.Collections;
using Pillo;
public class Beat : MonoBehaviour {

	public bool pressed = false;
	public bool crossedok = false;
	public bool crossedperfect = false;
	public GameObject Heart;
	public static int evoPoints;
	public AudioSource[] sounds;
	public AudioSource noise1;
	public AudioSource noise2;



	void Start () {
		 Heart = GameObject.Find ("Heart");

		//sounds = Heart.GetComponents<AudioSource>();
//		noise1 = sounds[0];
//		noise2 = sounds[1];


	}

	// Update is called once per frame
	void Update () {
		float pct = PilloController.GetSensor (Pillo.PilloID.Pillo1);



		if (pct > 0 && pressed == false ||  Input.GetKeyDown("space") && pressed == false) {
			pressed = true;
			if (crossedok == true) {
			//	noise1.Play();
				Debug.Log ("ok" + evoPoints);
				evoPoints++;
				Destroy (this.gameObject);
			}
			if (crossedperfect == true) {
//				noise2.Play();
			
				Debug.Log ("perfect" + evoPoints);
				evoPoints += 2;
				Destroy (this.gameObject);
			}


			if (pct == 0 && pressed == true) {
				pressed = false;
			}
		}
	}	
	void OnTriggerEnter(Collider col){
		if (col.gameObject.tag == "Markperfect") {
			crossedperfect = true;
			crossedok = false;
		}
		if(col.gameObject.tag == "Markok"){
			crossedok = true;
			crossedperfect = false;
		}

	}

	void OnTriggerExit(Collider col){
		if (col.gameObject.tag == "Markperfect") {
			crossedperfect = false;
		}
		if (col.gameObject.tag == "Markok") {
			crossedok = false;
		}

	}

}