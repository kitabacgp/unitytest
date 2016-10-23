using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
   
    public float speed = 5;

    public static int Playerhp =3;

    public GameObject player;

    public GameObject bullet;

    public GameObject shield;

    public GameObject shield2;

    public GameObject shield3;

    public float shotDelay = 0.5f;//C弾の発射間隔

    public float spinTime = 0.0005f;

    public float ShieldDelay = 3.0f;//シールド復活時間
    
    public float timer = 3.0f;//無敵時間

    public float CharaDPower = 5.0f;
    
    public float CharaCPower = 1.0f;//１秒あたり

    public Collider2D colA, colB, colC, colD;

    StageManager stageManager;

    

    IEnumerator Start() {

       
        if(StageManager.stageStatusProp== StageState.STAGE1)
        { 
            BGMManager.Instance.PlayBGM(StageState.STAGE1);

        }

        if(StageManager.stageStatusProp == StageState.STAGE2)
        {
           
            BGMManager.Instance.PlayBGM(StageState.STAGE2);
        }
       


        while (true)
        {
            //回転していなければ弾を発射
            if (Mathf.Round(this.transform.eulerAngles.z) % 90 ==0)
            {
                Quaternion kakudo = this.transform.rotation * Quaternion.Euler(0, 0, 90);
                GameObject bulletObj=Instantiate(bullet, transform.position,kakudo) as GameObject;
                SEManager.Instance.sePlay(2);
                ///////kidann

            }
            yield return new WaitForSeconds(shotDelay);
        }
    }


    void Update()
    {
        

        if (Playerhp == 0)
        {
            SceneShift.Instance.toGameOver();
        }

        if (GameManager.Instance.gameStatusProp == GameState.CLEAR)
        {
            colA.enabled = false;
            colB.enabled = false;
            colC.enabled = false;
            colD.enabled = false;
        }
        
       
        //Edit,PlojectSeting,InputからHorizontalのaを消去してください
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        Vector2 direction = new Vector2(x, y).normalized;

        GetComponent<Rigidbody2D>().velocity = direction * speed;

        if (Input.GetKeyDown("a"))
        {
            StartCoroutine(SpinR());
        }
        /*if (Input.GetKeyDown("u"))
        {
            StartCoroutine("SpinL");
        }
        if (Input.GetKeyDown("v"))
        {
            StartCoroutine("SpinR2");
        }*/

        Clamp();
    }

    void Clamp()
    {
        // 画面左下のワールド座標をビューポートから取得
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0.08f, 0.06f));

        // 画面右上のワールド座標をビューポートから取得
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(0.92f,0.94f));

        // プレイヤーの座標を取得
        Vector2 pos = transform.position;

        // プレイヤーの位置が画面内に収まるように制限をかける
        pos.x = Mathf.Clamp(pos.x, min.x, max.x);
        pos.y = Mathf.Clamp(pos.y, min.y, max.y);

        // 制限をかけた値をプレイヤーの位置とする
        transform.position = pos;
    }


    //aを押すと右に90度回転
    IEnumerator SpinR()
    {
        for (int i = 0; i <=13; i++)
        {
            transform.Rotate(new Vector3(0f, 0f, -i));
            yield return new WaitForSeconds(spinTime);
        }
        transform.Rotate(new Vector3(0f, 0f, 1f));
    }

    /*IEnumerator SpinL()
    {
        for (int i = 0; i <= 13; i++)
        {
            transform.Rotate(new Vector3(0f, 0f, i));
            yield return new WaitForSeconds(spinTime);
        }
        transform.Rotate(new Vector3(0f, 0f, -1f));
    }

    IEnumerator SpinR2()
    {
        for(int i = 0; i <= 44; i++)
        {
            transform.Rotate(new Vector3(0f, 0f, 2f));
            yield return new WaitForEndOfFrame();
        }
    }*/

        //Enemyに当たるとダメージ1
    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.tag == "Enemy")
        { 
            Playerhp = Playerhp - 1;

          SEManager.Instance.sePlay(0);




            StartCoroutine("Damage");

            Destroy(other.gameObject);
        }
    }
    //ダメージを受けると実行、無敵時間
    IEnumerator Damage()
    {

        colA.enabled = false;
        colB.enabled = false;
        colC.enabled = false;
        colD.enabled = false;

        //CharaA～Dを格納
        Transform[] children = new Transform[3];
        for (int i = 0; i < 3; i++)
        {
            children[i] = this.transform.GetChild(i);
        }

        //タイマーがゼロになるまで点滅、
        while(timer > 0.0f)
        {
             //print(timer);
            foreach (Transform child in children)
            {

                child.gameObject.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0f);
                yield return new WaitForEndOfFrame();
                //yield return new WaitForSeconds(0.05f);
                child.gameObject.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
                yield return new WaitForEndOfFrame();
                //yield return new WaitForSeconds(0.05f);
            }
            timer -= Time.deltaTime*20;
        }
        
        colA.enabled = true;
        colB.enabled = true;
        colC.enabled = true;
        colD.enabled = true;

        timer = 3 ;
       
    }

    //シールドスクリプトから
    public void Camon()
    {
        StartCoroutine("hshs");
    }


    IEnumerator hshs ()
    {
       
        //復活時間待ってシールド1生成
        yield return new WaitForSeconds(ShieldDelay);

        GameObject Shieldobj = Instantiate(shield, transform.localPosition,transform.localRotation) as GameObject;
        Shieldobj.transform.parent = this.transform;
        Shield.shieldhp = 3;
        Shieldobj.transform.localPosition = new Vector3(0f, -3f, -1f);
    }
}
