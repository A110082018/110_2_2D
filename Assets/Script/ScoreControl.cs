using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class ScoreControl : MonoBehaviour
{
    public Text textScore;
    public Text textBest;
    public string ScB;

    public static int score = 00;
    public int best = 00;

    


    // Start is called before the first frame update
    void Start()
    {
        ScB = File.ReadAllText("Assets/Resources/ScoreBoard.txt");
        Debug.Log(ScB[0]);
        Debug.Log(ScB[1]);

        textScore.text = "SCORE  00";
    }

    // Update is called once per frame
    void Update()
    {
        textScore.text = "SCORE  " + score;
    }
}
