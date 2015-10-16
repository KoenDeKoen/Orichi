using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.IO;

public class HighScoreMode : MonoBehaviour {
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
	public Text timer;
	public static float timerscore;
	public float highscore;
	public float timeelapsed;
	public float starttime;
	public float secondplace;
	public float thirdplace;
	private bool finished = false;
	// Use this for initialization
	void Start () {

		highscore =	PlayerPrefs.GetFloat("highscore");
		secondplace = PlayerPrefs.GetFloat("secondplace");
		thirdplace = PlayerPrefs.GetFloat("thirdplace");
		timeelapsed = 0;
		starttime = Time.time;
		Custominput.exercises = 50;
		finished = false;

	}
	//startime = 24 , starttime - starttime = timeelapsed;

	void Update() {


		SetText ();
		this.gameObject.GetComponent<SpriteRenderer> ().sprite = currentsprite;
		progresspercentage = MechanicControllerHiScore.stepstaken / Custominput.exercises;
		timeelapsed	= Time.time - starttime;

		if (MechanicControllerHiScore.stepstaken == Custominput.exercises) {
			timerscore = timeelapsed;	
		}

		if (EvoSystemHiScore.evolevel < 1) {
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
		if (EvoSystemHiScore.evolevel < 2 && progresspercentage > 0.33333) {
			//if(progresspercentage >0.333333 && currentsprite == evostatus7){
			
			//currentsprite = evostatus1;
			//	}
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
		if (EvoSystemHiScore.evolevel < 3 && progresspercentage > 0.66666) {
			//	if(progresspercentage >0.66666 && currentsprite == evostatus7){
			
			
			//	}
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

	//////////////////////////////highscore///////////////////////////////////

		
		if (highscore == 0 &&  MechanicControllerHiScore.stepstaken == 50 && finished == false) {
			highscore = timerscore;
			PlayerPrefs.SetFloat("highscore", highscore);
			Debug.Log ("in the 0 if");
			finished = true;
		}
		if (timerscore < secondplace && timerscore > highscore && MechanicControllerHiScore.stepstaken == 50 && finished == false || secondplace == 0 && timerscore > highscore && MechanicControllerHiScore.stepstaken == 50 && finished == false) {

		
			PlayerPrefs.SetFloat("thirdplace", secondplace);
			PlayerPrefs.SetFloat("secondplace", timerscore);
			finished = true;
		
		}
		if (timerscore < thirdplace && timerscore > secondplace && MechanicControllerHiScore.stepstaken == 50 && finished == false || thirdplace == 0 && timerscore > secondplace && MechanicControllerHiScore.stepstaken == 50 && finished == false) {
			PlayerPrefs.SetFloat("thirdplace", timerscore);
			finished = true;
		}
		if (timerscore < highscore && MechanicControllerHiScore.stepstaken == 50 && finished == false) {

			PlayerPrefs.SetFloat("thirdplace", secondplace);
			PlayerPrefs.SetFloat("secondplace", highscore);
			PlayerPrefs.SetFloat("highscore", timerscore);
			Debug.Log ("in the < if");
			finished = true;
	
		}

	}

	
	///////////////////////////////////////////////////////////////////////////////////// 

	public void SetText() {
		timer.text = timeelapsed.ToString ("f1");
		amounttotalamount.text = MechanicControllerHiScore.stepstaken.ToString() + "/" + Custominput.exercises.ToString();
	}


	IEnumerator fullbar(){
		currentsprite = evostatus7;
		yield return new WaitForSeconds(1.5f);
		currentsprite = evostatus1;
	}

}
