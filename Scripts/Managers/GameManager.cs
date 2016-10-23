using UnityEngine;
using System.Collections;
using UnityEngine.UI;


//ステータス
public enum GameState
{
    TITLE,
    PLAYING,
    PAUSE,
    CLEAR,
    GAMEOVER,
    NONE
}

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    SEManager seManager;

    void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    [SerializeField]
    GameObject TITLEGUI;
    [SerializeField]
    GameObject PLAYINGGUI;
    [SerializeField]
    GameObject PAUSEGUI;
    [SerializeField]
    GameObject CLEARGUI;
    [SerializeField]
    GameObject GAMEOVERGUI;

    private GameObject canvas;

    

    public float waitingTime =0.5f;

    //初期化、宣言
    private GameState Gamestatus = GameState.TITLE;

    //プロパティ
    public GameState gameStatusProp
    {
        
        get
        {
            return Gamestatus;
        }
        set
        {
            Gamestatus = value;
        }
    }

    void Update()
    {
        print(Gamestatus);
       
        //ポーズに関する処理
        //プレイ画面→ポーズ画面
        if (Gamestatus == GameState.PLAYING && Input.GetKeyDown("space"))
        {
            canvas = GameObject.Find("PauseCanvas");

            Gamestatus = GameState.PAUSE;

            Time.timeScale = 0;
            
            //PAUSEGUIのCanvasをオンにする
            canvas.GetComponent<Canvas>().enabled = true;
        }
        else if (Gamestatus == GameState.PAUSE && Input.GetKeyDown("z"))
        {
            Gamestatus = GameState.TITLE;

            Time.timeScale = 1;

           SceneShift.Instance.toTitle();
        }
        else if (Gamestatus == GameState.PAUSE && Input.GetKeyDown("space"))
        {
            Gamestatus = GameState.PLAYING;
            canvas.GetComponent<Canvas>().enabled = false;
            Time.timeScale = 1;

        }

        //gameスタート
        if (Gamestatus == GameState.TITLE && Input.GetKeyDown("space"))
        {
            SEManager.Instance.sePlay(4);
            Gamestatus = GameState.NONE;
            Invoke("waitTime", waitingTime);

        }

        if (Gamestatus == GameState.GAMEOVER && Input.GetKeyDown("space"))
        {
            SEManager.Instance.sePlay(4);
            Gamestatus = GameState.NONE;
            Invoke("toTitle",waitingTime);
        }

        if (Gamestatus == GameState.CLEAR && Input.GetKeyDown("space"))
        {
            SEManager.Instance.sePlay(4);
            Gamestatus = GameState.NONE;
            Invoke("toTitle", waitingTime);
        }

    }

    void toTitle()
    {
        Gamestatus = GameState.TITLE;
        SceneShift.Instance.toTitle();
    }

    void waitTime()
    {
        Gamestatus = GameState.PLAYING;
        SceneShift.Instance.toStage1();
    }

    //ゲームスタート時の処理
    void Start()
    {
        DontDestroyOnLoad(transform.gameObject);

        SEManager.Instance.sePlay(3);
    }

}
