using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameControl : MonoBehaviour
{
    //BG
    public float BGSpeed = 0.7f;
    public GameObject GameBackground1;
    public GameObject GameBackground2;

    //text UI
    public GameObject textRestart_vis;
    public GameObject textFail;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // press F1 to reboot
        if(Input.GetKeyDown(KeyCode.F1))
        {
            TimeControl.GameTime = 0;
            textFail.SetActive(false);
            textRestart_vis.SetActive(false);

            ScoreControl.score = 00;
            SceneManager.LoadScene(2);
            SceneManager.LoadScene(0);

            


        }
        // press esc to close the game
        if(Input.GetKeyDown(KeyCode.Escape))
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
        }

        //Game Background
        if (GameBackground1.transform.position.x < -20 )
        {
            GameBackground1.transform.position = new Vector3(18,0,0);
        }
        GameBackground1.transform.Translate(-BGSpeed * Time.deltaTime, 0, 0);

        if (GameBackground2.transform.position.x < -20 )
        {
            GameBackground2.transform.position = new Vector3(18,0,0);
        }
        GameBackground2.transform.Translate(-BGSpeed * Time.deltaTime, 0, 0);
    }
}
