using UnityEngine;
using System.Collections;

public class EvoSystem : MonoBehaviour {

	public int points;
	
	public GameObject ghost;
	public Animator m_ani;

	void FixedUpdate () {
		points = Beat.evoPoints;
	//	Debug.Log (points);
		if(points >= 4){

			m_ani.SetInteger("Evolve",1);
		}

		if(points >= 8){
			//animatie

		}

		if(points >= 12){
			//animatie
		}

		if(points >= 16){
			//animatie
		}

		if(points >= 20){
			//animatie
		}

		if(points >= 24){
			//animatie
		}
	}
}
