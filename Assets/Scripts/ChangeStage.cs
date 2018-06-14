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

	//TODO: Überarbeiten um Eingangspunkte für die Türen darzustellen
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
            PlayerController player = PlayerController.instance;
            room1.gameObject.SetActive(true);
            room2.gameObject.SetActive(true);
			door.Open ();
            Debug.Log("Player: " + player);
			if (player.stage == room1) {
				SwitchRooms (2, player);
                CameraToStagePosition(2);
			} else {
				SwitchRooms (1, player);
                CameraToStagePosition(1);
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
                player.stage = room1;
            }
            else
            {
                room1.gameObject.SetActive(false);
                player.stage = room2;
            }
            door.Close();
        });
        CameraToStagePosition(nextRoom);
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
                LeanTween.move(dummy.gameObject, new Vector3(dummy.transform.position.x, nextpos.y, dummy.transform.position.z), moveTime);
                Debug.Log("Camera Moved to: " + new Vector3(dummy.transform.position.x, dummy.transform.position.y, nextpos.z));
                break;
            case 5:
                LeanTween.move(dummy.gameObject, new Vector3(dummy.transform.position.x, nextpos.y, dummy.transform.position.z), moveTime);
                Debug.Log("Camera Moved to: " + new Vector3(dummy.transform.position.x, dummy.transform.position.y, nextpos.z));
                break;
        }
	}
}
