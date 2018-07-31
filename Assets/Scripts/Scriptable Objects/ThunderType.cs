using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

[CreateAssetMenu(menuName ="Scriptable Objects/Thunder Type")]
public class ThunderType : ScriptableObject {

    public List<Thunder> thunders;

    public void PlayRandom(StudioEventEmitter fsee, StageController stage)
    {
        fsee.SetParameter(Constants.THUNDERID, (float)thunders[Random.Range(0, thunders.Count)].ID);
        fsee.SetParameter(Constants.SOUNDSTATE, stage.soundState);
        fsee.Play();
    }

    public void PlaySpecific(StudioEventEmitter fsee, StageController stage,int id)
    {
        fsee.SetParameter(Constants.THUNDERID, (float)id);
        fsee.SetParameter(Constants.SOUNDSTATE, stage.soundState);
        fsee.Play();
    }
}
