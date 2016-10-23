using UnityEngine;
using System.Collections;

public class PlayerBullet : MonoBehaviour {

    public int bulletspeed = 10;

    public float lifeTime = 1;//消滅時間


    void Start()
    {
        //BulletをCharaD上に生成、左に移動
        this.transform.position = GameObject.Find("CharaD").transform.position;
        GetComponent<Rigidbody2D>().velocity = transform.up.normalized * bulletspeed;

        //消滅時間秒後、消去
        Destroy(gameObject, lifeTime);
    }

    void Update()
    {
      
    }

    //Enemyと衝突すると消滅
	void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {

            Destroy(this.gameObject);
        }
    }

}
