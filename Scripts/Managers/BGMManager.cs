using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BGMManager : MonoBehaviour {

    protected static BGMManager instance;

    //音源を探し、ない時エラー文を出す
    public static BGMManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = (BGMManager)FindObjectOfType(typeof(BGMManager));

                if (instance == null)
                {
                    Debug.LogError("BGMMamager Instance Error");
                }
            }
            return instance;
        }
    }


    //音量
    public SoundVolume volume = new SoundVolume();

    private AudioSource source;
    
    [Tooltip("1つ目にStage1、2つ目にStage2")]
    public AudioClip[] stageBGM;
    [Tooltip("1つ目にイントロ、2つ目にメイン")]
    public AudioClip[] boss1BGM;
    [Tooltip("1つ目にイントロ、2つ目にメイン")]
    public AudioClip[] boss2BGM;

    void Awake()
    {
        source = this.gameObject.GetComponent<AudioSource>();
        //ループ
        source.loop = true;

        //ボリューム設定
        source.volume = volume.BGM;
    }

    //BGM再生
    public void PlayBGM(StageState nowState)
    {
        print("bbbbbbbbbbbbbbbbbb");
        switch (nowState)
        {
            case StageState.STAGE1:
                source.clip = stageBGM[0];
                source.loop = true;
                break;

            case StageState.STAGE2:
                source.clip = stageBGM[0];
                source.loop = true;
                break;

            case StageState.STAGE1BOSS:
                //イントロ
                source.clip = boss1BGM[0];
                source.loop = false;
                Invoke("introToLoop", boss1BGM[0].length);
                break;

            case StageState.STAGE2BOSS:
                //イントロ
                source.clip = boss2BGM[0];
                source.loop = false;
                Invoke("introToLoop", boss2BGM[0].length);
                break;
        }
        //再生
        source.Play();

        //コメントアウト
        #region
        /*//ステージ1のとき、StageBGMを再生
        if (nowState == StageState.STAGE1)
        {
            source.clip = stageBGM[0];
            StageBGM.Play();
        }

        //ステージ2のとき、StageBGMを再生
        if (StageManager.stageStatusProp == StageState.STAGE2)
        {
            if (0 > index || stageBGM.Length <= index)
            {
                return;
            }
            //同じBGMの場合何もしない
            if (StageBGM.clip == stageBGM[index])
            {
                return;
            }
            StageBGM.Stop();
            StageBGM.clip = stageBGM[index];
            StageBGM.Play();
        }

        //ステージ1のボスのとき、Boss1BGMを再生
        if (StageManager.stageStatusProp == StageState.STAGE1BOSS)
        {
            if (0 > index || boss1BGM.Length <= index)
            {
                return;
            }
            //同じBGMの場合何もしない
            if (Boss1BGM.clip == boss1BGM[index])
            {
                return;
            }
            Boss1BGM.Stop();
            Boss1BGM.clip = boss1BGM[index];
            Boss1BGM.Play();
        }

        //ステージ2のボスのとき、Boss2BGMを再生
        if (StageManager.stageStatusProp == StageState.STAGE2BOSS)
        {
            if (0 > index || boss2BGM.Length <= index)
            {
                return;
            }
            //同じBGMの場合何もしない
            if (Boss2BGM.clip == boss2BGM[index])
            {
                return;
            }
            Boss2BGM.Stop();
            Boss2BGM.clip = boss2BGM[index];
            Boss2BGM.Play();
        }*/
        #endregion

    }

    //イントロからメインループへ
    void introToLoop()
    {
        if (source.clip == boss1BGM[0])
            source.clip = boss1BGM[1];

        if (source.clip == boss2BGM[0])
            source.clip = boss2BGM[1];

        source.loop = true;
        source.Play();
    }

    //BGM停止
    public void StopBGM()
    {
        source.Stop();
        source.clip = null;
    }
}

//音量クラス
public class SoundVolume
{
    public float BGM = 0.1f;

    public void Init()
    {
        BGM = 0.1f;
    }
}
