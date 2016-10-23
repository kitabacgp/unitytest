using UnityEngine;
using System.Collections;

public class Light : MonoBehaviour {

    

    IEnumerator Start()
    {
        var targetPlayer = GameObject.Find("Player");
        var thisColor = this.GetComponent<SpriteRenderer>().color;

        while (true)
        {

            //時機が回転していなければ
            if (Mathf.Round(targetPlayer.transform.eulerAngles.z) % 90 == 0)
            {

                this.GetComponent<Collider2D>().enabled = true;
                this.GetComponent<SpriteRenderer>().color = thisColor;
            }

            else//回転していれば
            {
                this.GetComponent<Collider2D>().enabled = false;
                this.GetComponent<SpriteRenderer>().color = new Color(0,0,0,0);
            }

            yield return new WaitForSeconds(0.05f);
        }
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
