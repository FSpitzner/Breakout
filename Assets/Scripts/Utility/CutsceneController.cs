using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

[RequireComponent(typeof(VideoPlayer))]
public class CutsceneController : MonoBehaviour {
    private VideoPlayer vplayer;

    private void Start()
    {
        vplayer = GetComponent<VideoPlayer>();
        vplayer.loopPointReached += CheckOver;
    }

    void CheckOver(VideoPlayer vp)
    {
        gameObject.SetActive(false);
    }

}
