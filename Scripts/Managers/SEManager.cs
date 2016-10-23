using UnityEngine;
using System.Collections;

public class SEManager : MonoBehaviour {

    //音管理
    protected static SEManager instance;

    public static SEManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = (SEManager)FindObjectOfType(typeof(SEManager));

                if (instance == null)
                {
                    Debug.LogError("SEManager Instance Error");
                }
            }

            return instance;
        }
    }

    // SE
    public GameObject[] seObj;

    void Awake()
    {
        GameObject[] obj = GameObject.FindGameObjectsWithTag("SEManager");
        if (obj.Length > 1)
        {
            // 既に存在しているなら削除
            Destroy(gameObject);
        }
        else
        {
            // 音管理はシーン遷移では破棄させない
            DontDestroyOnLoad(gameObject);
        }
    }

    public void sePlay(int id)
    {
        //対応するidのSEを呼び出す
        Instantiate(seObj[id]);


    }
}
