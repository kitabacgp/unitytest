using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


enum bossstate
{
    first,second,third
}

public class Bosscore : MonoBehaviour
{
    public float bosscorehp = 100;
    public float cansee = 5;
    public float playerbullet = 20;

    void Start()
    {
        ///////////////////////////////////
        StageManager.stageStatusProp = StageState.STAGE2;
        SceneManager.LoadScene("Stage2");
        
        ////////////////////////////////////

        this.GetComponent<SpriteRenderer>().enabled = false;//ここは本来false
        Transform _trans = transform.Find("coreposition");
        

        float[,] coreposition = new float[5, 2];
        coreposition[0, 0] = -10;
        coreposition[0, 1] = 11;
        coreposition[1, 0] = -8;
        coreposition[1, 1] = 3;
        coreposition[2, 0] = -6;
        coreposition[2, 1] = 11;
        coreposition[3, 0] = -4;
        coreposition[3, 1] = 3;
        coreposition[4, 0] = -2;
        coreposition[4, 1] = 11;

        int[] ary = new int[] { 0, 1, 2, 3, 4};

         System.Random rng = new System.Random();
         int n = ary.Length;
         while (n > 1)
         {
             n--;
             int k = rng.Next(n + 1);
             int tmp = ary[k];
             ary[k] = ary[n];
             ary[n] = tmp;
         }

         this.transform.position = new Vector3(coreposition[ary[0], 0], coreposition[ary[0], 1], 0);

       /* while (true)
        {
            if (bosscorehp <= 70 && bosscorehp >= 65)
            {
                bosscore.GetComponent<BoxCollider>().enabled = false;
                bosscore.transform.position = new Vector3(coreposition[ary[1], 0], coreposition[ary[1], 1], 0);
                bosscore.GetComponent<BoxCollider>().enabled = true;
            }
        }

        while (true)
        {
            if (bosscorehp <= 35)
            {
                bosscore.GetComponent<BoxCollider>().enabled = false;
                bosscore.transform.position = new Vector3(coreposition[ary[2], 0], coreposition[ary[2], 1], 0);
                bosscore.GetComponent<BoxCollider>().enabled = true;
            }
        }*/


    }

    void Update()
    {
        if (bosscorehp == 0)
        {
            //ステージステータスあとで
            SceneManager.LoadScene("Stage2");

        }
        
    }


    void OnTriggerStay2D(Collider2D other)
    {

        if (other.tag == "Light")
        {
            this.GetComponent<SpriteRenderer>().enabled = true;
        }
    }

    IEnumerator OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Light")
        {
            yield return new WaitForSeconds(5f);
            this.GetComponent<SpriteRenderer>().enabled = false;
        }
    }

    
   /* while (bosscore.GetComponent<SpriteRenderer>().enabled == true)
            if (c.tag=="PlayerBullet")
            {
                bosscorehp = bosscorehp - playerbullet;
            }

        */
    

}
