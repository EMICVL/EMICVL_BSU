using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CustomBehavior : MonoBehaviour
{
    public static bool HandledDistilledWater = false;
    public delegate void Metod();
    public static bool HandledGlass = false;
    public static bool HandledFirstFlask = false;
    protected Animator AnimatorComponent;
    public float ButtonWidth = 70f;
    public float ButtonHeight = 100.0f;
    float _doubleClickStart = 0;
    private Rect _firstMenuOnLoad;
    public float AreaWidth=200f;
    public float AreaHeight=200f;
    private bool SecondMenuShown = false;

    public Texture2D NormalBackgroundOfButtonStart;
    //public bool CreateButton(string text)
    //{
    //    return GUILayout.Button(text, GUILayout.Width(ButtonWidth), GUILayout.Height(ButtonHeight));
    //}
   
    void OnMouseUp()
    {
        if ((Time.time - _doubleClickStart) < 0.3f)
        {
            this.OnDoubleClick();
            _doubleClickStart = -1;
        }
        else
        {
            _doubleClickStart = Time.time;
        }
    }

    public virtual void OnDoubleClick()
    {

    }

    


    // Use this for initialization
    void Start()
    {
        AnimatorComponent = GetComponent<Animator>();
        var x = (Screen.width - AreaWidth) / 2;
        var y = (Screen.height - AreaHeight) / 2;
        _firstMenuOnLoad = new Rect(x, y, AreaWidth, AreaHeight);
    }

  

    void OnGUI()
    {
        //if (HandledDistilledWater&& HandledGlass && !SecondMenuShown)
        //{
        //    ShowSecondMenu = true;
        //    SecondMenuShown = true;
        //}
        //if (ShowFirstMenu)
        {
#if false
            GUILayout.BeginArea(_firstMenuOnLoad);
            GUILayout.BeginVertical();

            if (GUILayout.Button("Start", GUILayout.Width(200), GUILayout.Height(50)))
            {
                ShowFirstMenu = false;
            }
            GUILayout.Space(SpacingBetweenButtons);
            if (GUILayout.Button("Exit", GUILayout.Width(200), GUILayout.Height(50)))
            {
                Application.Quit();
            }
            GUILayout.EndVertical();
            GUILayout.EndArea();
#endif
           var centeredStyle2= GUI.skin.GetStyle("Button");
           // centeredStyle2.normal.background= NormalBackgroundOfButtonStart;
            //centeredStyle2.hover.background= NormalBackgroundOfButtonStart;
           // centeredStyle2.onHover.background= NormalBackgroundOfButtonStart;
           centeredStyle2.normal.textColor=Color.green;
           centeredStyle2.fontSize=25;
           // Graphics.Blit(NormalBackgroundOfButtonStart, null as RenderTexture);
            //if (GUI.Button(new Rect(Screen.width / 2 - 50, -50+Screen.height / 2 + 10, 100, 50), "Start", centeredStyle2))
            //{
            //    ShowFirstMenu = false;
            //    //var player = GameObject.FindGameObjectsWithTag("Player")[0];
            //    //player.GetComponent<RigidbodyFirstPersonController>().mouseLook.lockCursor= true;
            //}
            ////GUILayout.Space(SpacingBetweenButtons);
            //if (GUI.Button(new Rect(Screen.width / 2 - 50, 50+Screen.height / 2 + 10, 100, 50), "Exit", centeredStyle2))
            //{
            //    Application.Quit();
            //}
        }
       
    }
    public void DoAfterNSeconds(float duration, Metod metod)
    {
        StartCoroutine("WaitForSeconds", new object[] { duration, metod });
    }
    public IEnumerator WaitForSeconds(object[] param)
    {
        float duration = (float)param[0];
        Metod metod = (Metod)param[1];
        yield return new WaitForSeconds(duration);   //Wait
        metod();
    }

   
}