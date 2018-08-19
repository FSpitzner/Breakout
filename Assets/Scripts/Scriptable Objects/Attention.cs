using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects/Attention")]
public class Attention : ScriptableObject {

    public float value;
    public float threshold;
    public GameEvent thresholdEvent;

    public void ChangeValueByAmount(float amount)
    {
        value += amount;
        CheckThreshold();
    }

    private void CheckThreshold()
    {
        if(value >= threshold)
        {
            thresholdEvent.Raise();
        }
    }
}