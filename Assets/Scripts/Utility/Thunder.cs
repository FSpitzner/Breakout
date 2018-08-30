using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[Serializable]
public class Thunder
{
    public int ID;
    public float FearSoundstate0;
    public float FearSoundstate1;
    public float AttentionDelay;
    public float AttentionTime;
}

[CustomPropertyDrawer(typeof(Thunder))]
public class ThunderEditor : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        EditorGUI.BeginProperty(position, label, property);
        position = EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), label);

        var indent = EditorGUI.indentLevel;
        EditorGUI.indentLevel = 0;

        var idRect = new Rect(position.x + 10, position.y, 30, position.height);
        var fearRect = new Rect(position.x + 45, position.y, 35, position.height);
        var fear1Rect = new Rect(position.x + 85, position.y, 35, position.height);
        var attentionDelayRect = new Rect(position.x + 125, position.y, 40, position.height);
        var attentionTimeRect = new Rect(position.x + 170, position.y, 40, position.height);

        EditorGUI.PropertyField(idRect, property.FindPropertyRelative("ID"), GUIContent.none);
        EditorGUI.PropertyField(fearRect, property.FindPropertyRelative("FearSoundstate0"), GUIContent.none);
        EditorGUI.PropertyField(fear1Rect, property.FindPropertyRelative("FearSoundstate1"), GUIContent.none);
        EditorGUI.PropertyField(attentionDelayRect, property.FindPropertyRelative("AttentionDelay"), GUIContent.none);
        EditorGUI.PropertyField(attentionTimeRect, property.FindPropertyRelative("AttentionTime"), GUIContent.none);

        EditorGUI.indentLevel = indent;
        EditorGUI.EndProperty();
    }
}