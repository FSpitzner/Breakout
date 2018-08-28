using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(menuName = "Scriptable Objects/Scene Manager")]
public class SceneLoader : ScriptableObject {

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
