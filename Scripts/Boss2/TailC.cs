using UnityEngine;
using System.Collections;

public class TailC : MonoBehaviour {


    [SerializeField]
    GameObject bossBullet;

    // Use this for initialization
    void Start ()
    {
        StartCoroutine(shotC());
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    IEnumerator shotC()
    {
        if (!GetComponent<Tail>().weaken)
        {
            Quaternion qua;
            if (transform.localPosition.x > 0)
            {
                qua = Quaternion.Euler(new Vector3(0, 0, 135));
            }
            else
            {
                qua = Quaternion.Euler(new Vector3(0, 0, -135));
            }
            Instantiate(bossBullet, this.transform.position, qua);
        }
        yield return new WaitForSeconds(1);
        StartCoroutine(shotC());
    }
}
