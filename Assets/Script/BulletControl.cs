using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletControl : MonoBehaviour
{
    public float speed = 10;
    public int ATK = 10;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(speed * Time.deltaTime, 0, 0);
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
       
        if (collision.name == "wall_R")
            Destroy(this.gameObject , 3);
        if (collision.name == "Boss")
            Destroy(this.gameObject);
    }
}
