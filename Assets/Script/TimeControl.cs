using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeControl : MonoBehaviour
{
    public static float GameTime = 0;
    public Text textTime;
    // Start is called before the first frame update
    void Start()
    {
        GameTime = 0;
        
    }

    // Update is called once per frame
    void Update()
    {
        GameTime += Time.deltaTime;
        textTime.text = "TIME  "+GameTime.ToString("f1");
        
    }
}
