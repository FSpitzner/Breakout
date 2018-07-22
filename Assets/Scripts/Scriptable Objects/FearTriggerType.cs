using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class FearTriggerType : ScriptableObject {

    public float fearPowerPerTick;
    public float ticksPerSecond;

    public float GetTickTime()
    {
        return 1f / ticksPerSecond;
    }
}
