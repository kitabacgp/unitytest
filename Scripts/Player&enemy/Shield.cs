using UnityEngine;
using System.Collections;

public class Shield : MonoBehaviour {

    public static int shieldhp = 3;
   
    public GameObject shield;

    public GameObject shield2;

    public GameObject shield3;

    public GameObject player;


    void Update()
    {
        ////////////////////
       //Player playerScript = player.GetComponent<Player>();

        GameObject targetPlayer = GameObject.Find("Player");


        var thisColor = this.GetComponent<SpriteRenderer>().color;
        


        //PlayerのCollider有無
        if (targetPlayer.GetComponent<Player>().colA.enabled == true)
         {
            //時機が回転していなければそのまま
            if (Mathf.Round(this.transform.eulerAngles.z) % 90 == 0)
            {
                this.GetComponent<BoxCollider2D>().enabled = true;
                this.GetComponent<SpriteRenderer>().enabled = true;
                //thisColor.a = 1;
            }
            //回転していればシールドを消す
            else
            {
                
                this.GetComponent<BoxCollider2D>().enabled = false;
                //thisColor = new Color(1,1,1,0);
                this.GetComponent<SpriteRenderer>().enabled = false;
            }
         }        
        else
        {
            this.GetComponent<BoxCollider2D>().enabled = false;
        }

    }

 void Start()
    {

        var thisColor = this.GetComponent<SpriteRenderer>().color;
        //
        var targetPlayer = shield.transform.eulerAngles.z;
    }
	
    void OnTriggerEnter2D(Collider2D other)
    {
        var targetplayer = GameObject.Find("Player");

        if (other.gameObject.tag =="Enemy")
        {

            shieldhp = shieldhp - 1;
            
            // エネミーと衝突するとシールド2を生成
            if (shieldhp == 2)
            {
                var targetShield = GameObject.FindWithTag("Shield");
                GameObject Shield2obj = Instantiate(shield2, transform.localPosition, player.transform.localRotation) as GameObject;
              
                Shield2obj.transform.parent = targetplayer.transform;
                Shield2obj.transform.localPosition = new Vector3(0, -3, -1);
              
                Destroy(targetShield.gameObject);         

            }

            //さらに3を生成
            if (shieldhp == 1)
            {
                var targetShield2 = GameObject.FindWithTag("Shield2");

                GameObject Shield3obj = Instantiate(shield3, transform.localPosition, targetplayer.transform.localRotation) as GameObject;

                Shield3obj.transform.parent = targetplayer.transform;
                Shield3obj.transform.localPosition = new Vector3(0f, -3f, -1f);

                Destroy(targetShield2.gameObject);
                
            }

            if (shieldhp == 0)
            {
                StartCoroutine("newShield");
            }
        }
     }

    //3回衝突するとPlayerスクリプトのCanon()実行
    void newShield()
    {
        GameObject targetPlayer = GameObject.Find("Player");
        targetPlayer.GetComponent<Player>().Camon();
        Destroy(shield3.gameObject);
    }

}
