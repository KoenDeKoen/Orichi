using UnityEngine;
using System.Collections;

public class EvoSystem : MonoBehaviour {

	public int points;
	
	public GameObject ghost;
	public Animator m_ani;

	int evolevel;

	public Transform prefab;

	void FixedUpdate () {
		points = Beat.evoPoints;
		if(points >= 8){
			if(evolevel < 1)
			{
				evolevel = 1;
			m_ani.SetInteger("Evolve",1);
			Instantiate(prefab, new Vector3(0,0,-2), Quaternion.identity);
			}
		}

		if(points >= 16){
			//animatie
		}

		if(points >= 24){
			//animatie
		}
	}
}
