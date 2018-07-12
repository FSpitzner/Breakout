using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestController : MonoBehaviour {
    public virtual void SetValue(int itemID, bool value) { }
    public virtual void CheckQuestObject(Object obj) { }
}
