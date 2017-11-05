using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testRotate : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
	{
	    var player = this;
	    var x = player.transform.eulerAngles.x;
	    var y = player.transform.eulerAngles.y;
	    var z = player.transform.eulerAngles.z;
	    y += 5;
	    player.transform.eulerAngles = new Vector3(x, y, z);
    }
}
