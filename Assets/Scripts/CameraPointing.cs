using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class CameraPointing : MonoBehaviour {

	public Transform player;
	public float smoothTurnSpeed = 0.2f;
	private float turnRef;
    public AnimationCurve pulse;
    public PostProcessVolume volume;
    private bool isTweening = false;
    private float timer;
    private float timerPosition;
    private bool cameraOnPos = false;

    void Update() {
        if (cameraOnPos) {
            if (LevelController.instance.IsDreamworldTriggered())
            {
                if (!isTweening) {
                    timer = 0;
                    isTweening = true;
                }
                else
                {
                    timer += Time.deltaTime;
                    if (timerPosition >= 1)
                    {
                        timerPosition = 0;
                    }
                    else
                    {
                        while (timerPosition < 1)
                        {
                            timerPosition += Time.deltaTime;
                        }
                    }
                    
                }
                volume.weight = pulse.Evaluate(timer);
                pulse.Evaluate(timerPosition);
                Debug.Log(timerPosition);
                //if (timerPosition >= 0.2 && timerPosition <= 0.3) { LevelController.instance.playHeartbeat(); }

                /*Debug.Log("TRIGGERED!!!");
                isTweening = true;
                LeanTween.value(volume.weight, volume.weight, pulse.length).setEase(pulse).setOnComplete(() => {
                    isTweening = false;
                });*/
            }
            Quaternion targetRotation = Quaternion.LookRotation(player.position - transform.position);
            float quatY = Mathf.Clamp(targetRotation.y, -0.05f, 0.05f);

            //Debug.Log (quatY);
            targetRotation = new Quaternion(targetRotation.x, quatY, targetRotation.z, targetRotation.w);
            //Debug.Log (targetRotation.y);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, smoothTurnSpeed * Time.deltaTime);

            //Debug.Log (transform.rotation.y);

            //float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, Vector3.Angle(transform.position, player.position), ref turnRef, smoothTurnSpeed);
            //Debug.Log (angle);
            //transform.eulerAngles = new Vector3 (transform.eulerAngles.x, transform.eulerAngles.y + angle, transform.eulerAngles.z);
            //transform.LookAt(player);
        }
	}

    public void CameraOnPos()
    {
        cameraOnPos = true;
    }
}