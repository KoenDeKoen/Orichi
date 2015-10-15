using UnityEngine;
using System.Collections;
using UnityEngine.UI;
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
	// Use this for initialization
	void Start () {

		timeelapsed = 0;
		starttime = Time.time;
		Custominput.exercises = 50;
		highscore = PlayerPrefs.GetFloat ("highscore");

	}
	//startime = 24 , starttime - starttime = timeelapsed;

	void Update() {


		SetText ();
		this.gameObject.GetComponent<SpriteRenderer> ().sprite = currentsprite;
		progresspercentage = MechanicController.stepstaken / Custominput.exercises;
		timeelapsed	= Time.time - starttime;
		if (PlayerPrefs.GetFloat ("highscore") == 0 &&  MechanicController.stepstaken == Custominput.exercises) {
			highscore = timerscore;
			PlayerPrefs.SetFloat ("highscore", highscore);
			PlayerPrefs.Save ();

		}
		if (timerscore < highscore && MechanicController.stepstaken == Custominput.exercises) {
			highscore = timerscore;
			PlayerPrefs.SetFloat ("highscore", highscore);
			PlayerPrefs.Save ();
		}

		if (MechanicController.stepstaken == Custominput.exercises) {
			timerscore = timeelapsed;
			
		}

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
		if (EvoSystem.evolevel < 3 && progresspercentage > 0.66666) {
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
	}

	
	public void SetText() {
		timer.text = timeelapsed.ToString ("f1");
		amounttotalamount.text = MechanicController.stepstaken.ToString() + "/" + Custominput.exercises.ToString();
	}



	IEnumerator fullbar(){
		currentsprite = evostatus7;
		yield return new WaitForSeconds(1.5f);
		currentsprite = evostatus1;
	}

}
