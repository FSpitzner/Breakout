using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Diese Klasse wird verwendet, um bei Spielstart die Kamera in Position zu fahren

public class CameraMover : MonoBehaviour {

    [Header("Camera Settings")]
    [Tooltip("Time it takes to move the Camera to its position after starting the game")]
    public float cameraMoveTime = 2f;

	public void StartGame()
    {
        Debug.Log("Game Started");
        LeanTween.moveLocal(GameObject.FindGameObjectWithTag("MainCamera"), new Vector3(0, 2, -5), 2f).setEase(LeanTweenType.easeInOutSine);
        LeanTween.rotate(
            GameObject.FindGameObjectWithTag("MainCamera"),
            Quaternion.LookRotation(transform.position - new Vector3(
                transform.position.x,
                transform.position.y + 2,
                transform.position.z - 5)).eulerAngles,
            2f).setEase(LeanTweenType.easeInOutSine).setOnComplete(() => {
            PlayerController.instance.CameraOnPosition(true);
            LevelController.instance.InformCameraPointing();
        });
    }
	
}
