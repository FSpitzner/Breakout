using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StairsController : MonoBehaviour {

    public Animator animator;

    public StageController bottomStage;
    public StairTrigger bottomTrigger;

    public StageController topStage;
    public StairTrigger topTrigger;

    private PlayerController player;
    private StageController releaseStage;

    private bool goingUp, goingDown;
    public float goingDownTime = 17.4f;
    public float goingUpTime = 18.2084f;
    private float timer = 0f;

    private void Update()
    {
        if (goingDown || goingUp)
        {
            timer += Time.deltaTime;
            if(timer >= (goingDown == true ? goingDownTime : goingUpTime))
            {
                ReleasePlayer();
                goingDown = false;
                goingUp = false;
                timer = 0f;
            }
        }
    }

    public void EnableBottomStage()
    {
        bottomStage.SetActive(true);
    }

    public void EnableTopStage()
    {
        topStage.SetActive(true);
    }

    public void DisableButtomStage()
    {
        bottomStage.SetActive(false);
    }

    public void DisableTopStage()
    {
        topStage.SetActive(false);
    }

    public void StartAnimation(StairTrigger trigger, PlayerController player)
    {
        this.player = player;
        
        if(trigger == topTrigger)
        {
            goingUp = true;
            EnableBottomStage();
            animator.SetBool("GoingDown", true);
            releaseStage = bottomStage;
        }
        else
        {
            goingDown = true;
            EnableTopStage();
            animator.SetBool("GoingUp", true);
            releaseStage = topStage;
        }
        player.SetLockInputs(true);
    }

    public void ReleasePlayer()
    {
        player.stage = releaseStage;
        player.SetLockInputs(false);
    }
}
