using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragByMouse : MonoBehaviour {

	 public  Texture2D TextureNormal;
     public  Texture2D TexturePressed;
	 private Vector2 hotSpot = new Vector2(1, 1);
     // cursor mode to use
     CursorMode cursorMode = CursorMode.ForceSoftware;
	 public static float MinimumFloorY=65;
	 private float dist;
     private Vector3 v3Offset;
     private Plane plane;
     private bool IsMouseDown = false;
     
	 public static int id = 0;
     private bool isRotated = false;
    public static GameObject SelectedGameObject { get; set; }

    void OnMouseDown()
    {
		if(ActionManager.ShowFirstMenu) return;
        SelectedGameObject = null;
         //Debug.Log("OnMouseDown:" + this.gameObject.name);
         plane.SetNormalAndPosition(Camera.main.transform.forward, transform.position);
         Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
         float dist;
         plane.Raycast (ray, out dist);
         v3Offset = transform.position - ray.GetPoint (dist);         
     }
     
     void OnMouseDrag()
     {
		 if(ActionManager.ShowFirstMenu) return;
         SelectedGameObject = this.gameObject;

          Cursor.SetCursor(TexturePressed, hotSpot, cursorMode);  
          //Debug.Log("OnMouseDrag:" + this.gameObject.name);
          Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
          float dist;
          plane.Raycast (ray, out dist);
          Vector3 v3Pos = ray.GetPoint (dist);
          transform.position = v3Pos + v3Offset;    
     }
	 
	 private void CheckYCoordinat()
    {
        if (transform.position.y<MinimumFloorY)
        {
            transform.position = new Vector3(transform.position.x, MinimumFloorY,transform.position.z);
        }
    }
	
	void Update()
    {
        CheckYCoordinat();
		IsMouseDown = Input.GetMouseButton(0);
       
        FirlanmaniYoxla();	
        if (IsMouseDown)
        {
            Cursor.SetCursor(!IsMouseDown ? TextureNormal : TexturePressed, hotSpot, cursorMode);              
        }        
	}
	 private void FirlanmaniYoxla()
    {
        //if (Input.GetKey(KeyCode.Space)
        if (Input.GetButton("Jump"))
        {
            if (!isRotated)
            {
                //SelectedGameObject.transform.Rotate(-90, 0, 0,Space.World);
				if(SelectedGameObject!=null)
                    SelectedGameObject.transform.eulerAngles =new Vector3(-180,-90,90);//= Quaternion.Euler(90, 0, 0);
				 //SelectedGameObject.transform.Rotate(Vector3.up * 90, Space.World);
				
				//SelectedGameObject.transform.RotateAround(SelectedGameObject.transform.position, (Vector3.up), Time.deltaTime * 90f);
                isRotated = true;
            }
        }
        else
        {
            if (isRotated)
            {
				//SelectedGameObject.transform.Rotate(90, 0, 0,Space.World);
				//SelectedGameObject.transform.Rotate(Vector3.right,90);
				SelectedGameObject.transform.eulerAngles =new Vector3(-90,-90,90);//= Quaternion.Euler(90, 0, 0);
                //SelectedGameObject.transform.Rotate(Vector3.right * -90f, Space.World);
                isRotated = false;
            }
        }
    }
	 void OnGUI()
    {
        if (ActionManager.ShowFirstMenu) return;
        if (!IsMouseDown) return;
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

        //Font myFont = (Font)Resources.Load("Fonts/comic", typeof(Font));
        //style.font = myFont;

        // Set color for selected and unselected buttons
        style.normal.textColor = Color.red;
        style.hover.textColor = Color.green;


        GUI.Label(new Rect(Screen.width - 200, Screen.height - 35, 200, 80), word,style);
    }
}
