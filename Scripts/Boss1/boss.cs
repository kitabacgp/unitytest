using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class boss : MonoBehaviour
{

    // 弾のPrefab
    public GameObject enemybullet;

    // 弾の作成
    public void Shot (Transform origin)
    {
        print("ボスが撃った");
        Instantiate (enemybullet, origin.position, origin.rotation);
    }

}