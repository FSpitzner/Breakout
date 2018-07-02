using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


[RequireComponent(typeof(Rigidbody))]

public class PlayerController : MonoBehaviour {
    public static PlayerController instance;

	[Header("Player Statistics")]

	public float maxMoveSpeed;
	public float maxCrouchSpeed;
	public float jumpPower;
	public float maxRunSpeed;
	public int fear;

	private int moveState = 1;
	private Rigidbody rb;
	private bool jumping = false;

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

	//LevelSettings
	//[HideInInspector]
	public StageController stage;
    private bool controlsLocked = false;
    private bool gameStarted = false;
    private bool cameraOnPos = false;

    private void Awake()
    {
        instance = this;
    }
    void Start(){
		rb = this.GetComponent<Rigidbody> ();
		rb.interpolation = RigidbodyInterpolation.Interpolate;
        Debug.Log("Player: " + this);
        Debug.Log("Stage Registered: " + stage);
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
                LevelController.instance.UseTriggerObject();
            }
        }
	}

	void FixedUpdate(){
        if (gameStarted)
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
                if (Input.GetKeyDown(crouchKey))
                {
                    if (moveState != 0)
                        moveState = 0;
                    else
                        moveState = 1;
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
	}

	private void MovementControl(int forcePower){
		float walkingHorizontal = Input.GetAxis ("Horizontal");
		float walkingVertical = Input.GetAxis ("Vertical");
		rb.AddForce (new Vector3 (walkingHorizontal, 0f, walkingVertical) * forcePower, ForceMode.Force);
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
		Debug.Log (item + " collected");
	}

    public void SetLockInputs(bool isLocked)
    {
        controlsLocked = isLocked;
    }

    public void StartGame()
    {
        gameStarted = true;
        LeanTween.moveLocal(GameObject.FindGameObjectWithTag("MainCamera"), new Vector3(0,3,-10), 1f).setEase(LeanTweenType.easeInOutSine);
        LeanTween.rotate(GameObject.FindGameObjectWithTag("MainCamera"), Quaternion.LookRotation(transform.position - new Vector3(cameraDummy.position.x, cameraDummy.position.y+3, cameraDummy.position.z-10)).eulerAngles, 1f).setEase(LeanTweenType.easeInOutSine).setOnComplete(() => {
            cameraOnPos = true;
            LevelController.instance.InformCameraPointing();
        });

       /* Vector3 startpoint = LevelController.instance.GetGameMenuController().cameraMenuPos;
        Vector3 endpoint = new Vector3(cameraDummy.transform.position.x, cameraDummy.transform.position.y, cameraDummy.transform.position.z);
        LeanTween.moveSpline(cameraDummy.gameObject, new Vector3[]
        {
            //Points to move along
            //Amy moves around 1.2f to the left!
            startpoint,
            GetPoint(startpoint, endpoint, 0.25f),
            GetPoint(startpoint, endpoint, 0.5f),
            GetPoint(startpoint, endpoint, 0.75f),
            endpoint,
            endpoint
        }, 1f).setEase(LeanTweenType.easeInOutSine).setOnComplete(()=>
        {
            cameraOnPos = true;
        }); */
    }

    private Vector3 GetPoint(Vector3 start, Vector3 end, float posOnPath)
    {
        Vector3 endpoint;
        endpoint = Vector3.Lerp(start, end, posOnPath);
        if(posOnPath <= 0.25f)
        {
            endpoint.x += 0.75f;
        }
        else if(posOnPath <= 0.5f)
        {
            endpoint.x += 0.5f;
        }
        else if(posOnPath <= 0.75f)
        {
            endpoint.x += 0.25f;
        }
        return endpoint;
    }
}