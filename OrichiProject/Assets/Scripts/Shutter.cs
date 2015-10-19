using UnityEngine;
using System.Collections;

public class Shutter : MonoBehaviour {

	// Use this for initialization
	public SceneLoader sceneloader;
	public GameObject leftdoor;
	public GameObject rightdoor;
	private float timeclose;
	private float timeopen;
	private bool donelerpingopen;
	private bool donelerpingclose;
	private Vector3 leftdoorclosepos;
	private Vector3 rightdoorclosepos;
	private Vector3 leftdooropenpos;
	private Vector3 rightdooropenpos;
	private bool timerclosefinished;
	private bool timeropenfinished;
	private bool openandclosed;
	public bool stayopen;
	private bool switchscene;
	private string scenetoswitchto;
	public bool introscene;
	private bool closegame;
	public bool pilloscene;

	void Start () 
	{
		closegame = false;
		scenetoswitchto = "";
		switchscene = false;
		donelerpingclose = true;
		donelerpingopen = false;
		openandclosed = false;
		timeclose = 1F;
		timeopen = 1F;
		leftdoorclosepos = new Vector3 (-190, leftdoor.transform.localPosition.y, leftdoor.transform.localPosition.z);
		rightdoorclosepos = new Vector3 (190, rightdoor.transform.localPosition.y, rightdoor.transform.localPosition.z);
		leftdooropenpos = new Vector3 (-570, leftdoor.transform.localPosition.y, leftdoor.transform.localPosition.z);
		rightdooropenpos = new Vector3 (570, rightdoor.transform.localPosition.y, rightdoor.transform.localPosition.z);
		leftdoor.transform.localPosition = leftdoorclosepos;
		rightdoor.transform.localPosition = rightdoorclosepos;
		timerclosefinished = false;
		timeropenfinished = false;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(switchscene && donelerpingclose)
		{
			sceneloader.loadScene(scenetoswitchto);
		}
		if (!openandclosed) 
		{
			countDownForOpenUp ();
			if (timeropenfinished && donelerpingclose) 
			{			
				checkForDoneLerpOpen (leftdoor.transform.localPosition, rightdoor.transform.localPosition);
				openDoors ();
			}
			if (donelerpingopen) 
			{
				timeopen = 1F;
				countDownForShutDown ();
			}
			if (timerclosefinished && donelerpingopen && !stayopen) 
			{
				checkForDoneLerpClose (leftdoor.transform.localPosition, rightdoor.transform.localPosition);
				shutDoors ();
				if(donelerpingclose)
				{
					openandclosed = true;

				}
			}
		}
		if (closegame && donelerpingclose)
		{
			Application.Quit();
		}

		else 
		{
			if(introscene && openandclosed)
			{
				sceneloader.loadScene("MainMenu");;
			}
			if(pilloscene && openandclosed)
			{
				sceneloader.loadScene("IntroScreen");
			}
		}

	}

	private void shutLeftDoor()
	{
		leftdoor.transform.localPosition = Vector3.Lerp(leftdoor.transform.localPosition, leftdoorclosepos, Time.deltaTime * 3);
	}

	private void shutRightDoor()
	{
		rightdoor.transform.localPosition = Vector3.Lerp(rightdoor.transform.localPosition, rightdoorclosepos, Time.deltaTime * 3);
	}

	private void shutDoors()
	{
		shutLeftDoor ();
		shutRightDoor ();
	}

	private void checkForDoneLerpClose(Vector3 leftdoorpos, Vector3 rightdoorpos)
	{
		if(leftdoor.transform.localPosition.x >= leftdoorclosepos.x - 0.1F && rightdoor.transform.localPosition.x <= rightdoorclosepos.x + 0.1F)
		{
			donelerpingclose = true;
			donelerpingopen = false;
		}
	}

	private void checkForDoneLerpOpen(Vector3 leftdoorpos, Vector3 rightdoorpos)
	{
		if(leftdoor.transform.localPosition.x <= leftdooropenpos.x + 0.1F && rightdoor.transform.localPosition.x >= rightdooropenpos.x - 0.1F)
		{
			donelerpingopen = true;
			donelerpingclose = false;
		}
	}

	private void openLeftDoor()
	{
		leftdoor.transform.localPosition = Vector3.Lerp(leftdoor.transform.localPosition, leftdooropenpos, Time.deltaTime * 3);
	}
		
	private void openRightDoor()
	{
		rightdoor.transform.localPosition = Vector3.Lerp(rightdoor.transform.localPosition, rightdooropenpos, Time.deltaTime * 3);
	}

	private void openDoors()
	{
		openLeftDoor ();
		openRightDoor ();
	}

	private void countDownForShutDown()
	{
		timeclose -= Time.deltaTime;
		if(timeclose <= 0)
		{
			timerclosefinished = true;
		}
	}

	private void countDownForOpenUp()
	{
		timeopen -= Time.deltaTime;
		if(timeopen <= 0)
		{
			timeropenfinished = true;
		}
	}

	public void loadSceneAfterClosing(string scenename)
	{
		scenetoswitchto = scenename;
		switchscene = true;
		donelerpingopen = true;
		donelerpingclose = false;
		stayopen = false;
	}

	public void closeGameAfterClosing()
	{
		donelerpingopen = true;
		donelerpingclose = false;
		stayopen = false;
		closegame = true;
	}

}
