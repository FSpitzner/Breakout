using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(RoomDirection))]
public class ChangeStage : InteractTrigger {

	[Header("Room Settings")]
	public StageController room1;
	public Vector3 room1StartPoint;
    public StageController[] room1Objects;
	public StageController room2;
	public Vector3 room2StartPoint;
    public StageController[] room2Objects;
    public StageController[] sharedObjects;
	private RoomDirection room2PosFromRoom1;
	public DoorOpener door;
    public float playerRoomSwitchSpeed = 2f;
    private int nextRoom;
    public bool looksLikeShit;
    [ConditionalHide("looksLikeShit", true)]
    public GameObject fadeoutPanel;

	[Header("Camera Settings")]
	public Vector3 room1CameraPos;
    public Vector3 room2CameraPos;
	public float moveTime;
	public CameraMover dummy;

	//TODO: Überarbeiten um Eingangspunkte für die Türen darzustellen
    void OnDrawGizmos(){
		Gizmos.color = Color.magenta;
		Gizmos.DrawWireSphere (room1StartPoint, 0.5f);
		Gizmos.DrawWireSphere (room2StartPoint, 0.5f);
	}
    
	void Start(){
		room2PosFromRoom1 = transform.GetComponent<RoomDirection> ();
	}

	public override void Interact(){
        Debug.Log("Interacting");
        if (looksLikeShit)
        {
            player.gameObject.GetComponent<GravityControl>().ChangeGravity();
            fadeoutPanel.SetActive(true);
            player.playerMesh.SetActive(false);
            foreach (StageController sc in room1Objects)
            {
                if (!sc.isActive)
                {
                    sc.SetActive(true);
                }
            }
            foreach (StageController sc in room2Objects)
            {
                if (!sc.isActive)
                {
                    sc.SetActive(true);
                }
            }
            if (player.stage == room1)
            {
                nextRoom = 2;
                SwitchRooms(player);
            }
            else
            {
                nextRoom = 1;
                SwitchRooms(player);
            }
        }
        else if (!door.tweening && !door.CheckDoorIsLocked()) {
            Debug.Log("Hier bin ich");
            foreach(StageController sc in room1Objects)
            {
                if (!sc.isActive)
                {
                    sc.SetActive(true);
                }
            }
            foreach(StageController sc in room2Objects)
            {
                if (!sc.isActive)
                {
                    sc.SetActive(true);
                }
            }
            door.Open();
			if (player.stage == room1) {
                nextRoom = 2;
                SwitchRooms (player);
                //CameraToStagePosition(2);
			} else {
                nextRoom = 1;
				SwitchRooms (player);
                //CameraToStagePosition(1);
			}
            
        }
    }

	private void SwitchRooms(PlayerController player){
        player.SetLockInputs(true);
        player.transform.position = nextRoom == 1 ? room2StartPoint : room1StartPoint;
        player.StopPlayerMovement();
        Vector3 target = nextRoom == 1 ? room1StartPoint : room2StartPoint;
        if(!looksLikeShit)
            player.transform.LookAt(target);
        player.walkingThroughDoor = true;
        LTSeq seq = LeanTween.sequence();
        if(!looksLikeShit)
            seq.append(door.openTime);
        seq.append(() => {
            CameraToStagePosition(nextRoom);
            player.velocity = 1.5f;
        });
        seq.append(
            LeanTween.move(player.gameObject, target, playerRoomSwitchSpeed).setOnComplete(() =>
            {
                if (!looksLikeShit)
                {
                    door.Close(this);
                }
                else
                {
                    CompleteRoomSwitch();
                }
                player.velocity = 0f;
                player.walkingThroughDoor = false;
            })
        );
    }

    public void CompleteRoomSwitch()
    {
        player.playerMesh.SetActive(true);
        player.SetLockInputs(false);
        if (nextRoom == 1)
        {
            foreach (StageController sc in room2Objects)
            {
                sc.SetActive(false);
            }
            player.stage = room1;
        }
        else
        {
            foreach (StageController sc in room1Objects)
            {
                sc.SetActive(false);
            }
            player.stage = room2;
        }
    }


	private void CameraToStagePosition(int nextRoom){
        Debug.Log("Moving Camera!");
        Vector3 nextpos = nextRoom == 1 ? room1CameraPos : room2CameraPos;
        switch (room2PosFromRoom1.GetState())
        {
            case 0:
                LeanTween.move(dummy.gameObject, new Vector3(nextpos.x, dummy.transform.position.y, dummy.transform.position.z), moveTime);
                Debug.Log("Camera Moved to: " + new Vector3(nextpos.x, dummy.transform.position.y, dummy.transform.position.z));
                break;
            case 1:
                LeanTween.move(dummy.gameObject, new Vector3(nextpos.x, dummy.transform.position.y, dummy.transform.position.z), moveTime);
                Debug.Log("Camera Moved to: " + new Vector3(nextpos.x, dummy.transform.position.y, dummy.transform.position.z));
                break;
            case 2:
                LeanTween.move(dummy.gameObject, new Vector3(dummy.transform.position.x, dummy.transform.position.y, nextpos.z), moveTime);
                Debug.Log("Camera Moved to: " + new Vector3(dummy.transform.position.x, nextpos.y, dummy.transform.position.z));
                break;
            case 3:
                LeanTween.move(dummy.gameObject, new Vector3(dummy.transform.position.x, dummy.transform.position.y, nextpos.z), moveTime);
                Debug.Log("Camera Moved to: " + new Vector3(dummy.transform.position.x, nextpos.y, dummy.transform.position.z));
                break;
            case 4:
                LeanTween.move(dummy.gameObject, new Vector3(nextpos.x, nextpos.y, nextpos.z), moveTime);
                Debug.Log("Camera Moved to: " + new Vector3(nextpos.x, nextpos.y, nextpos.z));
                break;
            case 5:
                LeanTween.move(dummy.gameObject, new Vector3(nextpos.x, nextpos.y, nextpos.z), moveTime);
                Debug.Log("Camera Moved to: " + new Vector3(nextpos.x, nextpos.y, nextpos.z));
                break;
        }
	}
}
