using UnityEngine;
using System.Collections;
using Pillo;
public class MechanicControllerHiScore : MonoBehaviour 
{
	public MoveGround movingground;
	public SpawnGroundAndProps spawningclass;
	public MoveBackground movingbg;
	public SpawnBackground spawnbg;	
	private int turn;
	public static int stepstaken;
	public Animator m_ani;
	public bool done;
	public Animator redpillo;
	public Animator bluepillo;
	// Use this for initialization
	void Start () 
	{
		turn = 1;
		done = false;
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
					m_ani.SetBool("Switch", true);
					redpillo.SetInteger("RedSwitch",1);
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
					m_ani.SetBool("Switch", true);
					bluepillo.SetInteger("BlueSwitch",1);
					m_ani.SetBool("Switch", true);
				}
			}
			if(pct == 0){
				redpillo.SetInteger("RedSwitch",0);
				
			}
			if(pct2 == 0){
				bluepillo.SetInteger("BlueSwitch",0);
			}
			
			if(pct > 0.2){
				redpillo.SetInteger("RedSwitch",1);
			}

			if(pct2 > 0.2){
				bluepillo.SetInteger("BlueSwitch",1);
			}
		}
	}
}
