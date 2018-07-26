using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

[CreateAssetMenu(menuName ="Scriptable Objects/Thunder Type")]
public class ThunderType : ScriptableObject {

    public List<Thunder> thunders;

    public void PlayRandom(StudioEventEmitter fsee)
    {
        fsee.SetParameter(Constants.THUNDERID, (float)thunders[Random.Range(0, thunders.Count)].ID);
        fsee.SetParameter("InXOut", 1f //TODO: Hier StageController Soundstate einfügen
            );
        fsee.Play();
    }

    public void PlaySpecific(StudioEventEmitter fsee, int id)
    {
        fsee.SetParameter(Constants.THUNDERID, (float)id);
        fsee.Play();
    }
}
