using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(LevelController))]
[CanEditMultipleObjects]
public class LevelControllerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        LevelController script = (LevelController)target;
        if (script.thunderstorm)
        {
            script.thunderstormController =
                EditorGUILayout.ObjectField("Thunderstorm Controller", script.thunderstormController, typeof(ThunderstormController), true) as ThunderstormController;
        }
        else
        {
            script.thunderstormController = null;
        }
    }
}
