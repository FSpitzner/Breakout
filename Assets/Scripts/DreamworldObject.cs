using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DreamworldObject : MonoBehaviour {

	public float disappearTime;

	public void Activate(){
		transform.gameObject.SetActive (true);
	}

	public void Deactivate(){
		Invoke ("Disappear", disappearTime);
	}

	private void Disappear(){
		transform.gameObject.SetActive (false);
	}
}