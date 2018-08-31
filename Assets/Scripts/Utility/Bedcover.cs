using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bedcover : MonoBehaviour {

    public Animator ani;
	
    public void BedCover()
    {
        ani.SetBool("start", true);
    }

}
