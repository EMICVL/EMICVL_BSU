using UnityEngine;

public class DialoglarController : CustomBehavior
{
    // Use this for initialization
    void Start () {
           
    }
    //void OnGU1I()
    //{
    //    GUILayout.BeginArea(new Rect(Screen.width / 4.0f, 70, Screen.width / 2.0f, Screen.height / 1.5f));
    //    GUILayout.BeginVertical();
    //    //GUI.Box(FirstMenuOnLoad, "This is the text to be displayed");
    //    GUI.Window(0, _firstMenuOnLoad, Menu33, "Cargo Test");
    //    GUILayout.Space(SpacingBetweenButtons);
    //    GUILayout.EndVertical();
    //    GUILayout.EndArea();
    //}
    // Update is called once per frame
    void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
        }
    }
    //void Menu33(int i)
    //{
    //    if (CreateButton("Play"))
    //    {

    //    }
    //    if (CreateButton("Controls"))
    //    {

    //    }
    //    if (CreateButton("Quit"))
    //    {

    //    }
    //}


         
    void OnGUI()
    {
           
    }
}