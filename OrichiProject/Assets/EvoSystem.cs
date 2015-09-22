using UnityEngine;
using System.Collections;

public class EvoSystem : MonoBehaviour {


	public Transform prefab;
	public Animator m_ani;
	private GameObject tempobj;
	public int points;
	int evolevel;



	void Update () {
		points = MechanicController.stepstaken;

		if(points >= 20){
			if(evolevel < 1)
			{
				evolevel = 1;
				m_ani.SetInteger("Evolve",1);
				Instantiate(prefab, new Vector3(0,-1.5F,-5), Quaternion.identity);
			}
		}

		if(points >= 60){
			if(evolevel < 2)
			{
				evolevel = 2;
				m_ani.SetInteger("Evolve",2);
				Instantiate(prefab, new Vector3(0,-1.5f,-2), Quaternion.identity);
			}
		}

		if(points >= 100){
			if(evolevel < 3)
			{
				evolevel = 3;
				m_ani.SetInteger("Evolve",3);
				Instantiate(prefab, new Vector3(0,-1.5f,-2), Quaternion.identity);
			}
		}
	}
}
