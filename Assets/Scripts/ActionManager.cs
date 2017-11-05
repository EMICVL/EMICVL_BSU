using UnityEngine;
using UnityEngine.SceneManagement;

public class ActionManager : MonoBehaviour
{
    public static bool Bool_0 { get; set; }
    public static bool Bool_1 { get; set; }
    public static bool Bool_2 { get; set; }
    public static bool Bool_3 { get; set; }
    public static bool Bool_4 { get; set; }
    public static bool Bool_5 { get; set; }
	
	
	
    public static GameStateTypes CurrentGameState = GameStateTypes.NotStarted;

    public static bool AllLevelsCompleted
    {
        get
        {
            return Bool_0 &&
                   Bool_1 &&
                   Bool_2 &&
                   Bool_3 &&
                   Bool_4 &&
                   Bool_5;
        }
    }
    private static bool _showFirstMenu = true;
    private static bool _showSecondMenu = false;
    public float SpacingBetweenButtons = 10.0f;

    public static bool ShowSecondMenu
    {
        get { return _showSecondMenu; }
        set
        {
            _showSecondMenu = value;
            Time.timeScale = _showSecondMenu ? 0.0f : 1.0f;
        }
    }
    public static  GUIContent[] contents { get; set; }
	
    public Texture BoxTexture;
    
	public Texture BoxTextureCompleted;
    
	public static ActionManager Instance { get; set; }
    
	GUIStyle style = new GUIStyle();
    private Rect _firstMenuOnLoad;
    public float AreaWidth = 200f;
    public float AreaHeight = 200f;
    public static bool ShowFirstMenu
    {
        get { return _showFirstMenu; }
        set
        {
            _showFirstMenu = value;
            Time.timeScale = _showFirstMenu ? 0.0f : 1.0f;
        }
    }
	
    // Use this for initialization
    void Start ()
    {
        Instance = this;
        ShowFirstMenu = true;
        var x = (Screen.width - AreaWidth) / 2;
        var y = (Screen.height - AreaHeight) / 2;
        _firstMenuOnLoad = new Rect(x, y, AreaWidth, AreaHeight);
        style.alignment = TextAnchor.MiddleLeft;
        style.fontSize = 15;
        style.normal.textColor = Color.green;

        contents = new GUIContent[7];
        
        var content0 = new GUIContent(@"Bacterial culture(suspension)", BoxTexture,
            "Remove a loopful of bacteria from tube");
        contents[0] = content0;

        var content1 = new GUIContent(@"Glass slide", BoxTexture,
            "Place the loopful of bacteria in the center of the target circle on the slide");
        contents[1] = content1;

        var content2 = new GUIContent(@"Cover the smear", BoxTexture,
            "Cover the smear withcrystal violet solution\n\n    and let stand  for 30-60 seconds.Briefly wash of\n\n        stainwith distilled water and dry the slide");
        contents[2] = content2;

        var content3 = new GUIContent(@"Cover the smear with Lugol’s", BoxTexture,
            "Cover the smear with Lugol’s\n\n        iodinesolution and let it stand \n\n    for 30-60 seconds.Wash of smear\n\n        with distilled water");
        contents[3] = content3;

        var content4 = new GUIContent(@"Flood the smear with", BoxTexture,
            "96% ethyl alcohol for 30 seconds.");
        contents[4] = content4;

        //var content5 = new GUIContent(@"Cover the smear with fuksin", BoxTexture,
        //    "  Cover the smear with fuksin(or safranin) solution for 30     seconds.Pour off fuksinsolution from smear and wash\n\n        gently with distilled water for 2-3 seconds.\n\n        Drythe smear with bibulous paper.");
        //contents[5] = content5;

        var content6 = new GUIContent(@"Put a drop of immersion oil", BoxTexture,
            @" Put a drop of immersion oil on thesmear and examine the smear under immersion objective");
        contents[5] = content6;
    }
    
    public static int BoxWidth = 250;
    public static int BoxHeight = 50;
	public GUIStyle centeredStyle2;
	public GUIStyle StartButton;
	public GUIStyle ExitButton;
	public GUIStyle YouWonButton;
	 

	 
	public Texture backgroundTexture;
	public void OnGUI()
    {
        if (ShowFirstMenu)
        {
			//GL.Clear(true,true,Color.green);
			GUI.DrawTexture (new Rect (0, 0, Screen.width, Screen.height), backgroundTexture, ScaleMode.StretchToFill);
            if(centeredStyle2==null)centeredStyle2 = GUI.skin.GetStyle("Button");
            // centeredStyle2.normal.background= NormalBackgroundOfButtonStart;
            //centeredStyle2.hover.background= NormalBackgroundOfButtonStart;
            // centeredStyle2.onHover.background= NormalBackgroundOfButtonStart;
            centeredStyle2.normal.textColor = Color.green;
            centeredStyle2.fontSize = 25;
            // Graphics.Blit(NormalBackgroundOfButtonStart, null as RenderTexture);
            if (GUI.Button(new Rect(Screen.width / 2 - 50, -50 + Screen.height / 2 + 10, 200, 100), "Start", StartButton))
            {
                ShowFirstMenu = false;
				AudioSource audio = GetComponent<AudioSource>();
				audio.Stop();
                //var player = GameObject.FindGameObjectsWithTag("Player")[0];
                //player.GetComponent<RigidbodyFirstPersonController>().mouseLook.lockCursor= true;
            }
            GUILayout.Space(SpacingBetweenButtons);
            if (GUI.Button(new Rect(Screen.width / 2 - 50, 50 + Screen.height / 2 + 10, 200, 100), "Exit", ExitButton))
            {
                Application.Quit();
				#if UNITY_EDITOR
				UnityEditor.EditorApplication.isPlaying = false;
				#endif
            }
        }


        if (ShowSecondMenu)
        {
            CurrentGameState = GameStateTypes.HandledDistilledWaterAndGlass;
            GUILayout.BeginArea(_firstMenuOnLoad);
            GUILayout.BeginVertical();

            if (GUILayout.Button("OK You Have Completed First\nPress To Continue", GUILayout.Width(200), GUILayout.Height(50)))
            {
                ShowSecondMenu = false;
            }
            GUILayout.Space(SpacingBetweenButtons);

            GUILayout.EndVertical();
            GUILayout.EndArea();
        }

        OnGUIGeneral();

        //GUI.Box(new Rect(0, 0, BoxWidth, BoxHeight), "This is a box");
        if (!ShowFirstMenu&&!AllLevelsCompleted)
        {
            int h = 0;
            foreach (var content in contents)
            {
               if(content!=null) GUI.Box(new Rect(0, h, BoxWidth, BoxHeight), content, style);
                h += BoxHeight;
            }
        }
    }
	// Update is called once per frame
	void Update ()
	{
	    var player = GameObject.Find("Player");
	    var x = player.transform.eulerAngles.x;
	    var y = player.transform.eulerAngles.y;
	    var z = player.transform.eulerAngles.z;
	    y += 5;
       // player.transform.eulerAngles = new Vector3(x, y, z);

        //player.transform.RotateAround(Vector3.up, 0.05f);
    }
    void OnGUIGeneral()
    {
        if (!AllLevelsCompleted)
        {
            return;
        }
        GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), backgroundTexture, ScaleMode.StretchToFill);
        if (centeredStyle2 == null) centeredStyle2 = GUI.skin.GetStyle("Button");
        // centeredStyle2.normal.background= NormalBackgroundOfButtonStart;
        //centeredStyle2.hover.background= NormalBackgroundOfButtonStart;
        // centeredStyle2.onHover.background= NormalBackgroundOfButtonStart;
        centeredStyle2.normal.textColor = Color.green;
        centeredStyle2.fontSize = 25;
        // Graphics.Blit(NormalBackgroundOfButtonStart, null as RenderTexture);
        //if (GUI(new Rect(Screen.width / 2 - 50, -50 + Screen.height / 2 + 10, 200, 100), "You Won", YouWonButton))
        //{
        //}
        //        GUILayout.Space(SpacingBetweenButtons);
        if (GUI.Button(new Rect(Screen.width / 2 - 50, 50 + Screen.height / 2 + 10, 200, 100), "Exit", ExitButton))
        {
            Application.Quit();
#if UNITY_EDITOR
				UnityEditor.EditorApplication.isPlaying = false;
#endif
        }

        ////==////////////////////////////////////////
        //if (GUI.Button(new Rect(Screen.width / 2 - 50, -50 + Screen.height / 2 + 10, 100, 50), 
        //        "ReStart"
        //        ,
        //        YouWonButton))
        //{
        //        Debug.Log("OnGUIGeneral");
        //        ActionManager.Bool_0 = false;
        //        ActionManager.Bool_1 = false;
        //        ActionManager.Bool_2 = false;
        //        ActionManager.Bool_3 = false;
        //        ActionManager.Bool_4 = false;
        //        ActionManager.Bool_5 = false;
        //        ShowFirstMenu = true;
        //        SceneManager.LoadScene("EsasScene");
        //    }
    }
}
