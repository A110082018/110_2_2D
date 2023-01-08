using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenuSetting : MonoBehaviour
{
    public float speed = 1.0f;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //esc = close
        if(Input.GetKeyDown(KeyCode.Escape))
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
        }
    }

    //Button Start
    public void ButtonStart()
    {
        print("Start");
        SceneManager.LoadScene(3);
    }
    //Button ScoreBoard
    public void ButtonScoreBoard()
    {
        print("ScoreBoard");
        SceneManager.LoadScene(1);
    }

    //Button Exit
    public void ButtonExit()
    {
        print("EXIT");
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
    }
    //Button Back
    public void ButtonBack()
    {
        print("ScoreBoard");
        SceneManager.LoadScene(0);
    }

}
