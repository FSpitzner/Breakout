using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttentionTrigger : Trigger {

    public float cooldownTimer = 2f;
    public AttentionType type;
    public Attention attentionObject;
    private bool isInside;
    private PlayerController player;
    private float timer = 0f;
    private bool onCooldown = false;
    public bool thunderPlaying = false;
    
    private void FixedUpdate()
    {
        if (isInside)
        {
            if (!thunderPlaying)
            {
                if (timer >= cooldownTimer)
                {
                    onCooldown = false;
                    timer = 0f;
                }

                else if (player.velocity >= type.maxSpeed && !onCooldown)
                {
                    attentionObject.ChangeValueByAmount(type.attentionOnThreshold);
                    onCooldown = true;
                }
            }
        }
        if (onCooldown)
        {
            timer += Time.deltaTime;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            isInside = true;
            player = other.attachedRigidbody.GetComponent<PlayerController>();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            isInside = false;
            player = null;
        }
    }

    public void SetThunderPlaying(bool state)
    {
        thunderPlaying = state;
    }
}
