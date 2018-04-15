using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


[RequireComponent(typeof(Rigidbody))]

public class PlayerController : MonoBehaviour {
	/*
	 * TODO
	 * Variablen in Gruppen einteilen + Unterteiler im Unity Inspector
	 * Variablen für alle Input-Tasten, damit diese in Optionen geändert werden können
	 */

	[Header("Player Statistics")]

	public float maxMoveSpeed;
	public float maxCrouchSpeed;
	public float jumpPower;
	public float maxRunSpeed;

	private int moveState = 1;
	private Rigidbody rb;

	// Controllerbelegung

	[Header("Inputs")]

	[SerializeField]
	private KeyCode jumpKey;
	[SerializeField]
	private KeyCode runKey;
	[SerializeField]
	private KeyCode crouchKey;
	[SerializeField]
	private KeyCode interactKey;

	[Header("Camera")]
	public Transform cameraDummy;
	public float camSmoothSpeed = 0.2f;
	private Vector3 camCurVelocity;

	void Start(){
		rb = this.GetComponent<Rigidbody> ();
		rb.interpolation = RigidbodyInterpolation.Interpolate;
	}

	void Update(){
		CheckKeyInput ();
		cameraDummy.position = Vector3.SmoothDamp (transform.position, new Vector3(cameraDummy.transform.position.x, cameraDummy.transform.position.y, transform.position.z), ref camCurVelocity, camSmoothSpeed);

		if(Input.GetKeyDown(interactKey)){
			LevelController.instance.UseTriggerObject ();
		}
	}

	void FixedUpdate(){
		if (Input.GetKey (runKey)&&moveState!=0) {
			moveState = 2;
		}
		if (Input.GetKeyUp (runKey)&&moveState!=0) {
			moveState = 1;
		}
		if (Input.GetKeyDown (crouchKey)) {
			if (moveState != 0)
				moveState = 0;
			else
				moveState = 1;
			Debug.Log("Now we are " + (moveState == 0 ? "crouching" : "walking"));
		}

		switch (moveState) {
		case 0:
			MovementControl (50);
			break;
		case 1:
			MovementControl (100);
			break;
		case 2:
			MovementControl (150);
			break;
		case 3:
			//kein Movement (zb beim Springen)
			break;
		default:
			MovementControl (100);
			break;
		}
	}

	private void MovementControl(int forcePower){
		float walking = Input.GetAxis ("Horizontal");
		rb.AddForce (new Vector3 (walking, 0f, 0f) * forcePower, ForceMode.Force);
		/*
		if (Input.GetKey (KeyCode.A)) {
			rb.AddForce (Vector3.left * forcePower, ForceMode.Force);
		}
		if (Input.GetKey (KeyCode.D)) {
			rb.AddForce (-Vector3.left * forcePower, ForceMode.Force);
		}*/
		if (rb.velocity.magnitude > (moveState == 0 ? maxCrouchSpeed : (moveState == 1 ? maxMoveSpeed : maxRunSpeed )))
			rb.velocity = rb.velocity.normalized * (moveState == 0 ? maxCrouchSpeed : (moveState == 1 ? maxMoveSpeed : maxRunSpeed));
	}

	void CheckKeyInput(){
		foreach(KeyCode kcode in Enum.GetValues(typeof(KeyCode))){
			if (Input.GetKeyDown(kcode)){
				Debug.Log("KeyCode down: " + kcode);
			}
		}
		//Debug.Log ("Horizontal: " + Input.GetAxis ("ControllerPOVVertical"));
		//Debug.Log ("Vertical: " + Input.GetAxis ("ControllerPOVHorizontal"));
	}
}
