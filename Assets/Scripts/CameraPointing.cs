using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPointing : MonoBehaviour {

	public Transform player;
	public float smoothTurnSpeed = 0.2f;
	private float turnRef;

	void Update () {

		Quaternion targetRotation = Quaternion.LookRotation (player.position - transform.position);
		float quatY = Mathf.Clamp(targetRotation.y, -0.05f, 0.05f);

		//Debug.Log (quatY);
		targetRotation = new Quaternion (targetRotation.x, quatY, targetRotation.z, targetRotation.w);
		//Debug.Log (targetRotation.y);
		transform.rotation = Quaternion.Slerp (transform.rotation, targetRotation, smoothTurnSpeed * Time.deltaTime);

		//Debug.Log (transform.rotation.y);

		//float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, Vector3.Angle(transform.position, player.position), ref turnRef, smoothTurnSpeed);
		//Debug.Log (angle);
		//transform.eulerAngles = new Vector3 (transform.eulerAngles.x, transform.eulerAngles.y + angle, transform.eulerAngles.z);
		//transform.LookAt(player);

	}
}