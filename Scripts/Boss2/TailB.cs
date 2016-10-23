using UnityEngine;
using System.Collections;

public class TailB : MonoBehaviour {


    [SerializeField]
    GameObject bossBullet;

    GameObject player;

	// Use this for initialization
	void Start () {

        player = GameObject.Find("Player");
        StartCoroutine(shotB());
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    IEnumerator shotB()
    {
        Quaternion rota = Quaternion.identity;

        //弾Bを生成してplayerのほうにむかせる
        rota.eulerAngles = new Vector3(0, 0, GetAim(this.transform.position, player.transform.position));
        GameObject bullet =(GameObject)Instantiate(bossBullet, this.transform.position, rota);

        if (GetComponent<Tail>().weaken)
        {
            bullet.transform.localScale /= 2;
        }
        yield return new WaitForSeconds(2.0f);
        StartCoroutine(shotB());
    }


    public float GetAim(Vector2 p1, Vector2 p2)
    {
        float dx = p2.x - p1.x;
        float dy = p2.y - p1.y;
        float rad = Mathf.Atan2(dy, dx);
        return rad * Mathf.Rad2Deg - 90;
    }
}
