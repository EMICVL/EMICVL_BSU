using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Class to control rackets via touch
 public class TouchControl : MonoBehaviour 
 {
     //Public Variables
     public GameObject player1;
     public GameObject player2;
     //A modifier which affects the rackets speed
     public float speed;
     //Fraction defined by user that will limit the touch area
     public int frac;
 
     //Private Variables
     private float fracScreenWidth;
     private float widthMinusFrac;
     private Vector2 touchCache;
     private Vector3 player1Pos;
     private Vector3 player2Pos;
     private bool touched = false;
     private int screenHeight;
     private int screenWidth;
     // Use this for initialization
     void Start () 
     {
         //Cache called function variables
         screenHeight = Screen.height;
         screenWidth = Screen.width;
         fracScreenWidth = screenWidth / frac;
         widthMinusFrac = screenWidth - fracScreenWidth;
         player1Pos = player1.transform.position;
         player2Pos = player2.transform.position;
     }
     
     // Update is called once per frame
     void Update () 
     {
 //If running game in editor
 #if UNITY_EDITOR
         //If mouse button 0 is down
         if(Input.GetMouseButton(0))
         {
             //Cache mouse position
             Vector2 mouseCache = Input.mousePosition;
             //If mouse x position is less than or equal to a fraction of the screen width
             if (mouseCache.x <= fracScreenWidth)
             {
                 player1Pos = new Vector3(-7.5f, 0.5f, Mathf.Clamp(mouseCache.y / screenHeight * speed, 0, 8));
             }
             //If mouse x position is greater than or equal to a fraction of the screen width
             if(mouseCache.x >= widthMinusFrac)
             {
                 player2Pos = new Vector3(7.5f, 0.5f, Mathf.Clamp(mouseCache.y / screenHeight * speed, 0, 8));
             }
             //Set touched to true to allow transformation
             touched = true;
         }
 #endif
         //If a touch is detected
         if (Input.touchCount >= 1)
         {
             //For each touch
             foreach (Touch touch in Input.touches)
             {
                 //Cache touch position
                 touchCache = touch.position;
                 //If touch x position is less than or equal to a fraction of the screen width
                 if (touchCache.x <= fracScreenWidth)
                 {
                     player1Pos = new Vector3(-7.5f, 0.5f, Mathf.Clamp(touchCache.y / screenHeight * 8, 0, 8));
                 }
                 //If mouse x position is greater than or equal to a fraction of the screen width
                 if(touchCache.x >= widthMinusFrac)
                 {
                     player2Pos = new Vector3(7.5f, 0.5f, Mathf.Clamp(touchCache.y / screenHeight * 8, 0, 8));
                 }
             }
             touched = true;
         }
     }
 
     //FixedUpdate is called once per fixed time step
     void FixedUpdate()
     {
         if (touched)
         {
             //Transform rackets
             player1.transform.position = player1Pos;
             player2.transform.position = player2Pos;
             touched = false;
         }
     }
 }