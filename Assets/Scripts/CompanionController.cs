using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* 
 * Kontrolliert alle Aktionen des Companions
 * 
 */

[RequireComponent(typeof(Rigidbody))]
public class CompanionController : MonoBehaviour {

    [Header("Companion Settings")]
    [Tooltip("The speed at which the Companion travels")]
    public float movingSpeed = 2.0f;
    [Tooltip("The max. Distance at which Items can be spotted")]
    public float itemScanRadius = 5.0f;
    [Tooltip("Insert Amy's CompanionTarget-Transform here")]
    public Transform companionTargetAmy;
    private Transform activeTarget;
    private Rigidbody rb;


    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        activeTarget = companionTargetAmy;
    }

    // TODO: Cooler Effekt bei Ein- und Ausblenden des Companions
    public void SetActive(bool state)
    {
        gameObject.SetActive(state);
    }

    private void FixedUpdate()
    {
        activeTarget = ScanForTargets() == null ? activeTarget : ScanForTargets();
        if(rb.velocity.magnitude < movingSpeed)
        {
            rb.AddForce((activeTarget.position - transform.position), ForceMode.Force);
        }
    }


    /* 
     * Scant die Umgebung in einer Sphere mit Radius = itemScanRadius ab und gibt Transform des nahegelegensten Items zurück
     * Falls kein Item im Suchradius gefunden wird, ist Rückgabewert >> null <<
     * 
     */
    private Transform ScanForTargets()
    {
        Collider[] hits = Physics.OverlapSphere(transform.position, itemScanRadius);
        float distance = 5f;
        Collider newTarget = null;
        foreach (Collider c in hits)
        {
            if (c.tag.CompareTo(Constants.TAG_ITEM)==0)
            {
                if (Vector3.Distance(transform.position, c.transform.position) < distance)
                {
                    newTarget = c;
                }
            }
        }
        return newTarget == null ? null : newTarget.transform;
    }
}
