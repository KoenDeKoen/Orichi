using UnityEngine;
using System.Collections;
using Pillo;
public class MechanicController : MonoBehaviour 
{
	public MoveGround movingground;
	public SpawnGroundAndProps spawningclass;
	public MoveBackground movingbg;
	public SpawnBackground spawnbg;	
	private int turn;
	public static int stepstaken;
	public Animator m_ani;
	public Animator help;

	// Use this for initialization
	void Start () 
	{
		turn = 1;
	}
	
	// Update is called once per frame
	void Update () 
	{
		float pct = PilloController.GetSensor (Pillo.PilloID.Pillo1);
		float pct2 = PilloController.GetSensor (Pillo.PilloID.Pillo2);
		//PLAYER 1 turn
		if(turn == 1)
		{
			if(Input.GetKeyDown("a") || pct > 0.2 && pct2 == 0)
			{
				movingground.moveGround(spawningclass.getParent());
				movingbg.moveFastMountain(spawnbg.getParents()[0]);
				movingbg.moveSlowMountain(spawnbg.getParents()[1]);
				stepstaken++;
				turn = 2;
				help.SetInteger("MoveSet",1);
				m_ani.SetBool("Switch", true);
			}
		}

		//PLAYER 2 turn
		if(turn == 2)
		{
			if(Input.GetKeyDown("l") || pct2 > 0.2 && pct == 0 )
			{
				movingground.moveGround(spawningclass.getParent());
				movingbg.moveFastMountain(spawnbg.getParents()[0]);
				movingbg.moveSlowMountain(spawnbg.getParents()[1]);
				stepstaken++;
				turn = 1;
				help.SetInteger("MoveSet",2);
				m_ani.SetBool("Switch", true);
			}
		}

		if(Input.GetKeyDown("a") || pct > 0.2 && pct2 == 0)
		{
			help.SetInteger("MoveSet",1);
		}

		if(Input.GetKeyDown("l") || pct2 > 0.2 && pct == 0 )
		{
			help.SetInteger("MoveSet",2);
		}
		
		if((Input.GetKeyDown("a") && Input.GetKeyDown("l")) || (pct > 0.2 && pct2 > 0.2)){
			help.SetInteger("MoveSet",3);
		}
	}
}
