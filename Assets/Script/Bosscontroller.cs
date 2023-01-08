using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bosscontroller : MonoBehaviour
{
    public GameObject Shot;
    public float HP = 100;
    public float MAXHP = 100;
    public float speed = 0.1f;
    private Rigidbody2D rb;
    public float _moveRange = 3.0f;
    float centerY;
    private int counter = 0;
    

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("BossShot", 1, 0.03f);

        centerY = this.gameObject.transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }
    void BossShot()
    {
        counter++;
        Vector3 ShotAngle = new Vector3(0, 0, Random.Range(0, 360));
        if (counter % 2 == 0)
        {
            Instantiate(Shot, transform.position, Quaternion.Euler(ShotAngle));
        }
    }
    void Movement()
    {
        if (_moveRange != 0)
        {
            this.gameObject.transform.position += new Vector3(0, speed * Time.deltaTime, 0);
            if (this.gameObject.transform.position.y >= centerY + _moveRange || this.gameObject.transform.position.y <= centerY - _moveRange)
            {
                //Debug.Log(this.transform.position.x);
                speed = -speed;
                //this.gameObject.transform.position += new Vector3(_moveSpeed * Time.deltaTime, 0, 0);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (gameObject.tag =="PlayerShot")
        {
            /* BulletControl bullet = gameObject.GetComponent<BulletControl>();
             HP -= bullet.ATK;
            */
            HP -= 20;
        }

        if (HP <= 0)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }

    }

    
}
