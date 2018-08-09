using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightTrigger : InteractTrigger {

    public GameObject light;

    public override void Interact()
    {
        light.SetActive(!light.activeSelf);
    }
}
