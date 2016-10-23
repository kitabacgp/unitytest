using UnityEngine;

public class enemybullet : MonoBehaviour
{
    public int speed = 12;
    void Update()
    {
        GetComponent<Rigidbody2D>().velocity = transform.up.normalized * speed;
    }
}