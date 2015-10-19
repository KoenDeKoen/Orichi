using UnityEngine;
using System.Collections;

public class ParticleTrigger : MonoBehaviour {

	public Transform hearts;

	public void Heartsparticle(GameObject gameobjectpos) {
		Instantiate(hearts, gameobjectpos.transform.position, Quaternion.identity);
	}
}
