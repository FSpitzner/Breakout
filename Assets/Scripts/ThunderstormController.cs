using UnityEditor;
using UnityEngine;
using FMODUnity;

[RequireComponent(typeof(StudioEventEmitter))]
public class ThunderstormController : MonoBehaviour {

    public bool thunderstormActive = true;

    [MinMaxRange(2f, 20f)]
    public RangedFloat thunderInterval;

    [Tooltip("Delay between Lightning and Thunder")]
    [MinMaxRange(0f, 3f)]
    public RangedFloat thunderstormDistance;

    public ThunderType smallThunders;
    public ThunderType bigThunders;

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
                    smallThunders.PlayRandom(see, player.stage);
                    break;
                case 1:
                    bigThunders.PlayRandom(see, player.stage);
                    break;
            }
            Invoke("PlayThunder", Random.Range(thunderInterval.minValue, thunderInterval.maxValue));
        }
    }
}