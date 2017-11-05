using UnityEngine;

public class SelectableObject : MonoBehaviour
{
    public GameObject HandObject;
    //float speed = 6.0f;
    //float jumpSpeed = 8.0f;
    //float gravity = 20.0f;
    //private Vector3 moveDirection = Vector3.zero;
    // ======================================================================
    //private bool grabObj = false;
    //private GameObject hitObj;
    //public RaycastHit hit;
    GameObject SelectedObject=null;
    void OnTriggerEnter(Collider info)
    {
        Debug.Log("geldi :" + info.gameObject.tag);
//        Debug.Log("geldi2 :" + info.tag);
        if (info.tag == "Player")
        {
            SelectedObject = info.gameObject;
            Debug.Log("tutmusham:" + info.gameObject.name);
            //SelectedObject.GetComponent<Renderer>().material=...
        }
    }
    void OnTriggerExit(Collider info)
    {
        if (info.tag == "Player")
        {
            //Debug.Log("buraxdim:" + info.gameObject.name);
            //SelectedObject = null;
        }
    }


    public void Update()
    {
        if (SelectedObject!=null)
        {
            //obyekti ozunun dalinca surundurmek
            var pos = HandObject.GetComponent<Camera>().transform.localPosition;
            var x = pos.x+1;
            var y = pos.y;
            var z = pos.z+1;
            this.gameObject.transform.position = new Vector3(x, y, z);
            Debug.Log("suruyurem..."+ SelectedObject.transform.position);
        }
        /*if(Input.GetMouseButtonDown(0))
        {
            Debug.Log("buraxdim:" + info.gameObject.name);
        }
        
        Debug.DrawLine(controller.gameObject.transform.forward,controller.gameObject.transform.position , Color.green);
        if (Physics.Raycast(transform.position, transform.forward, out hit, 5))
        {
            Debug.Log("BURDAYAM");
            if (hit.collider.gameObject != null && Input.GetMouseButtonDown(0) && grabObj == false)
            {
                Debug.Log("hit.collider.gameObject");
                hitObj = hit.collider.gameObject;
                grabObj = true;
            }
            else if (Input.GetMouseButtonDown(0) && grabObj == true)
            {
                grabObj = false;
            }
        }
        if (grabObj)
        {
            Debug.Log("grabObj");
            //Moving object with player, 2 units in front of him cause we want to see it.
            var x = gameObject.transform.position.x;
            var y = gameObject.transform.position.y;
            var z = gameObject.transform.position.z + 2;
            hitObj.transform.position = new Vector3(x, y, z);

        }
        // =====================================================================

        


        if (controller.isGrounded)
        {
            Debug.Log("controller.isGrounded");
            // We are grounded, so recalculate
            // move direction directly from axes
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0,
            Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= speed;


            if (Input.GetButton("Jump"))
            {
                Debug.Log("if (Input.GetButton(\"Jump\"))");
                moveDirection.y = jumpSpeed;
            }
        }


        // Apply gravity
        moveDirection.y -= gravity * Time.deltaTime;


        // Move the controller
        controller.Move(moveDirection * Time.deltaTime);
        */
    }
}