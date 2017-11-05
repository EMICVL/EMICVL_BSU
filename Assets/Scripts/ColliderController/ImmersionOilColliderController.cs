using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ImmersionOilColliderController : MonoBehaviour {

    // Use this for initialization
    void OnCollisionStay(Collision col)
    {
        if(ActionManager.ShowFirstMenu) return;
        if (col.gameObject.name == "First Glass")
        {
			Debug.Log("ImmersionOilColliderController.OnCollisionEnter:" + col.collider.name + " | " + col.gameObject.name);
            //Debug.LogError("OnCollisionEnter");
            ActionManager.Bool_5 = true;
            ActionManager.contents[5].image = ActionManager.Instance.BoxTextureCompleted;
            foreach (var guiContent in ActionManager.contents)
            {
                if (guiContent.image.name!= ActionManager.Instance.BoxTextureCompleted.name)
                {
                    return;
                }
            }
            AllLevelsCompleted = true;

        }
    }

    public static bool AllLevelsCompleted = false;   
}
