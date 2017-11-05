using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FushinSolutionColliderManager : MonoBehaviour {

    // Use this for initialization
    void OnCollisionStay(Collision col)
    {
        if(ActionManager.ShowFirstMenu) return;
        if (col.gameObject.name == "First Glass")
        {
			Debug.Log("FushinSolutionColliderManager.OnCollisionEnter:" + col.collider.name + " | " + col.gameObject.name);
            //Debug.LogError("OnCollisionEnter");
            ActionManager.Bool_2 = true;
            ActionManager.contents[2].image = ActionManager.Instance.BoxTextureCompleted;
        }
    }
	
}
