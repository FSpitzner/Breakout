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

    public Vector3 downPosition;
    public Vector3 upPosition;

    public GameObject cameraDummy;
    private bool goingUp, goingDown;
    public float goingDownTime = 17.4f;
    public float goingUpTime = 18.2084f;
    private float timer = 0f;

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(downPosition, .25f);
        Gizmos.DrawWireSphere(upPosition, .25f);
    }

    private void Update()
    {
        if (goingDown || goingUp)
        {
            timer += Time.deltaTime;
            if(timer >= (goingDown == true ? goingDownTime : goingUpTime))
            {
                if (goingUp)
                {
                    RebuildPlayerObjectUp();
                }
                else
                {
                    RebuildPlayerObjectDown();
                }
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
            player.transform.eulerAngles = new Vector3(0, -90, 0);
            player.transform.position = downPosition; // Hier die Endposition beim herunterlaufen einfügen
            goingDown = true;
            EnableBottomStage();
            animator.SetBool("GoingDown", true);
            LeanTween.move(cameraDummy, new Vector3(cameraDummy.transform.position.x, 1.041f, cameraDummy.transform.position.z), goingDownTime);
            releaseStage = bottomStage;
        }
        else
        {
            player.transform.eulerAngles = new Vector3(0, 90, 0);
            goingUp = true;
            EnableTopStage();
            animator.SetBool("GoingUp", true);
            LeanTween.move(cameraDummy, new Vector3(cameraDummy.transform.position.x, 7.52f, cameraDummy.transform.position.z), goingUpTime);
            releaseStage = topStage;
        }
        player.SetLockInputs(true);
    }

    public void ReleasePlayer()
    {
        player.stage = releaseStage;
        player.SetLockInputs(false);
    }

    private void RebuildPlayerObjectUp()
    {
        Debug.Log("Rebuilding Player Up");
        player.transform.position = upPosition;// Hier die Endposition beim hochlaufen einfügen
        player.ResetPlayerMesh();
        player.ani.transform.localEulerAngles = new Vector3(0, 0, 0);
    }

    private void RebuildPlayerObjectDown()
    {
        Debug.Log("Rebuilding Player Down");
        player.transform.eulerAngles = new Vector3(0, -90, 0);
        player.ResetPlayerMesh();
    }
}
