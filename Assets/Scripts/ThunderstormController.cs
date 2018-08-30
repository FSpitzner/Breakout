using UnityEditor;
using UnityEngine;
using FMODUnity;
using System.Collections.Generic;
using System.Collections;

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

    public Thunder[] thunders;

   // public ThunderType smallThunders;
   // public ThunderType bigThunders;

    public StudioEventEmitter see;
    public PlayerController player;
    public Fear fear;

    private int i = 0;
    private float thunderEventTimer = -.1f;
    public GameEvent thunderStartEvent;
    public GameEvent thunderStopEvent;

    private void Update()
    {
        if(thunderEventTimer > 0)
        {
            thunderEventTimer -= Time.deltaTime;
            if(thunderEventTimer <= 0)
            {
                thunderStopEvent.Raise();
            }
        }
    }

    public void StartThunderstorm()
    {
        PlayThunder();
    }

    public void PlayThunder()
    {
        if (thunderstormActive)
        {
            PlayRandom();
            Invoke("PlayThunder", Random.Range(thunderInterval.minValue, thunderInterval.maxValue));
        }
    }

    public void PlayRandom()
    {
        int randomThunderID = Random.Range(0, thunders.Length-1);
        Debug.Log("Playing Thunder " + randomThunderID);
        lightAni.SetInteger("ThunderID", randomThunderID);
        StartCoroutine(PlaySound(Random.Range(thunderstormDistance.minValue, thunderstormDistance.maxValue), randomThunderID, (float)player.stage.soundState));
        fear.IncreaseFear(player.stage.soundState == 0 ? thunders[randomThunderID].FearSoundstate0 : thunders[randomThunderID].FearSoundstate1);
        /*see.SetParameter(Constants.THUNDERID, (float)randomThunderID);
        see.SetParameter(Constants.SOUNDSTATE, player.stage.soundState);
        see.Play();*/
    }

    public void PlaySpecific(int id)
    {
        lightAni.SetInteger("ThunderID", id);
        Debug.Log("Playing Thunder " + id);
        StartCoroutine(PlaySound(Random.Range(thunderstormDistance.minValue, thunderstormDistance.maxValue),id, (float)player.stage.soundState));
        fear.IncreaseFear(player.stage.soundState == 0 ? thunders[id].FearSoundstate0 : thunders[id].FearSoundstate1);
        /*see.SetParameter(Constants.THUNDERID, (float)id);
        see.SetParameter(Constants.SOUNDSTATE, player.stage.soundState);
        see.Play();*/
        if (i<thunders.Length-1)
            i++;
        else
        {
            i = 0;
        }
    }

    private IEnumerator PlaySound(float delay, float id, float soundstate)
    {
        yield return new WaitForSeconds(delay);
        thunderStartEvent.Raise();
        thunderEventTimer = thunders[(int)id].AttentionTime;
        see.SetParameter(Constants.THUNDERID, id);
        see.SetParameter(Constants.SOUNDSTATE, soundstate);
        see.Play();
    }
}