using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WizardControls : MonoBehaviour
{
    
    public float speed = 0.005f;
    private bool alive = true;
    private Rigidbody2D rb;

    //Heart Control
    public GameObject Heart1;
    public GameObject Heart2;
    public GameObject Heart3;
    public int HeartNum = 3;

    //UI
    public GameObject textFail;
    public GameObject textRestart_vis;
    public Text textRestart_text;
    public GameObject textPass;
    public Text textTime;

    //Def Bullet
    public GameObject Bullet;
    public GameObject Bullet1; 
    public GameObject Bullet2;

    //Audio
    public AudioSource m_audioSource;
    public AudioClip m_hittedSound;
    public string Scenes;

    //Animation
    private Animator Anim;
    private SpriteRenderer mySpriteRenderer;
    


    // Start is called before the first frame update
    void Start()
    {
        //Animation
        Anim = GetComponent<Animator>();
        mySpriteRenderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();

        textFail.SetActive(false);
        textRestart_vis.SetActive(false);
        textPass.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (alive)
        {

        }
        
        //Time limit = 30
        if(Time.time>30)
        {
            
            if(ScoreControl.score >= 400)
            {
                textPass.SetActive(true);
                if (SceneManager.GetActiveScene().buildIndex == 2)
                    SceneManager.LoadScene(3);
                else
                    SceneManager.LoadScene(0);
            }
            else
            {
                textFail.SetActive(true);
                textRestart_vis.SetActive(true);
                InvokeRepeating("showHide", 0.5f, 0.5f);
            }
        }

        //move control
        /*
        float v = Input.GetAxis("Vertical");
        float h = Input.GetAxis("Horizontal");

        Vector3 push = new Vector3(h, v, 0) * speed;
        transform.Translate(h, v, 0);
        rb.AddForce(push * Time.deltaTime);
        */
        
        if (Input.GetKey(KeyCode.RightArrow))
            transform.Translate(speed, 0, 0);
        if (Input.GetKey(KeyCode.LeftArrow))
            transform.Translate(-speed, 0, 0);
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(0, speed, 0);
            transform.position -= new Vector3(speed, 0);
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(0, -speed, 0);
            transform.position += new Vector3(speed, 0);
        }

        //bullet control || Attack
        if (Input.GetKeyDown(KeyCode.X))
        {
            SceneManager.LoadScene("Games");
        }
        if (Input.GetKeyDown(KeyCode.Space))
            {
                Instantiate(Bullet, transform.position+new Vector3(0,1.5f,0), transform.rotation);
                m_audioSource.Play();
                Anim.SetTrigger("attack");
                transform.position += new Vector3(speed, 0);
            }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Instantiate(Bullet1, transform.position + new Vector3(0, 1.5f, 0), transform.rotation);
            m_audioSource.Play();
            Anim.SetTrigger("attack");
            transform.position += new Vector3(speed, 0);
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            Instantiate(Bullet2, transform.position + new Vector3(0, 1.5f, 0), transform.rotation);
            m_audioSource.Play();
            Anim.SetTrigger("attack");
            transform.position += new Vector3(speed, 0);
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //hitted by enemy
        if (collision.tag == "Bullet") 
        {
            Destroy(collision.gameObject);
            m_audioSource.PlayOneShot(m_hittedSound);
            Anim.SetTrigger("hurt");
            HeartNum--;
            if (HeartNum == 2)
                Heart3.SetActive(false);
            else if (HeartNum == 1)
                Heart2.SetActive(false);
            else if (HeartNum == 0)
            {
                Heart1.SetActive(false);
                Anim.SetTrigger("die");                
                this.gameObject.SetActive(false);

                //UI: Fail
                textFail.SetActive(true);
                textRestart_vis.SetActive(true);
                InvokeRepeating("showHide", 0.5f, 0.5f);
                
            }

        }
    }
    //word shine
    private void showHide() 
    {
        if (textRestart_text.text == "")
        {
            textRestart_text.text = "- press F1 to Restart -";
        }
        else
        {
        textRestart_text.text = "";
        }
    }


}
