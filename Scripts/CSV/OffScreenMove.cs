using UnityEngine;
using System.Collections;

public enum EnemyDirection
{
    NONE, UP, DOWN, LEFT, RIGHT
}

public class OffScreenMove : MonoBehaviour {

    private EnemyDirection enemyDirection;

    [SerializeField, Tooltip("敵の登場時間")]
    int second = 70;

    int outSpeed ;
    //動く方向の単位vector
    [System.NonSerialized]
    public Vector3 dir;
    //画面内にいるかどうか
    [System.NonSerialized]
    public bool onScreen;

    // Use this for initialization
    void Start ()
    {
        onScreen = false;
        outSpeed = 200 / second;
    }
	
	// Update is called once per frame
	void Update ()
    {
        Vector2 enemyViewportPoint = Camera.main.WorldToViewportPoint(this.transform.position);
        
        if (!onScreen)
        {
            //画面内にいるかどうか
            onScreen = enemyViewportPoint.x > 0.0f && enemyViewportPoint.x < 1.0f &&
                enemyViewportPoint.y > 0.0f && enemyViewportPoint.y < 1.0f;

            //敵を動かす
            this.transform.position += dir * outSpeed * Time.deltaTime;
        }

        if (onScreen)
        {
            
            //ここに敵が動く処理

            //少し余裕を持った画面外判定
            bool outScreen = !(enemyViewportPoint.x > -0.2f && enemyViewportPoint.x < 1.2f &&
                enemyViewportPoint.y > -0.2f && enemyViewportPoint.y < 1.2f);
            if (outScreen)
            {
                //画面外に行ったら消す
                Destroy(this.gameObject);
            }
        }
    }

    public EnemyDirection enemyDireProp
    {
        get { return enemyDirection; }
        set { enemyDirection = value; }
    }

    public void setDirection()
    {
        switch (enemyDirection)
        {
            case EnemyDirection.UP:
                dir = new Vector3(0, -1, 0);
                break;
            case EnemyDirection.DOWN:
                dir = new Vector3(0, 1, 0);
                break;
            case EnemyDirection.LEFT:
                dir = new Vector3(1, 0, 0);
                break;
            case EnemyDirection.RIGHT:
                dir = new Vector3(-1, 0, 0);
                break;
            default: break;
        }
    }
}
