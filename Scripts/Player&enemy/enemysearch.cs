using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class enemysearch : MonoBehaviour
{

    public static GameObject enemy3;
    private GameObject player;//追跡対象
    public float sokudo = 7;

    public float enemyhp = 10;

    public float speed = 5f;

    public float CharaDPower = 5f;

    public float CharaCPower = 1.0f;




    void Start()
    {
        this.GetComponent<SpriteRenderer>().enabled = false;
        player = GameObject.Find("Player");
        Move();
    }
  

    void Update()
    {
        if (enemyhp <= 0)
        {
            Destroy(this.gameObject);
        }

    }

    void Move()
    {
        Vector2 Enemy3 = player.transform.position;
       
        float x = Enemy3.x;
        float y = Enemy3.y;
    
        Vector2 direction = new Vector2(x - transform.position.x, y - transform.position.y).normalized;
        
        GetComponent<Rigidbody2D>().velocity = (direction * sokudo);
       
    }


        void OnTriggerEnter2D(Collider2D c)
        {
            // レイヤー名を取得
            string layerName = LayerMask.LayerToName(c.gameObject.layer);

            if (layerName == "Player")
            {
            
                // エネミーの削除
                Destroy(this.gameObject);
            }

        if (layerName == "PlayerBullet")
        {

            enemyhp = enemyhp - CharaDPower;
        }

        if (layerName == "Shield")
            {
            Destroy(this.gameObject);
            }

            if (layerName == "Playerwave")
            {
                //ここにはプレイヤーの攻撃範囲に入るとHPが減る処理が入る


                // エネミーの削除
            }
            if (layerName == "Light")
            {
                this.GetComponent<SpriteRenderer>().enabled = true;

            }

        }
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

        if (other.tag == "Okyou")//のちに変更
        {

            enemyhp -= CharaCPower * Time.deltaTime;
        }
    }




}