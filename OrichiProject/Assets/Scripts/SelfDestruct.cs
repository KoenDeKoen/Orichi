using UnityEngine;
using System.Collections;

public class SelfDestruct : MonoBehaviour {
	
	public void DestroyMe()
	{
		Destroy (gameObject);
	}
}
