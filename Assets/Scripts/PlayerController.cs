﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


[RequireComponent(typeof(Rigidbody))]

public class PlayerController : MonoBehaviour {
    public static PlayerController instance;

    [Header("Animator")]
    public Animator ani;

	[Header("Player Statistics")]

	public float maxMoveSpeed;
	public float maxCrouchSpeed;
	public float jumpPower;
	public float maxRunSpeed;
    public float velocity;

	private int moveState = 1;
	private Rigidbody rb;
	private bool jumping = false;

    [Header("Collider")]
    [Tooltip("Amy's default Collider when standing")]
    public Collider defaultCollider;
    [Tooltip("Amy's Collider when crouching")]
    public Collider crouchCollider;
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

    private List<InteractTrigger> interactTriggers;

	//LevelSettings
	//[HideInInspector]
    [Tooltip("Scriptable Object Player Stage")]
	public StageController stage;
    private bool controlsLocked = false;
    private bool gameStarted = false;
    private bool cameraOnPos = false;

    [HideInInspector]
    public List<ItemController> items;

    private void Awake()
    {
        instance = this;
    }

    void Start(){
        interactTriggers = new List<InteractTrigger>();
        items = new List<ItemController>();
		rb = this.GetComponent<Rigidbody> ();
		rb.interpolation = RigidbodyInterpolation.Interpolate;
        Debug.Log("Player: " + this);
        Debug.Log("Stage Registered: " + stage);
        crouchCollider.enabled = false;
	}

	void Update(){
        if (gameStarted && cameraOnPos)
        {
            //CheckKeyInput ();
            cameraDummy.position = Vector3.SmoothDamp(
                new Vector3(transform.position.x, transform.position.y, cameraDummy.transform.position.z),
                new Vector3(cameraDummy.transform.position.x, cameraDummy.transform.position.y, cameraDummy.transform.position.z),
                ref camCurVelocity, camSmoothSpeed);
            if (Input.GetKeyDown(interactKey))
            {
                interactTriggers.ForEach((InteractTrigger it) =>
                {
                    it.Interact();
                });
            }
        }
	}

	void FixedUpdate(){
        
        if (gameStarted && cameraOnPos)
        {
            if (!controlsLocked)
            {
                if (Input.GetKey(runKey) && moveState != 0)
                {
                    moveState = 2;
                }
                if (Input.GetKeyUp(runKey) && moveState != 0)
                {
                    moveState = 1;
                }
                if (Input.GetButtonUp("Jump"))
                {
                    if (moveState != 0)
                    {
                        moveState = 0;
                        ani.SetBool("crouching", true);
                        crouchCollider.enabled = true;
                        defaultCollider.enabled = false;
                    }
                    else
                    {
                        moveState = 1;
                        ani.SetBool("crouching", false);
                        defaultCollider.enabled = true;
                        crouchCollider.enabled = false;
                    }
                    Debug.Log("Now we are " + (moveState == 0 ? "crouching" : "walking"));
                }
                if (Input.GetKeyDown(jumpKey))
                {
                    if (!jumping)
                    {
                        jumping = true;
                        Jumper();
                    }
                }

                switch (moveState)
                {
                    case 0:
                        MovementControl(50);
                        break;
                    case 1:
                        MovementControl(100);
                        break;
                    case 2:
                        MovementControl(150);
                        break;
                    case 3:
                        //kein Movement (zb beim Springen)
                        break;
                    default:
                        MovementControl(100);
                        break;
                }
            }
        }
        velocity = rb.velocity.magnitude;
        ani.SetFloat("velocity", rb.velocity.magnitude);
    }

	private void MovementControl(int forcePower){
		float walkingHorizontal = Input.GetAxis ("Horizontal");
		float walkingVertical = Input.GetAxis ("Vertical");
        Vector3 forcedirection = new Vector3(walkingHorizontal, 0f, walkingVertical);
        rb.AddForce (forcedirection * forcePower, ForceMode.Force);
        if(forcedirection != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(forcedirection);
        }

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

	private void Jumper(){
		rb.AddForce (Vector3.up * jumpPower, ForceMode.Impulse);
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

	void OnCollisionEnter(Collision collision)
	{
		if(collision.contacts.Length > 0)
		{
			ContactPoint contact = collision.contacts[0];
			if(Vector3.Dot(contact.normal, Vector3.up) > 0.5)
			{
				jumping = false;
			}
		}
	}

	public void CollectItem(ItemController item){
        items.Add(item);
        LevelController.instance.getQuest().SetValue(item.itemID, true);

        //Debug.Log (item + " collected");
	}

    public void SetLockInputs(bool isLocked)
    {
        controlsLocked = isLocked;
    }

    public void StartGame()
    {
        gameStarted = true;
        cameraDummy.GetComponent<CameraMover>().StartGame();
    }

    public void CameraOnPosition(bool isOnPos)
    {
        cameraOnPos = isOnPos;
    }

    public void StopPlayerMovement()
    {
        rb.velocity = Vector3.zero;
    }

    public void RegisterInteractionTrigger(InteractTrigger trigger)
    {
        interactTriggers.Add(trigger);
    }

    public void UnregisterInteractionTrigger(InteractTrigger trigger)
    {
        if (interactTriggers.Contains(trigger))
            interactTriggers.Remove(trigger);
    }
}