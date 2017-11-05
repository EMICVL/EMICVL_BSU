using UnityEngine;

public class CustomCursor : MonoBehaviour
{
    public  Texture2D TextureNormal;
    public  Texture2D TexturePressed;
    // cursor mode to use
    CursorMode cursorMode = CursorMode.ForceSoftware;
    // cursor hotspot (pixels from top left of image)
    private Vector2 hotSpot = new Vector2(1, 1);

    // Use this for initialization
    void Start()
    {
        Cursor.visible = true;
    }

    // Update is called once per frame
    void Update()
    {
        CheckYCoordinat();
        IsMouseDown = Input.GetMouseButton(0);
        if (IsMouseDown)
        {
            //Debug.Log("Kliklendi:" + this.name);
        }
        if (IsOnMouseEnter) FirlanmaniYoxla();
        //if (IsOnMouseEnter)
        {
            Cursor.SetCursor(!IsMouseDown ? TextureNormal : TexturePressed, hotSpot, cursorMode);
              
        }
        if (IsMouseDown&& !IsOnMouseEnter)
        {
           // GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
        }
        else
        {
            //GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation |
              //                                           RigidbodyConstraints.FreezePosition;
        }
        
    }

    public static int id = 0;
    private bool isRotated = false;
    private void FirlanmaniYoxla()
    {
        if (gameObject.layer!= LayerMask.NameToLayer("Firlanan"))
        {
            return;
        }
        if (Input.GetMouseButton(1))
        {
            if (!isRotated)
            {
                transform.Rotate(90, 0, 0);
                isRotated = true;
            }
        }
        else
        {
            if (isRotated)
            {
                transform.Rotate(-90, 0, 0);
                isRotated = false;
            }
        }
    }

    private void CheckYCoordinat()
    {
        if (transform.position.y<60)
        {
            transform.position = new Vector3(transform.position.x, 60, transform.position.z);
        }
    }

    private bool IsMouseDown = false;
    private bool IsOnMouseEnter=false;

    void OnMouseEnter()
    {
        IsOnMouseEnter = true;
            
        //Debug.Log("OnMouseEnter");
        //Debug.Log("tag='"+tag);
        if (tag== "DistilledWater")
        {
        }
        //Debug.Log(Input.GetMouseButtonDown(0));
        // when we mouse over this object, set the cursor
    }

    void OnMouseExit()
    {
        IsOnMouseEnter = false;
        //Debug.Log("OnMouseExit");
        // when we mouse off this object restore the default cursor (passing null)
        Cursor.SetCursor(null, Vector2.zero, cursorMode);
        //this.GetComponent<Rigidbody>().velocity = Vector3.zero;
           
    }

    public Texture myBoxTexture;
    void OnGUI()
    {
        if (!IsOnMouseEnter) return;
        var word = "";
        if (!IsMouseDown)
        {
            word = "" + name;
        }
        else
        {
            if (name == "Alcohol Lamp")
            {
                word = name + " lightening ";
            }
            else
            {
                word = name + " selected ";
            }
        }
        //GUI.Box(new Rect(Screen.width - 200, Screen.height - 35, 200, 80), myBoxTexture);
        GUIStyle style = new GUIStyle();

        Font myFont = (Font)Resources.Load("Fonts/comic", typeof(Font));
        style.font = myFont;

        // Set color for selected and unselected buttons
        style.normal.textColor = Color.red;
        style.hover.textColor = Color.green;


        GUI.Label(new Rect(Screen.width - 200, Screen.height - 35, 200, 80), word,style);
    }
}