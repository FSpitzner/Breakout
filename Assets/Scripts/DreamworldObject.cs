using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DreamworldObject : MonoBehaviour {

	public float delay;

    private void Awake()
    {
        transform.localScale = new Vector3(0, 0, 0);
        gameObject.SetActive(false);
    }

    public void Activate(){
        Invoke("Appear", delay);
	}
    
    public void Deactivate(){
		Invoke ("Disappear", delay);
    }

	private void Disappear(){
        LeanTween.scale(gameObject, new Vector3(0, 0, 0), 0.5f).setOnComplete(() => {
            transform.gameObject.SetActive(false);
        });
	}

    private void Appear()
    {
        transform.gameObject.SetActive(true);
        LeanTween.scale(gameObject, new Vector3(1, 1, 1), 0.5f);
    }
}