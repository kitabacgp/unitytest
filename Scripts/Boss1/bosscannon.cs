using UnityEngine;
using System.Collections;

public class bosscannon : MonoBehaviour
{
    boss Boss;
    Bosscore bosscore;
    public GameObject enemybullet;
    float timecount;
    float amari;

    void Update()
    {
        timecount += Time.deltaTime;
        //経過時間を一連の動作の一区切りの時間である30秒で割ったときの余りをamariとする
        amari = timecount % 30;
    }
    IEnumerator Start()
    {
        this.
        Boss = GetComponent<boss>();
        bosscore =  FindObjectOfType<Bosscore>().GetComponent<Bosscore>();
        bosscore.bosscorehp = 100;
      
        
        while (bosscore.bosscorehp != 0)
        {
            //下の（１）の内容を参照し、５秒間弾発射＋５秒間発射しないの計１０秒間待つ
            StartCoroutine(cannonRota(0, 5,0));
            yield return new WaitForSeconds(10f);
       


            //下の（１）の内容を参照し、角度を30度反時計回りに回す
            StartCoroutine(cannonRota(10, 15, 30));
            yield return new WaitForSeconds(10f);


            ////下の（１）の内容を参照し、角度を60度時計回りに回す
            StartCoroutine(cannonRota(20, 25, -60));
            yield return new WaitForSeconds(10f);
            for (int k = 0; k < transform.childCount; k++)
            {
                Transform cannonposition = transform.GetChild(k);
                //最初の位置からずれた分の角度を戻す
                cannonposition.transform.eulerAngles += new Vector3(0, 0, 30);
            }
   

        }

    }
    //(1)
    //amariの値によって発射する角度(rote)をずらす
    IEnumerator cannonRota(int a, int b,int rota)
    {
        for (int k = 0; k < transform.childCount; k++)
        {
            Transform cannonposition = transform.GetChild(k);
            cannonposition.transform.eulerAngles += new Vector3(0, 0, rota);
        }

        while (a <= amari && amari < b)
        {
            for (int k = 0; k < transform.childCount; k++)
            {
                Transform cannonposition = transform.GetChild(k);
                Boss.Shot(cannonposition);
            }
            yield return new WaitForSeconds(0.6f);
        }
    }
}
 
   