using UnityEngine;
using System.Collections;

public class TailA : MonoBehaviour {


    [SerializeField]
    GameObject bossBullet;

    float time, timeA;


    void Start()
    {
        time = 0;
        StartCoroutine(shot());
    }

    // Update is called once per frame
    void Update ()
    {
        time += Time.deltaTime;
        timeA = time % 6;
    }

    IEnumerator shot()
    {
        if (transform.localPosition.x > 0)
        {
            shotA(135, 3.0f);
        }
        else
        {
            shotA(-135, 3.0f);
        }
        yield return new WaitForSeconds(3.0f);
        shotA(180, 3.0f);
        yield return new WaitForSeconds(3.0f);
        StartCoroutine(shot());
    }

    void shotA(int degree, float endTime)
    {
        StartCoroutine(shotA(timeA, timeA + endTime, degree));
    }

    IEnumerator shotA(float startTime, float endTime, int degree)
    {
        Quaternion rotation = Quaternion.identity;
        if (!this.GetComponent<Tail>().weaken)
        {
            rotation.eulerAngles = new Vector3(0, 0, degree);
            Instantiate(bossBullet, this.transform.position, rotation);
        }
        yield return new WaitForSeconds(0.1f);
        if (startTime <= timeA && timeA < endTime)
        {
            StartCoroutine(shotA(startTime, endTime, degree));
        }
    }
}
