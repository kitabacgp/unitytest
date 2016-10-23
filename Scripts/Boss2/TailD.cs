using UnityEngine;
using System.Collections;

public class TailD : MonoBehaviour {
    
    [SerializeField]
    GameObject bossBullet;

    GameObject player;

    // Use this for initialization
    void Start () {
        player = GameObject.Find("Player");
        StartCoroutine(shotD());
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    IEnumerator shotD()
    {
        Quaternion rota = Quaternion.identity;

        //弾Dを生成してplayerのほうにむかせる
        rota.eulerAngles = new Vector3(0, 0, GetAim(this.transform.position, player.transform.position));
        Instantiate(bossBullet, this.transform.position, rota);

        if (!GetComponent<Tail>().weaken)
        {
            yield return new WaitForSeconds(1.0f);
        }
        else
        {
            yield return new WaitForSeconds(2.0f);
        }
        StartCoroutine(shotD());
    }


    public float GetAim(Vector2 p1, Vector2 p2)
    {
        float dx = p2.x - p1.x;
        float dy = p2.y - p1.y;
        float rad = Mathf.Atan2(dy, dx);
        return rad * Mathf.Rad2Deg - 90;
    }
}
