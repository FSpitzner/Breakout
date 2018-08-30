using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BreakoutUtility;

/* 
 * Kontrolliert alle Aktionen des Companions
 * 
 */

[RequireComponent(typeof(Rigidbody))]
public class CompanionController : MonoBehaviour {

    [Header("Companion Settings")]
    [Tooltip("The max speed at which the Companion travels")]
    public float maxMovingSpeed = 2.0f;
    [SerializeField]
    private float movingSpeed;
    [Tooltip("The max. Distance at which Items can be spotted")]
    public float itemScanRadius = 5.0f;
    [Tooltip("Max. Distance between Amy and her Companion")]
    public float maxDistance = 6.0f;
    [Tooltip("Min. Distance the Companion should have to its Target")]
    public float minDistance = 0.1f;
    [Tooltip("")]
    public float breakDistance = 0.5f;
    [Tooltip("Force that gets applied to the Companion for Movements")]
    public float forcePower = 0.02f;
    [Tooltip("Insert Amy's CompanionTarget-Transform here")]
    public Transform companionTargetAmy;
    public Transform activeTarget;
    public Vector3 targetVector;
    private Rigidbody rb;
    private float defaultDrag;
    private Vector3 curVelocity;


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

    private void Update()
    {
        /* float distance = Vector3.Distance(activeTarget.position, transform.position);
         if (distance < breakDistance)
         {
             movingSpeed = maxMovingSpeed - ((maxMovingSpeed / 2) * (1f - (LocalMaths.PercentOf(distance, maxDistance) / 100f)));
             Debug.Log(LocalMaths.PercentOf(distance, maxDistance));
         }
         else
             movingSpeed = maxMovingSpeed;
             */
        transform.LookAt(activeTarget);
        transform.position = Vector3.SmoothDamp(transform.position, activeTarget.position, ref curVelocity, 0.5f, maxMovingSpeed);
    }
    
    private void FixedUpdate()
    {
        activeTarget = ScanForTargets();
        {/*
        //Verwendung von Drag noch nicht Optimal
        if (Vector3.Distance(activeTarget.position, transform.position) < minDistance)
        {
            if (rb.velocity.magnitude > 0.01f)
            {
                rb.drag += 1f;
            }
        }
        else if (Vector3.Distance(activeTarget.position, transform.position) < breakDistance)
        {
            rb.drag += .5f;
        }
        else
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
        }*/
        }
    }


    /* 
     * Scant die Umgebung in einer Sphere mit Radius = itemScanRadius ab und gibt Transform des nahegelegensten Items zurück
     * Falls kein Item im Suchradius gefunden wird, ist Rückgabewert >> null <<
     * 
     */
    private Transform ScanForTargets()
    {
        Collider[] hits = Physics.OverlapSphere(PlayerController.instance.transform.position, itemScanRadius);
        float distance = itemScanRadius;
        Transform newTarget = null;
        foreach (Collider c in hits)
        {
            if (c.tag.CompareTo(Constants.TAG_ITEM)==0)
            {
                if (Vector3.Distance(transform.position, c.transform.position) < distance)
                {
                    newTarget = c.transform.Find(Constants.NAME_COMPANION_TARGET);
                }
            }
        }
        if(Vector3.Distance(transform.position, companionTargetAmy.position) > maxDistance)
        {
            newTarget = null;
        }
        return newTarget == null ? companionTargetAmy : newTarget;
    }
}
