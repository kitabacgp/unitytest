using UnityEngine;
using System.Collections;

public class Boss2 : MonoBehaviour {

    //PlayerBullet
    //Light


    [SerializeField]
    GameObject[] tail;

    void tailScriptDel()
    {
        foreach (TailA tailScript in FindObjectsOfType<TailA>())
        {
            Destroy(tailScript);
        }
        foreach (TailB tailScript in FindObjectsOfType<TailB>())
        {
            Destroy(tailScript);
        }
        foreach (TailC tailScript in FindObjectsOfType<TailC>())
        {
            Destroy(tailScript);
        }
        foreach (TailD tailScript in FindObjectsOfType<TailD>())
        {
            Destroy(tailScript);
        }
        foreach (CenterTail tailScript in FindObjectsOfType<CenterTail>())
        {
            Destroy(tailScript);
        }
    }

    GameObject player;

    SEManager seManager;

    //HP
    [SerializeField]
    float bossHP = 100.0f;

    [SerializeField, Tooltip("与えるダメージ=攻撃力*(1+ magnification*弱体尾本数)")]
    float magnification=0.2f;

    // Use this for initialization
    void Start()
    {

        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (bossHP<=0)
        {
            SEManager.Instance.sePlay(6);
            SEManager.Instance.sePlay(9);
            GameManager.Instance.gameStatusProp = GameState.CLEAR;

            tailScriptDel();

            GameObject clearCanvas = GameObject.Find("ClearCanvas");
            clearCanvas.GetComponent<Canvas>().enabled = true;
            Invoke("wait", 2f);
            
            
        }
    }

    void wait()
    {
        
        
        SceneShift.Instance.toClear();
    }

    void OnTriggerStay2D(Collider2D col)
    {
        if (col.tag == "PlayerBullet")
        {
            //弾の攻撃力を取得してbossHPを減らす
            //範囲攻撃のほう
            float attackPerSecond = FindObjectOfType<Player>().GetComponent<Player>().CharaCPower;
            bossHP -= attackPerSecond * Time.deltaTime * (1 + magnification * Tail.weakTailNumber);

            
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "PlayerBullet")
        {
            //弾の攻撃力を取得してbossHPを減らす
            //波動弾攻撃のほう
            float attackPoint = FindObjectOfType<Player>().GetComponent<Player>().CharaDPower;
            bossHP -= attackPoint*(1+magnification*Tail.weakTailNumber);
        }
    }
}
