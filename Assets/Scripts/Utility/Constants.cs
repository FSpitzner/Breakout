using System.Collections;
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
    public static readonly string SOUNDSTATE = "InXOut";

    public static readonly string AMBWINDVOL = "ambwindvol";
    public static readonly string HEARTVOL = "heartvolume";
    public static readonly string AMBRAINVOL = "ambrainvol";
    public static readonly string AMBIENTINGAMEMUSICVOL = "ambmusicvol";
    public static readonly string DREAMWORLDMUSICVOL = "DreamworldMusicVol";
    public static readonly string AMOUNTMENTALILLNESS = "amountMentalIllness";

    public static readonly string MENUVOL = "MenuVol";

    //probably temporary: Variant A = 0; Variant B = 1; Variant C = 2;
    public static readonly string MenuMusic = "WhichMusic";

    public static readonly string HEARTSPEED = "heartspeed";

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
