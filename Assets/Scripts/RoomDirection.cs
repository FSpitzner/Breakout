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

[CustomEditor(typeof(RoomDirection))]
[CanEditMultipleObjects]
public class RoomDirectionEditor : Editor{
	bool left, right, infront, behind, aboth, below;
	RoomDirection script;
	public override void OnInspectorGUI ()
	{
        DrawDefaultInspector ();
		script = (RoomDirection)target;

        left = script.left;
        right = script.right;
        infront = script.infront;
        behind = script.behind;
        aboth = script.aboth;
        below = script.below;

		EditorGUILayout.LabelField ("Room 2's direction from Room 1:");

		left = EditorGUILayout.Toggle ("left", left);
		if (left) {
			script.SetValues (true, false, false, false, false, false);
			UpdateValues ();
		}
		right = EditorGUILayout.Toggle ("right", right);
		if (right) {
			script.SetValues (false, true, false, false, false, false);
			UpdateValues ();
		}
		infront = EditorGUILayout.Toggle ("infront", infront);
		if (infront) {
			script.SetValues (false, false, true, false, false, false);
			UpdateValues ();
		}
		behind = EditorGUILayout.Toggle ("behind", behind);
		if (behind) {
			script.SetValues (false, false, false, true, false, false);
			UpdateValues ();
		}
		aboth = EditorGUILayout.Toggle ("aboth", aboth);
		if (aboth) {
			script.SetValues (false, false, false, false, true, false);
			UpdateValues ();
		}
		below = EditorGUILayout.Toggle ("below", below);
		if (below) {
			script.SetValues (false, false, false, false, false, true);
			UpdateValues ();
		}
		if (!left && !right && !infront && !behind && !aboth && !below) {
			left = true;
		}
	}
	void UpdateValues(){
		left = script.left;
		right = script.right;
		infront = script.infront;
		behind = script.behind;
		aboth = script.aboth;
		below = script.below;
	}
}
