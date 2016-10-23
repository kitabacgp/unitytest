using UnityEngine;
using System.Collections;

public class Tail : MonoBehaviour {

    [SerializeField]
    float tailHP = 100.0f;

    float MaxHP;

    [SerializeField, Tooltip("ライト1秒あたりの尾へのダメージ量")]
    float lightDamagePerSecond = 15.0f;

    [SerializeField, Range(0.0f, 1.0f), Tooltip("HP最大を１とした時の弱体化の閾値")]
    float weakHP = 0.3f;

    [SerializeField, Tooltip("尾の一秒あたりの回復量")]
    float recoverPerSecond = 3.0f;

    //尾が弱っている状態であるかどうか
    //[System.NonSerialized]
    public bool weaken = false;

    //弱っている尾が何本あるか
    public static int weakTailNumber=0;

    //前フレームの弱体状態を保持
    bool before;

    // Use this for initialization
    void Start ()
    {
        MaxHP = tailHP;
        before = weaken;
    }
	
	// Update is called once per frame
	void Update ()
    {
        //尾が弱っているか判定
        if (tailHP <= MaxHP*weakHP)
        {
            weaken = true;
        }
        else
        {
            weaken = false;
        }

        //前フレームからweakenに変更があったかどうか
        if (before != weaken)
        {
            if (weaken)
            {
                weakTailNumber++;
            }
            else
            {
                weakTailNumber--;
            }
        }
        //前フレームの弱体状態を保持
        before = weaken;


        if (tailHP < MaxHP)
        {
            //徐々に回復
            tailHP += recoverPerSecond * Time.deltaTime;
        }
        else
        {
            tailHP = MaxHP;
        }
	}

    void OnTriggerStay2D(Collider2D col)
    {
        if (col.tag == "Light")
        {
            //しっぽのHPを減らす
            tailHP -= lightDamagePerSecond * Time.deltaTime;
        }
    }


    public float GetAim(Vector2 p1, Vector2 p2)
    {
        float dx = p2.x - p1.x;
        float dy = p2.y - p1.y;
        float rad = Mathf.Atan2(dy, dx);
        return rad * Mathf.Rad2Deg - 90;
    }
}
