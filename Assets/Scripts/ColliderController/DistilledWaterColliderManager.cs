using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistilledWaterColliderManager : MonoBehaviour {
	
    void OnCollisionStay(Collision col)
    {        
		if(ActionManager.ShowFirstMenu) return;
        if (col.gameObject.name== "First Glass")
        {
			Debug.Log("DistilledWaterColliderManager.OnCollisionEnter:" + col.collider.name + " | " + col.gameObject.name);
            //Debug.LogError("OnCollisionEnter");
            ActionManager.Bool_0 = true;
            ActionManager.contents[0].image = ActionManager.Instance.BoxTextureCompleted;
        }

    }
}
