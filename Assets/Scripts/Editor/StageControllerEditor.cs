using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CanEditMultipleObjects]
[CustomEditor(typeof(StageController))]
public class StageControllerEditor : Editor
{
    Material[] materials;
    StageController stage;

    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        stage = (StageController)target;
        GUILayout.Space(20);
        if (GUILayout.Button(new GUIContent("Fill Materials")))
        {
            stage.FillMaterials();
        }
    }

}
