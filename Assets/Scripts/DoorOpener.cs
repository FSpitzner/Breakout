using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpener : MonoBehaviour {

    [Tooltip("Put Door in here. If this Skript is on the Door itself, let it empty")]
    public GameObject door;
    public Vector3 defaultRotation;
	public Vector3 openRotation;
	public float openTime = 2f;
	private bool opened = false;
	[HideInInspector]
	public bool tweening = false;
    /*
	void OnDrawGizmos(){
		
		Gizmos.color = Color.blue;
		Gizmos.DrawWireCube (new Vector3(transform.position.x + targetPosOffset.x, transform.position.y + targetPosOffset.y, transform.position.z + targetPosOffset.z), transform.lossyScale);
	}
    */
	void Start(){
		defaultRotation = door != null ? door.transform.localEulerAngles : transform.localEulerAngles;
	}

	public void Open(){
		if (!tweening) {
			tweening = true;
			if (!opened)
				LeanTween.rotateLocal (door != null ? door : gameObject, openRotation, openTime).setOnComplete (() => {
					opened = true;
					tweening = false;
				});
			else
				LeanTween.rotateLocal (door != null ? door : gameObject, defaultRotation, openTime).setOnComplete (() => {
					opened = false;
					tweening = false;
				});
		}
	}

    public void Close()
    {
        tweening = true;
        LeanTween.rotateLocal(door != null ? door : gameObject, defaultRotation, openTime).setOnComplete(() =>
        {
            opened = false;
            tweening = false;
        });
    }
}