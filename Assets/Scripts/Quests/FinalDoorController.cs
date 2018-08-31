using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalDoorController : MonoBehaviour {

    public BoxCollider finalDoorCollider;
    private bool gotBread, gotFlashlight;

    public void SetBread()
    {
        gotBread = true;
        CheckDoor();
    }

    public void SetFlashlight()
    {
        gotFlashlight = true;
        CheckDoor();
    }

    private void CheckDoor()
    {
        if(gotBread && gotFlashlight)
        {
            finalDoorCollider.enabled = true;
        }
    }
}
