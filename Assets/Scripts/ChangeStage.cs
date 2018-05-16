using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(RoomDirection))]
public class ChangeStage : InteractTrigger {

	[Header("Room Settings")]
	public StageController room1;
	public Vector3 room1StartPoint;
	public StageController room2;
	public Vector3 room2StartPoint;
	private RoomDirection room2PosFromRoom1;
	public DoorOpener door;
    public float playerRoomSwitchSpeed = 2f;

	[Header("Camera Settings")]
	public Vector3 room1CameraPos;
    public Vector3 room2CameraPos;
	public float moveTime;
	public CameraMover dummy;

	void OnDrawGizmos(){
		Gizmos.color = Color.magenta;
		Gizmos.DrawWireSphere (room1StartPoint, 0.5f);
		Gizmos.DrawWireSphere (room2StartPoint, 0.5f);
	}

	void Start(){
        triggerType = "Interact";
		room2PosFromRoom1 = transform.GetComponent<RoomDirection> ();
	}

	public override void Interact(){
        Debug.Log("Interacting");
		if (!door.tweening) {
			PlayerController player = GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerController> ();
            room1.gameObject.SetActive(true);
            room2.gameObject.SetActive(true);
			door.Open ();

			if (player.stage == room1) {
				SwitchRooms (2, player);
			} else {
				SwitchRooms (1, player);
			}
		}
	}

	private void SwitchRooms(int nextRoom, PlayerController player){
        player.SetLockInputs(true);
        player.transform.position = nextRoom == 1 ? room2StartPoint : room1StartPoint;
        LeanTween.move(player.gameObject, nextRoom == 1 ? room1StartPoint : room2StartPoint, playerRoomSwitchSpeed).setOnComplete(() =>
        {
            player.SetLockInputs(false);
            if (nextRoom == 1)
            {
                room2.gameObject.SetActive(false);
            }
            else
            {
                room1.gameObject.SetActive(false);
            }
        }
        );
	}

	private void CameraToStagePosition(){
		
	}
}
