using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterControl : MonoBehaviour
{
    public float speed = 5;

    public GameObject explosion;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(-speed * Time.deltaTime, 0, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //collision: wall = destory
        if (collision.name == "Wall_L")
            Destroy(this.gameObject);

        //collision: bullet = destory
        if (collision.name == "BulletPrefab(Clone)")
        {
            Destroy(this.gameObject);
            Destroy(collision.gameObject);
            Instantiate(explosion, transform.position, transform.rotation);
            ScoreControl.score += 20;
        }
    }
}
