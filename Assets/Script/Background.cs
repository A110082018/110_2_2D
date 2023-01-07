using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    public float MenuSpeed = 0.3f;
    public GameObject Menu1;
    public GameObject Menu2;


    // Start is called before the first frame update
    void Start()
    {

        
    }

    // Update is called once per frame
    void Update()
    {
        //Menu Backgorund
        if (Menu1.transform.position.y < -12 )
        {
            Menu1.transform.position = new Vector3(6,17,0);
        }
        Menu1.transform.Translate(0, -MenuSpeed * Time.deltaTime, 0);

        if (Menu2.transform.position.y < -12 )
        {
            Menu2.transform.position = new Vector3(6,17,0);
        }
        Menu2.transform.Translate(0, -MenuSpeed * Time.deltaTime, 0);


        
    }
}
