using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Diese Klasse wird verwendet, um die Kamera beim Wechsel von Räumen von einer Ebene zur nächsten zu bewegen

public class CameraMover : MonoBehaviour {

	private bool isMoving = false;

	public bool MoveCameraToPos(Vector3 stagePos, float moveTime){
		if (!isMoving) {
			isMoving = true;
			LeanTween.move (gameObject, stagePos, moveTime).setOnComplete(() => {
				isMoving = false;
				}
			);
		}
		return !isMoving;
	}
}
