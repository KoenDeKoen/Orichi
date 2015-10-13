using UnityEngine;
using System.Collections;
using UnityEngine.UI;
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
	public Text amounttotalamount;

	void Start(){
	

	}
	//exercisesdone / exercisestotal

	public void SetText() {
		amounttotalamount.text = MechanicController.stepstaken.ToString() + "/" + Custominput.exercises.ToString();
	}

	void Update() {

		SetText ();
		this.gameObject.GetComponent<SpriteRenderer> ().sprite = currentsprite;
		progresspercentage = MechanicController.stepstaken / Custominput.exercises;
	/*	if (progresspercentage == 0) {
			currentsprite = evostatus1;
		}

		if (progresspercentage > 0.166 && currentsprite == evostatus1) {
			currentsprite = evostatus2;
		}

		if (progresspercentage > 0.333 && currentsprite == evostatus2) {
			currentsprite = evostatus3;
		}
		if (progresspercentage > 0.5 && currentsprite == evostatus3) {
			currentsprite = evostatus4;
		}
		if (progresspercentage > 0.666 && currentsprite == evostatus4) {
			currentsprite = evostatus5;
		}
		if (progresspercentage > 0.833 && currentsprite == evostatus5) {
			currentsprite = evostatus6;
		}

		if (progresspercentage == 1 && currentsprite == evostatus6) {
			currentsprite = evostatus7;
		}*/
		if (EvoSystem.evolevel < 1) {
			if(progresspercentage == 0){
			currentsprite = evostatus1;
			}
			if(progresspercentage > 0.055 && currentsprite == evostatus1 ){
				currentsprite = evostatus2;
			}
			if(progresspercentage > 0.11111&& currentsprite == evostatus2 ){
				currentsprite = evostatus3;
			}
			if(progresspercentage > 0.16666 && currentsprite == evostatus3 ){
				currentsprite = evostatus4;
			}
			if(progresspercentage > 0.22222 && currentsprite == evostatus4 ){
				currentsprite = evostatus5;
			}
			if(progresspercentage > 0.2777&& currentsprite == evostatus5  ){
				currentsprite = evostatus6;
			}
			if(progresspercentage > 0.333333 && currentsprite == evostatus6){
				StartCoroutine("fullbar");
		
			}
		}
		if (EvoSystem.evolevel < 2 && progresspercentage > 0.33333) {
			if(progresspercentage >0.333333 && currentsprite == evostatus7){
		
				//currentsprite = evostatus1;
			}
			if(progresspercentage > 0.38833&& currentsprite == evostatus1 ){
				currentsprite = evostatus2;
			}
			if(progresspercentage > 0.44444&& currentsprite == evostatus2  ){
				currentsprite = evostatus3;
			}
			if(progresspercentage > 0.49996 && currentsprite == evostatus3 ){
				currentsprite = evostatus4;
			}
			if(progresspercentage > 0.55555 && currentsprite == evostatus4 ){
				currentsprite = evostatus5;
			}
			if(progresspercentage > 0.61109&& currentsprite == evostatus5  ){
				currentsprite = evostatus6;
			}
			if(progresspercentage > 0.66666  && currentsprite == evostatus6){
				StartCoroutine("fullbar");
		
			}
		}
		if (EvoSystem.evolevel < 3 && progresspercentage > 0.66666) {
			if(progresspercentage >0.66666 && currentsprite == evostatus7){


			}
			if(progresspercentage > 0.055 + 0.6666 && currentsprite == evostatus1 ){
				currentsprite = evostatus2;
			}
			if(progresspercentage > 0.11111 + 0.6666 && currentsprite == evostatus2){
				currentsprite = evostatus3;
			}
			if(progresspercentage > 0.16666 + 0.6666 && currentsprite == evostatus3){
				currentsprite = evostatus4;
			}
			if(progresspercentage > 0.22222 + 0.6666 && currentsprite == evostatus4){
				currentsprite = evostatus5;
			}
			if(progresspercentage > 0.2777 + 0.6666 && currentsprite == evostatus5){
				currentsprite = evostatus6;
			}
			if(progresspercentage >= 1 && currentsprite == evostatus6){
				currentsprite = evostatus7;
			}
		}
	}
	IEnumerator fullbar(){
		currentsprite = evostatus7;
		yield return new WaitForSeconds(1.5f);
		currentsprite = evostatus1;
	}

}