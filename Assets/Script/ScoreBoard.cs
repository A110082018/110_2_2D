using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreBoard : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
        TextAsset txt = Resources.Load("ScoreBoard") as TextAsset;
        Debug.Log(txt);

        
        string[] str = txt.text.Split('\n');
        
        Debug.Log("str[0]= "+str[0]);
        Debug.Log("str[1]= "+str[1]);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
