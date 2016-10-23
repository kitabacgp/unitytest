using UnityEngine;
using System.Collections;

public class SEPlay : MonoBehaviour {

    //再生したあと停止
    void Update()
    {
        if (!GetComponent<AudioSource>().isPlaying)
        {
            Destroy(gameObject);
        }
    }
}
