using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class RoomDirection : MonoBehaviour{
	
	[HideInInspector]
	public bool left = true;
	[HideInInspector]
	public bool right = false;
	[HideInInspector]
	public bool infront = false;
	[HideInInspector]
	public bool behind = false;
	[HideInInspector]
	public bool aboth = false;
	[HideInInspector]
	public bool below = false;

	public void SetValues(bool left, bool right, bool infront, bool behind, bool aboth, bool below){
		this.left = left;
		this.right = right;
		this.infront = infront;
		this.behind = behind;
		this.aboth = aboth;
		this.below = below;
	}
    public int GetState()
    {
        if (left)
            return 0;
        if (right)
            return 1;
        if (infront)
            return 2;
        if (behind)
            return 3;
        if (aboth)
            return 4;
        else
            return 5;
    }
}


