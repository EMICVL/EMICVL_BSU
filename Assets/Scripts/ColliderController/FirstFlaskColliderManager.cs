using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstFlaskColliderManager : MonoBehaviour {

    void OnCollisionEnter(Collision collision)
    {
		if(ActionManager.ShowFirstMenu) return;
        //Destroy(collision.gameObject);
        Debug.Log("FirstFlaskColliderManager.OnCollisionEnter:"+collision.gameObject.name);
        foreach (ContactPoint contact in collision.contacts)
        {
            Debug.DrawRay(contact.point, contact.normal, Color.red);
        }
    }
    
}
