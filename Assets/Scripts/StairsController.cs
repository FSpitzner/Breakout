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
        if(trigger == bottomTrigger)
        {
            animator.SetBool("GoingDown", true);
            releaseStage = bottomStage;
        }
        else
        {
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
