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
    [Tooltip("The max speed at which the Companion travels")]
    public float maxMovingSpeed = 2.0f;
    private float movingSpeed;
    [Tooltip("The max. Distance at which Items can be spotted")]
    public float itemScanRadius = 5.0f;
    [Tooltip("Max. Distance between Amy and her Companion")]
    public float maxDistance = 6.0f;
    [Tooltip("Min. Distance the Companion should have to its Target")]
    public float minDistance = 0.1f;
    [Tooltip("")]
    public float breakDistance = 0.3f;
    [Tooltip("Force that gets applied to the Companion for Movements")]
    public float forcePower = 0.02f;
    [Tooltip("Insert Amy's CompanionTarget-Transform here")]
    public Transform companionTargetAmy;
    public Transform activeTarget;
    public Vector3 targetVector;
    private Rigidbody rb;
    private float defaultDrag;


    private void Start()
    {
        movingSpeed = maxMovingSpeed;
        rb = GetComponent<Rigidbody>();
        defaultDrag = rb.drag;
        activeTarget = companionTargetAmy;
    }

    // TODO: Cooler Effekt bei Ein- und Ausblenden des Companions
    public void SetActive(bool state)
    {
        gameObject.SetActive(state);
    }

    private void FixedUpdate()
    {
        activeTarget = ScanForTargets();
        float distance = Vector3.Distance(activeTarget.position, transform.position);
        movingSpeed = maxMovingSpeed - (maxMovingSpeed/2 - );

        /*if (Vector3.Distance(activeTarget.position, transform.position) < minDistance)
        {
            if (rb.velocity.magnitude > 0.01f)
            {
                rb.drag += 1f;
            }
        }
        else if (Vector3.Distance(activeTarget.position, transform.position) < minDistance + 0.2f)
        {
            rb.drag += .5f;
        }
        else */
        {
            rb.drag = defaultDrag;
            if (rb.velocity.magnitude <= movingSpeed)
            {
                targetVector = activeTarget.position - transform.position;
                rb.AddForce(targetVector * forcePower, ForceMode.Force);
            }
            if (rb.velocity.magnitude > movingSpeed)
            {
                rb.velocity = rb.velocity.normalized * movingSpeed;
            }
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
        if(Vector3.Distance(transform.position, companionTargetAmy.position) > maxDistance)
        {

        }
        return newTarget == null ? companionTargetAmy : newTarget.transform;
    }
}
