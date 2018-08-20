using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StairTrigger : InteractTrigger {

    public StairsController stairs;

    public override void Interact()
    {
        stairs.StartAnimation(this, player);
    }
}
