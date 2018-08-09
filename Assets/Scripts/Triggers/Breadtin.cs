using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Breadtin : InteractTrigger {
    public Collider breadTinTrigger;
    public Collider breadtrigger;

    public override void Interact()
    {
        breadTinTrigger.enabled = false;
        breadtrigger.enabled = true;
    }
}
