using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityControl : MonoBehaviour {

    public Rigidbody rb;

    public void ChangeGravity()
    {
        rb.useGravity = !rb.useGravity;
    }
}
