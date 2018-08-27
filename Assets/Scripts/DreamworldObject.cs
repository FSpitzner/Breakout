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
    }

	private void Disappear(){
        LeanTween.scale(gameObject, new Vector3(0, 0, 0), 0.5f).setOnComplete(() => {
            transform.gameObject.SetActive(false);
        });
	}
}