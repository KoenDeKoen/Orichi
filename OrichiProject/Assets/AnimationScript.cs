using UnityEngine;
using System.Collections;

public class AnimationScript : MonoBehaviour {

	public Animator m_ani;

	// Animation Event
	public void Switch() {
		m_ani.SetBool("Switch", false);
	}
}
