using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LampaAndGlassCollisionManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnCollisionEnter(Collision col)
    {
        Debug.Log("OnCollisionEnter:" + col.collider.name + " | " + col.gameObject.name);
        if (col.gameObject.name == "First Glass")
        {
            //Debug.LogError("OnCollisionEnter");
            ActionManager.Bool_1 = true;
            ActionManager.contents[1].image = ActionManager.Instance.BoxTextureCompleted;
        }

    }
}
