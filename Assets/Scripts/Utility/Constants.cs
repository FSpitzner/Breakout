﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Constants{

    #region Tags
    public static readonly string TAG_PLAYER = "Player";
    public static readonly string TAG_ITEM = "Item";

    #endregion

    #region Layers

    #endregion

    #region GameObject Names
    public static readonly string NAME_COMPANION_TARGET = "CompanionTarget";
    #endregion

    #region FMOD Parameter Names
    public static readonly string THUNDERID = "ThunderID2Play";

    #endregion
}

// TODO: NICETOHAVE
/*
[CustomEditor(typeof(Constants))]
public class ConstantsEditor : Editor
{
    List<string> tags;
    Constants script;
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        script = (Constants)target.;
    }
}
*/
