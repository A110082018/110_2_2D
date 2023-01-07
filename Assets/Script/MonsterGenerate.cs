using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterGenerate : MonoBehaviour
{
    public GameObject Monster;
    public float timer = 0;
    public float period = 0.5f;
    float y;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer>period)
        {
            timer = 0;
            y = Random.Range(-3, 4);
            Instantiate(Monster, new Vector3(10, y, 0), transform.rotation);
        }
    }
}
