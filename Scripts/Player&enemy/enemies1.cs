using UnityEngine;
using System.Collections;

public class enemies1 : MonoBehaviour
{

    public float enemyhp = 10;

    public float speed = 5f;

    private Player player;

    OffScreenMove offScr;
    

    /*Player,PlayerBullet,Light,Fieldに
     それぞれの名前のレイヤーをセットしてください
     また、FieldをGame画面と同じ大きさに変更してください*/


    void Start()
    {
        //生成されたとき見えなくする
        this.GetComponent<SpriteRenderer>().enabled = false;
        player = GameObject.Find("Player").GetComponent<Player>();
        offScr = this.GetComponent<OffScreenMove>();
    }

    void Update()
    {
        //Hp0で消滅
        if (enemyhp <= 0)
        {
            Destroy(this.gameObject);
        }

      
        if(offScr.onScreen)
        {
            GetComponent<Rigidbody2D>().velocity = offScr.dir * speed;
        }

    }

    void OnTriggerEnter2D(Collider2D c)
    {
        
        // レイヤー名を取得
        string layerName = LayerMask.LayerToName(c.gameObject.layer);
        

        if (layerName == "PlayerBullet")
        {

            enemyhp = enemyhp - player.CharaDPower;
        }

        //Lightに当たると見える
        if (layerName == "Light")
        {
           // print("22222222222222");
            this.GetComponent<SpriteRenderer>().enabled = true;
        }

        if (layerName == "Shield")
        {
            Destroy(this.gameObject);
        }

    }

    //Lightを出ると見えなくする
    void OnTriggerExit2D(Collider2D other)
    {

        if (other.tag == "Light")
        {
           // print("outLight");
            this.GetComponent<SpriteRenderer>().enabled = false;
        }
    }

    void OnTriggerStay2D(Collider2D other)
    { 
        if (other.tag == "Okyou")
        {
                enemyhp -= player.CharaCPower*Time.deltaTime ;        
        }
    }

}



