using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ItemController))]
public class ItemTrigger : InteractTrigger {

	public bool collectableFanatasie = true, collectableReal = true;

	void Start(){
		triggerType = "Interact";
	}

	public override void Interact (){
		bool dreamworldTriggered = LevelController.instance.GetDreamworldTriggered ();
		if ((collectableReal && collectableFanatasie) || (collectableReal && !dreamworldTriggered) || (collectableFanatasie && dreamworldTriggered)) {
			LevelController.instance.player.CollectItem (gameObject.GetComponent<ItemController> ());
			gameObject.SetActive (false);
		}
	}
}
