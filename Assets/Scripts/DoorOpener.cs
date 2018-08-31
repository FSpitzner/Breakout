using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using FMODUnity;

public class DoorOpener : MonoBehaviour
{

    [Tooltip("Put Door in here. If this Skript is on the Door itself, let it empty")]
    public GameObject door;
    public RegisterEvent openDoorEvent;
    public Vector3 defaultRotation;
    public Vector3 openRotation;
    public float openTime = 2f;
    private bool opened = false;
    public bool doorIsLocked = false;
    public int keyItemID = 0;
    public int questID = 0;
    [HideInInspector]
    public bool tweening = false;

    [Header("Fear Settings")]
    public bool increaseFear;
    [ConditionalHide("increaseFear", true)]
    public Fear fear;
    [ConditionalHide("increaseFear", true)]
    public float fearAmount;

    [Header("Door Creaks")]
<<<<<<< HEAD

    public StudioEventEmitter FMOD_EVENT_EMIT_CreakOpen;

    public StudioEventEmitter FMOD_EVENT_EMIT_CreakClose;

=======
    /*public StudioEventEmitter FMOD_EVENT_EMIT_reakOpen;
    public StudioEventEmitter FMOD_EVENT_EMIT_reakClose;*/
    public string CREAK_OPEN;
    public string CREAK_CLOSE;
>>>>>>> 837862c11f1ddb3694e36576db9fc1e7dca53e19
    /*

	void OnDrawGizmos(){
		Gizmos.color = Color.blue;
		Gizmos.DrawWireCube (new Vector3(transform.position.x + targetPosOffset.x, transform.position.y + targetPosOffset.y, transform.position.z + targetPosOffset.z), transform.lossyScale);
	}
    */

    public bool CheckDoorIsLocked()
    {
        Debug.Log("Check started");
        if (doorIsLocked)
            Debug.Log("Door is Locked!");
        //LevelController.instance.getQuest().CheckQuestObject(this);
        if (openDoorEvent != null)
        {
            openDoorEvent.GetListeners().ForEach((RegisterEventListener rel) =>
            {
                rel.OnEventRaised(this);
            });
        }
        Debug.Log("Jetzt bin ich schon hier!");
        return doorIsLocked == false ? false : CheckHasKeys();
    }

    private bool CheckHasKeys()
    {
        bool hasKeys = false;
        PlayerController.instance.items.ForEach(delegate (ItemController i)
        {
            if (i.itemID == keyItemID)
            {
                hasKeys = true;
            }
        });
        return !hasKeys;
    }

    public void Open()
    {
        if (!tweening)
        {
            if (increaseFear)
                fear.IncreaseFear(fearAmount);
            //opened: true= open --> door closes; false=closed --> door opens
            tweening = true;
            if (!opened)
            {    //DOORCREAKING
<<<<<<< HEAD

                FMOD_EVENT_EMIT_CreakOpen.Play();
=======
                RuntimeManager.PlayOneShot(CREAK_OPEN);
>>>>>>> 837862c11f1ddb3694e36576db9fc1e7dca53e19
                LeanTween.rotateLocal(door != null ? door : gameObject, openRotation, openTime).setOnComplete(() =>
                {
                    opened = true;
                    tweening = false;
                });
            }
            else
            {
<<<<<<< HEAD
                FMOD_EVENT_EMIT_CreakClose.Play();

=======
                RuntimeManager.PlayOneShot(CREAK_CLOSE);
>>>>>>> 837862c11f1ddb3694e36576db9fc1e7dca53e19
                LeanTween.rotateLocal(door != null ? door : gameObject, defaultRotation, openTime).setOnComplete(() =>
                {
                    opened = false;
                    tweening = false;
                });
            }
        }
    }

    public void Close(ChangeStage stage)
    {
        //DOORCREAKING
        FMOD_EVENT_EMIT_CreakClose.Play();
        tweening = true;
        LeanTween.rotateLocal(door != null ? door : gameObject, defaultRotation, openTime).setOnComplete(() =>
        {
            opened = false;
            tweening = false;
            InformCloser(stage);
        });
    }

    private void InformCloser(ChangeStage stage)
    {
        stage.CompleteRoomSwitch();
    }

    public void UnlockDoor(bool state)
    {
        doorIsLocked = state;
    }
}