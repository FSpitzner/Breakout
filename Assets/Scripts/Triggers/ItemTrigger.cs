using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ItemController))]
public class ItemTrigger : InteractTrigger {

	public bool collectableFanatasie = true, collectableReal = true;
    public Fear fear;
    public ItemController item;

	public override void Interact (){
        bool dreamworldTriggered = fear.IsDreamworldActive();
		if ((collectableReal && collectableFanatasie) || (collectableReal && !dreamworldTriggered) || (collectableFanatasie && dreamworldTriggered)) {
			player.CollectItem (item);
			gameObject.SetActive (false);
            player.UnregisterInteractionTrigger(this);
		}
	}
}
