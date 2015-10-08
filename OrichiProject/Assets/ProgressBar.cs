using UnityEngine;
using System.Collections;

public class ProgressBar : MonoBehaviour {

	public float progresspercentage;
	public Sprite evostatus7;
	public Sprite evostatus6;
	public Sprite evostatus5;
	public Sprite evostatus4;
	public Sprite evostatus3;
	public Sprite evostatus2;
	public Sprite evostatus1;
	public Sprite currentsprite;
	void Start(){
	

	}



	void Update() {
		this.gameObject.GetComponent<SpriteRenderer> ().sprite = currentsprite;
		progresspercentage = MechanicController.stepstaken / Custominput.exercises;
		if (progresspercentage == 0) {
			currentsprite = evostatus1;
		}

		if (progresspercentage > 0.1666666666666667 && currentsprite == evostatus1 ) {
			currentsprite = evostatus2;
		}

		if (progresspercentage > 0.3333333333333333 && currentsprite == evostatus2 ) {
			currentsprite = evostatus3;
		}
		if (progresspercentage > 0.5 && currentsprite == evostatus3 ) {
			currentsprite = evostatus4;
		}
		if (progresspercentage > 0.6666666666666667 && currentsprite == evostatus4 ) {
			currentsprite = evostatus5;
		}
		if (progresspercentage > 0.8333333333333333 && currentsprite == evostatus5 ) {
			currentsprite = evostatus6;
		}

		if (progresspercentage == 1 && currentsprite == evostatus6 ) {
			currentsprite = evostatus7;
		}
	}
}