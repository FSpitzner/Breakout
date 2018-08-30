using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelActivator : MonoBehaviour {

    public GameObject obj;

	public void Deactivate()
    {
        obj.SetActive(false);
    }
}
