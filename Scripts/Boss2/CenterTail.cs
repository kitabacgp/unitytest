using UnityEngine;
using System.Collections;

public class CenterTail : MonoBehaviour {

    [SerializeField]
    GameObject bossBullet;

    GameObject player;

    // Use this for initialization
    void Start ()
    {
        player = GameObject.Find("Player");
        StartCoroutine(shotCenter());
    }
	
	// Update is called once per frame
	void Update ()
    {

	}

    IEnumerator shotCenter()
    {
        Quaternion rota = Quaternion.identity;
        int number = Tail.weakTailNumber;

        if (1 <= number && number <= 6)
        {
            //playerのほうへの角度
            rota.eulerAngles = new Vector3(0, 0, GetAim(this.transform.position, player.transform.position));
        }
        else if (number > 6)
        {
            rota.eulerAngles = new Vector3(0, 0, Random.Range(0.0f,360.0f));
        }

        if (1 <= number)
            Instantiate(bossBullet, this.transform.position, rota);

        if (number == 0)
        {
            yield return new WaitForSeconds(0.1f);
        }
        else if(number <=3)
        {
            yield return new WaitForSeconds(4.0f);
        }
        else if (number <= 6)
        {
            yield return new WaitForSeconds(2.0f);
        }
        else
        {
            yield return new WaitForSeconds(0.2f);
        }
        StartCoroutine(shotCenter());
    }

    public float GetAim(Vector2 p1, Vector2 p2)
    {
        float dx = p2.x - p1.x;
        float dy = p2.y - p1.y;
        float rad = Mathf.Atan2(dy, dx);
        return rad * Mathf.Rad2Deg - 90;
    }
}
