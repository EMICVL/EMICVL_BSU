using UnityEngine;

public class AlovController : MonoBehaviour
{
    public GameObject Alov;
    GameObject AlovCari;
    // Use this for initialization
    void Start()
    {

    }

    private bool active = false;
    // Update is called once per frame
    void Update()
    {
        if (IsOnMouseEnter&&Input.GetMouseButtonDown(0))
        {
            //Alov.SetActiveRecursively(active);
            if (active)
            {
                Destroy(AlovCari);
                //Debug.Log("alov sondurdum");
            }
            else
            {
                AlovCari = Instantiate(Alov);
                //Debug.Log("alov yaratdim");
            }
            active = !active;
        }
    }
    private bool IsOnMouseEnter = false;
    void OnMouseEnter()
    {
        IsOnMouseEnter = true;

        Debug.Log("OnMouseEnter");
        Debug.Log("tag='" + this.tag);
        //Debug.Log(Input.GetMouseButtonDown(0));
        // when we mouse over this object, set the cursor

    }
    void OnMouseExit()
    {
        IsOnMouseEnter = false;
        Debug.Log("OnMouseExit");
        // when we mouse off this object restore the default cursor (passing null)
        //this.GetComponent<Rigidbody>().velocity = Vector3.zero;

    }
}