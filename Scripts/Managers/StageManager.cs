using UnityEngine;
using System.Collections;

    //ステータス名
    public enum StageState
    {
        STAGE1,
        STAGE1BOSS,
        STAGE2,
        STAGE2BOSS
    }

public class StageManager : MonoBehaviour
{

    public static StageManager Instance;

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
    GameObject STAGE1GUI;
    [SerializeField]
    GameObject STAGE1BOSSGUI;
    [SerializeField]
    GameObject STAGE2GUI;
    [SerializeField]
    GameObject STAGE2BOSSGUI;

    //初期化、宣言
    private static StageState StageStatus = StageState.STAGE1;/// <summary>
    /// /////////////////
    /// </summary>

    //プロパティ
    public static StageState stageStatusProp
    {
        get
        {
            return StageStatus;
        }
        set
        {
            StageStatus = value;
        }
    }
    void Update()
    {
        print(stageStatusProp);
    }
}
