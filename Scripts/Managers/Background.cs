using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Background : MonoBehaviour
{
    BGMManager bgmManager;
    //スクロールするスピード
    public float speed = 0.12f;

    //時間をはかる
    public float timer = 0;

    [SerializeField]
    private GameObject boss1,bosscannon,boss2;

    void Update()
    {

        //ループ
        float y = Mathf.Repeat(timer * speed, 1);

        //Yの値を動かす
        Vector2 offset = new Vector2(0, y);


        //マテリアルにオフセットを設定する
        GetComponent<Renderer>().sharedMaterial.SetTextureOffset("_MainTex", offset);

        if (StageManager.stageStatusProp == StageState.STAGE1)
        {
            
            if (timer >= 70 )
            {
                //スクロールが止まる

                //ボス画面1へ移動
                StageManager.stageStatusProp = StageState.STAGE1BOSS;
                Instantiate(boss1, new Vector2(0, 0), Quaternion.identity);
                Instantiate(bosscannon, new Vector2(0, 9), Quaternion.identity);
                BGMManager.Instance.PlayBGM(StageState.STAGE1BOSS);
            }
            else
            {
                //時間を取得
                timer += Time.deltaTime;
            }
        }
        if (StageManager.stageStatusProp == StageState.STAGE2)
        {
            if (timer >= 70)
            {
                //スクロールが止まる

                //ボス画面2へ移動
                StageManager.stageStatusProp = StageState.STAGE2BOSS;
                Instantiate(boss2, new Vector2(0, 3), Quaternion.identity);
                BGMManager.Instance.PlayBGM(StageState.STAGE2BOSS);
            }
            else
            {
                //時間を取得
                timer += Time.deltaTime;
            }
        }
    }
}


