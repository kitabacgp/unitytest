using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SceneShift : MonoBehaviour {

    public static SceneShift Instance;

    void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update () {
	
	}

    public void toStage1()
    {
        SceneManager.LoadScene("Stage1");
    }
    public void toStage2()
    {
        SceneManager.LoadScene("Stage2");
    }
    public void toTitle()
    {
        SceneManager.LoadScene("Title");
    }
    public void toClear()
    {
        SceneManager.LoadScene("Clear");
    }
    public void toGameOver()
    {
        SceneManager.LoadScene("GameOverTest");
    }

}
