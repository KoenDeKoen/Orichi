using UnityEngine;
using System.Collections;

public class EvoSystem : MonoBehaviour {



	public Animator m_ani;

	public int points;
	int evolevel;

	public Transform prefab;

	void Update () {

		points = MechanicController.stepstaken;
		Debug.Log(points);

		if(points >= 8){
			if(evolevel < 1)
			{
				evolevel = 1;
			m_ani.SetInteger("Evolve",1);
			Instantiate(prefab, new Vector3(0,0,-2), Quaternion.identity);
			}
		}

		if(points >= 16){
			if(evolevel < 2)
			{
				evolevel = 2;
				m_ani.SetInteger("Evolve",2);
				Instantiate(prefab, new Vector3(0,0,-2), Quaternion.identity);
			}
		}

		if(points >= 24){
			if(evolevel < 3)
			{
				evolevel = 3;
				m_ani.SetInteger("Evolve",3);
				Instantiate(prefab, new Vector3(0,0,-2), Quaternion.identity);
			}
		}
	}
}
