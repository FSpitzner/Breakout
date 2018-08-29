using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[Serializable]
public class Thunder
{
    public int ID;
    public float FearAmount;
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
        var fearRect = new Rect(position.x + 45, position.y, 50, position.height);
        var attentionDelayRect = new Rect(position.x + 100, position.y, 40, position.height);
        var attentionTimeRect = new Rect(position.x + 145, position.y, 40, position.height);

        EditorGUI.PropertyField(idRect, property.FindPropertyRelative("ID"), GUIContent.none);
        EditorGUI.PropertyField(fearRect, property.FindPropertyRelative("FearAmount"), GUIContent.none);
        EditorGUI.PropertyField(attentionDelayRect, property.FindPropertyRelative("AttentionDelay"), GUIContent.none);
        EditorGUI.PropertyField(attentionTimeRect, property.FindPropertyRelative("AttentionTime"), GUIContent.none);

        EditorGUI.indentLevel = indent;
        EditorGUI.EndProperty();
    }
}