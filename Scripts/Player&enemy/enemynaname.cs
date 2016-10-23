using UnityEngine;
using System.Collections;

public class enemynaname : MonoBehaviour
{

    public float enemyhp = 10;

    public float speed = 5f;

    public float CharaDPower = 5f;

    public float CharaCPower = 1.0f;

    OffScreenMove offScr;

    private Vector3 pos;

    private Rigidbody2D rigid;

    /*Player,PlayerBullet,Light,Fieldに
     それぞれの名前のレイヤーをセットしてください
     また、FieldをGame画面と同じ大きさに変更してください*/

    

    void Start()
    {
        //生成されたとき見えなくする
        this.GetComponent<SpriteRenderer>().enabled = false;
        offScr = this.GetComponent<OffScreenMove>();
        pos = Camera.main.WorldToViewportPoint(this.transform.position);

        rigid = GetComponent<Rigidbody2D>();


    }

    void Update()
    {
        //Hp0で消滅
        if (enemyhp <= 0)
        {
            Destroy(this.gameObject);
        }

        if (offScr.onScreen == true)
        {



            if (pos.x <= 0.5 && pos.y <= 0)
            {
                rigid.velocity = (transform.right+transform.up) * speed;
               
            }
            if (pos.x >= 0.5 && pos.y <= 0)
            {
                rigid.velocity = (-transform.right + transform.up) * speed;
            }
            if (pos.x <= 0 && pos.y <= 0.5)
            {
                rigid.velocity = (transform.right + transform.up) * speed;
            }
            if (pos.x <= 0 && pos.y >= 0.5)
            {
                rigid.velocity = (transform.right - transform.up) * speed;
            }
            if (pos.x <= 0.5 && pos.y >= 1)
            {
                rigid.velocity = (transform.right - transform.up) * speed;
            }
            if (pos.x >= 0.5 && pos.y >= 1)
            {
                rigid.velocity = -(transform.right + transform.up) * speed;
            }
            if (pos.x >= 1 && pos.y <= 0.5)
            {
                rigid.velocity = (transform.right - transform.up) * speed;
            }
            if (pos.x >= 1 && pos.y >= 0.5)
            {
                rigid.velocity = -(transform.right + transform.up) * speed;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D c)
    {

        // レイヤー名を取得
        string layerName = LayerMask.LayerToName(c.gameObject.layer);

        if (layerName == "Player")
        {
            Destroy(this.gameObject);
        }

        if (layerName == "PlayerBullet")
        {

            enemyhp = enemyhp - CharaDPower;
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

        // string layerName = LayerMask.LayerToName(c.gameObject.layer);

        if (other.tag == "Light")
        {
            // print("outLight");
            this.GetComponent<SpriteRenderer>().enabled = false;
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {

        if (other.tag == "Light")//のちに変更
        {

            enemyhp -= CharaCPower * Time.deltaTime;
        }
    }

}