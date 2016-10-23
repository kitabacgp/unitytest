using UnityEngine;
using System.Collections;

public class Boss2Bullet : MonoBehaviour {

    [SerializeField]
    int spead=10;

    float time;

	// Use this for initialization
	void Start ()
    {
        time = 0;
	}
	
	// Update is called once per frame
	void Update ()
    {
        transform.Translate(Vector3.up * Time.deltaTime * spead);
        time += Time.deltaTime;
        if (time > 2.0f)
        {
            Destroy(this.gameObject);
        }

        //z座標を０に
        Vector3 nowPos = transform.position;
        nowPos.z = 0;
        transform.position = nowPos;
    }

}
