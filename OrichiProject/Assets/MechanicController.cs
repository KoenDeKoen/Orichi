using UnityEngine;
using System.Collections;

public class MechanicController : MonoBehaviour 
{
	public MoveGround movingground;
	private int turn;
	// Use this for initialization
	void Start () 
	{
		turn = 1;
	}
	
	// Update is called once per frame
	void Update () 
	{
		//PLAYER 1 turn
		if(turn == 1)
		{
			if(Input.GetKeyDown("a"))
			{
				movingground.moveGround();
				turn = 2;
			}
		}

		//PLAYER 2 turn
		if(turn == 2)
		{
			if(Input.GetKeyDown("l"))
			{
				movingground.moveGround();
				turn = 1;
			}
		}
	}
}
