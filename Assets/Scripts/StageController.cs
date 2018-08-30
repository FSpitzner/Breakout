using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.ShaderGraph;

public class StageController : MonoBehaviour {
    
    public List<Material> mats;
    public List<DreamworldObject> dreamworldObjects;
    private bool deactivate = false;
    private bool activate = false;
    private bool tweening = false;
    public bool isActive = false;
    private float opacity = 0f;
    public Fear fear;
    private bool dreamworldObjectsActive = false;
    private float transparencyTime = 1f;
    public int soundState;
    
    public void ActivateDreamworldObjects()
    {
        dreamworldObjectsActive = true;
        dreamworldObjects.ForEach((DreamworldObject dO) =>
        {
            dO.Activate();
        });
    }
    
    public void DeactivateDreamworldObjects()
    {
        dreamworldObjectsActive = false;
        dreamworldObjects.ForEach((DreamworldObject dO) =>
        {
            dO.Deactivate();
        });
    }

    public void SetActive(bool value)
    {
        if (!tweening)
        {
            if (!value)
            {
                deactivate = true;
                DeactivateDreamworldObjects();
            }
            else
            {
                gameObject.SetActive(true);
                activate = true;
                if (fear.IsDreamworldActive() && !dreamworldObjectsActive)
                {
                    ActivateDreamworldObjects();
                }
            }
        }
    }
    
    private void Start()
    {
        if (isActive)
        {
            opacity = 0f;
        }
        else
        {
            opacity = 1f;
            gameObject.SetActive(false);
        }
        mats.ForEach((Material m) =>
        {
            m.SetFloat("opacity", opacity);
        });
    }

    private void Update()
    {
        if (deactivate)
        {
            if (!tweening)
            {
                opacity = 0f;
                mats.ForEach((Material m) =>
                {
                    m.SetFloat("Vector1_DB2A1952", opacity);
                });
            }
            tweening = true;
            if(opacity < 1f)
                opacity += 1f/transparencyTime * Time.deltaTime;
            else if(opacity >= 1f)
            {
                opacity = 1f;
                mats.ForEach((Material m) =>
                {
                    m.SetFloat("Vector1_DB2A1952", opacity);
                });
                deactivate = false;
                isActive = false;
                tweening = false;
                gameObject.SetActive(false);
            }
        }else if (activate)
        {
            if (!tweening)
            {
                opacity = 1f;
                mats.ForEach((Material m) =>
                {
                    m.SetFloat("Vector1_DB2A1952", opacity);
                });
            }
            tweening = true;
            if (opacity > 0f)
                opacity -= 1f/transparencyTime * Time.deltaTime;
            else if (opacity <= 0f)
            {
                opacity = 0f;
                mats.ForEach((Material m) =>
                {
                    m.SetFloat("Vector1_DB2A1952", opacity);
                });
                isActive = true;
                activate = false;
                tweening = false;
            }
        }
        if (tweening)
        {
            Debug.Log("Tweening! Opacity at: " + opacity);
            mats.ForEach((Material m) =>
            {
                m.SetFloat("Vector1_DB2A1952", opacity);
            });
        }
        
    }

    public void FillMaterials()
    {
        mats = new List<Material>();
        GetMaterials(this.transform);
        mats.ForEach((Material m) =>
        {
            Debug.Log("Material: " + m);
        });
    }

    private void GetMaterials(Transform parent)
    {
        if (parent.GetComponent<MeshRenderer>() != null)
        {
            foreach (Material m in parent.GetComponent<MeshRenderer>().sharedMaterials)
            {
                if (!mats.Contains(m))
                {
                    mats.Add(m);
                }
            }
        }
        if (parent.childCount != 0)
        {
            foreach (Transform child in parent)
            {
                GetMaterials(child);
            }
        }
    }

    public bool IsActive()
    {
        return isActive;
    }

    public void OnQuit()
    {
        mats.ForEach((Material m) =>
        {
            m.SetFloat("Vector1_DB2A1952", 0f);
        });
    }
}

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
        if(GUILayout.Button(new GUIContent("Fill Materials")))
        {
            stage.FillMaterials();
        }
    }

}