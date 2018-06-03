using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DreamworldObject : MonoBehaviour {

	public float disappearTime;

	public void Activate(){
		transform.gameObject.SetActive (true);
        LeanTween.scale(gameObject, new Vector3(1, 1, 1), 0.5f);
	}
    

    public void Deactivate(){
		Invoke ("Disappear", disappearTime);
        LeanTween.scale(gameObject, new Vector3(0, 0, 0), 0.5f);
    }

	private void Disappear(){
		transform.gameObject.SetActive (false);
	}
}