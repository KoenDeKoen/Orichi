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
	public Animator redpillo;
	public Animator bluepillo;
	public bool done;
	public GameObject helpcloud;

	// Use this for initialization
	void Start () 
	{
		turn = 1;
		done = false;
		if(Custominput.tutorial)
		{
			help.enabled = true;
			helpcloud.SetActive(true);
		}

		else
		{
			help.enabled = false;
			helpcloud.SetActive(false);
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(!done){
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
					if(Custominput.tutorial)
					{
						help.SetInteger("MoveSet",1);

					}
					m_ani.SetBool("Switch", true);
					redpillo.SetInteger("RedSwitch",1);
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
					if(Custominput.tutorial)
					{
						help.SetInteger("MoveSet",2);

					}
					m_ani.SetBool("Switch", true);
					bluepillo.SetInteger("BlueSwitch",1);
				}
			}

			if(Custominput.tutorial)
			{
				if(Input.GetKeyDown("a") || pct > 0.2 && pct2 == 0)
				{	
					help.SetInteger("MoveSet",1);
				}

				if(Input.GetKeyDown("l") || pct2 > 0.2 && pct == 0)
				{
					help.SetInteger("MoveSet",2);
				}
		
				if((Input.GetKeyDown("a") && Input.GetKeyDown("l")) || (pct > 0.2 && pct2 > 0.2)){
					help.SetInteger("MoveSet",3);
				}
			}
			if(pct == 0){
				redpillo.SetInteger("RedSwitch",0);

			}
			if(pct2 == 0){
				bluepillo.SetInteger("BlueSwitch",0);
			}

			if(pct > 0.2 && pct2 > 0.2){
				redpillo.SetInteger("RedSwitch",1);
				bluepillo.SetInteger("BlueSwitch",1);
			}
		}
	}
}
