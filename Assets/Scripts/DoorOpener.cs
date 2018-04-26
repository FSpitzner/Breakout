using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpener : MonoBehaviour {

	public Vector3 targetPosOffset;
	public float openTime = 3;
	private Vector3 defaultPosition;
	private bool opened = false, tweening = false;

	void OnDrawGizmos(){
		
		Gizmos.color = Color.blue;
		Gizmos.DrawWireCube (new Vector3(transform.position.x + targetPosOffset.x, transform.position.y + targetPosOffset.y, transform.position.z + targetPosOffset.z), transform.lossyScale);
	}

	void Start(){
		defaultPosition = transform.position;
	}

	public void Open(){
		if (!tweening) {
			tweening = true;
			if (!opened)
				LeanTween.move (gameObject, transform.position + targetPosOffset, openTime).setOnComplete (() => {
					opened = true;
					tweening = false;
				});
			else
				LeanTween.move (gameObject, defaultPosition, openTime).setOnComplete (() => {
					opened = false;
					tweening = false;
				});
		}
	}
}