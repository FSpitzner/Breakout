using UnityEditor;
using UnityEngine;
using FMODUnity;
using System.Collections.Generic;

[RequireComponent(typeof(StudioEventEmitter))]
public class ThunderstormController : MonoBehaviour {

    public bool thunderstormActive = true;
    public Animator lightAni;

    [Tooltip("Time between Thunders")]
    [MinMaxRange(2f, 20f)]
    public RangedFloat thunderInterval;

    [Tooltip("Delay between Lightning and Thunder in seconds")]
    [MinMaxRange(0f, 3f)]
    public RangedFloat thunderstormDistance;

    public int thunderAmount;

   // public ThunderType smallThunders;
   // public ThunderType bigThunders;

    public StudioEventEmitter see;
    public PlayerController player;

    public void StartThunderstorm()
    {
        PlayThunder();
    }

    public void PlayThunder()
    {
        if (thunderstormActive)
        {
            int nextthunder = Random.Range(0, 1);
            switch (nextthunder)
            {
                case 0:
                    PlayRandom();
                    break;
                case 1:
                    PlayRandom();
                    break;
            }
            Invoke("PlayThunder", Random.Range(thunderInterval.minValue, thunderInterval.maxValue));
        }
    }

    public void PlayRandom()
    {
        int randomThunderID = Random.Range(1, thunderAmount);
        Debug.Log("Playing Thunder " + randomThunderID);
        lightAni.SetInteger("ThunderID", randomThunderID);
        see.SetParameter(Constants.THUNDERID, (float)randomThunderID);
        see.SetParameter(Constants.SOUNDSTATE, player.stage.soundState);
        see.Play();
    }

    public void PlaySpecific(int id)
    {
        lightAni.SetInteger("ThunderID", id);
        see.SetParameter(Constants.THUNDERID, (float)id);
        see.SetParameter(Constants.SOUNDSTATE, player.stage.soundState);
        see.Play();
    }
}