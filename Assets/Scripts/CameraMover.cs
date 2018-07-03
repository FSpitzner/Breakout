using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Diese Klasse wird verwendet, um die Kamera beim Wechsel von Räumen von einer Ebene zur nächsten zu bewegen

public class CameraMover : MonoBehaviour {

    [Header("Camera Settings")]
    [Tooltip("Time it takes to move the Camera to its position after starting the game")]
    public float cameraMoveTime = 2f;

	public void StartGame()
    {
        LeanTween.moveLocal(GameObject.FindGameObjectWithTag("MainCamera"), new Vector3(0, 3, -10), 2f).setEase(LeanTweenType.easeInOutSine);
        LeanTween.rotate(
            GameObject.FindGameObjectWithTag("MainCamera"),
            Quaternion.LookRotation(transform.position - new Vector3(
                transform.position.x,
                transform.position.y + 3,
                transform.position.z - 10)).eulerAngles,
            2f).setEase(LeanTweenType.easeInOutSine).setOnComplete(() => {
            PlayerController.instance.CameraOnPosition(true);
            LevelController.instance.InformCameraPointing();
        });
    }
	
}
