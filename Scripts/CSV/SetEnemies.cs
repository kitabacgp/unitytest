using UnityEngine;
using System.Collections;

public class SetEnemies : MonoBehaviour {

    CSVReader csvReader;
    [SerializeField]
    GameObject enemy1, enemy2;
    [SerializeField]
    GameObject upEnemies, downEnemies, leftEnemies, rightEnemies;

    // Use this for initialization
    void Start ()
    {
        csvReader = GameObject.Find("Reader").GetComponent<CSVReader>();
        setAllEnemy(csvReader.stageEnemyDatas,csvReader.height);
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void setAllEnemy(string[,] enemyData,int height)
    {
        for (int i = 0; i < height; i++)
        {
            GameObject enemy=null;
            switch (int.Parse(enemyData[i, 3]))
            {
                case 1:
                    enemy = Instantiate(enemy1,Vector2.zero,Quaternion.identity) as GameObject;
                    break;
                case 2:
                    enemy = Instantiate(enemy2, Vector2.zero, Quaternion.identity) as GameObject;
                    break;
                default:print("エラー");break;
            }

            Vector2 enemyPos=Vector2.zero;
            float distance = float.Parse(enemyData[i, 1]) * 2;
            Vector3 ViewportToWorld
                = Camera.main.ViewportToWorldPoint
                (new Vector3(float.Parse(enemyData[i, 2]), float.Parse(enemyData[i,2]),10));
            float width_x = ViewportToWorld.x;
            float width_y = -ViewportToWorld.y;
            
            //画面右上のワールド座標
            Vector3 rightUpPoint = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, 10));
            //画面左下のワールド座標
            Vector3 leftDownPoint = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 10));

            EnemyDirection dir = EnemyDirection.NONE;

            switch (enemyData[i, 0])
            {
                case "up":
                    enemy.transform.parent = upEnemies.transform;
                    enemyPos = new Vector2(width_x, rightUpPoint.y + distance);
                    dir = EnemyDirection.UP;
                    break;
                case "down":
                    enemy.transform.parent = downEnemies.transform;
                    enemyPos = new Vector2(width_x, leftDownPoint.y - distance);
                    dir = EnemyDirection.DOWN;
                    break;
                case "left":
                    enemy.transform.parent = leftEnemies.transform;
                    enemyPos = new Vector2(leftDownPoint.x - distance, width_y);
                    dir = EnemyDirection.LEFT;
                    break;
                case "right":
                    enemy.transform.parent = rightEnemies.transform;
                    enemyPos = new Vector2(rightUpPoint.x + distance, width_y);
                    dir = EnemyDirection.RIGHT;
                    break;
                default:
                    print("エラー");
                    break;
            }
            enemy.transform.position = enemyPos;
            enemy.transform.localScale = Vector3.one ;
            enemy.GetComponent<OffScreenMove>().enemyDireProp = dir;
            enemy.GetComponent<OffScreenMove>().setDirection();
        }
    }
}
