using UnityEngine;

public class AnimatorBoolSetter : MonoBehaviour {

    public Animator animator;

    public void SetBoolTrue(string name)
    {
        animator.SetBool(name, true);
    }
}