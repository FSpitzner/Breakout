using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Video;

[RequireComponent(typeof(VideoPlayer))]
public class CutsceneController : MonoBehaviour {

    public UnityEvent startEvent;
    private VideoPlayer vplayer;
    public Animator ani;

    private void Start()
    {
        startEvent.Invoke();
        vplayer = GetComponent<VideoPlayer>();
        vplayer.loopPointReached += CheckOver;
    }

    void CheckOver(VideoPlayer vp)
    {
        ani.SetBool("done", true);
    }
}
