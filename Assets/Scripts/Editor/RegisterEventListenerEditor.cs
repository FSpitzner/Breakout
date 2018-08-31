using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(RegisterEventListener))]
public class RegisterEventListenerEditor : Editor
{
    RegisterEventListener script;
    MethodInfo[] methods;
    BindingFlags flag = BindingFlags.Public;
    public override void OnInspectorGUI()
    {
        script = (RegisterEventListener)target;
        script.Event = EditorGUILayout.ObjectField("Event", script.Event, typeof(RegisterEvent), true) as RegisterEvent;
        script.respondWithMethode = EditorGUILayout.Toggle("Respond with Methode", script.respondWithMethode);
        if (script.respondWithMethode)
        {
            script.target = EditorGUILayout.ObjectField("Target", script.target, typeof(MonoBehaviour), true) as MonoBehaviour;
            //EditorGUILayout.IntField(script.methodeID);
            if (script.target != null)
            {
                methods = script.target.GetType().GetMethods();

                string[] methodNames = new string[methods.Length];
                for (int i = 0; i < methods.Length; i++)
                {
                    methodNames[i] = methods[i].Name;
                }
                script.methodeID = EditorGUILayout.Popup(script.methodeID, methodNames);
            }
            //script.targetMethode = methods[script.methodeID];
            // Debug.Log("Target Methode: " + script.targetMethode);
        }
        else
        {
            this.serializedObject.Update();
            EditorGUILayout.PropertyField(this.serializedObject.FindProperty("response"), true);
            serializedObject.ApplyModifiedProperties();
        }
        //Debug.Log(script.targetMethode);
    }
}
