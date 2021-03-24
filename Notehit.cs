using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Notehit : MonoBehaviour
{
    public bool canBePressed;
 

    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (canBePressed)
            {
                gameObject.SetActive(false);


                //gamemanager.instance.NoteHit();


                if (transform.position.y <= -2.35f && transform.position.y > -2.75f || transform.position.y < -3.15f && transform.position.y >= -3.45f)
                {
                    gamemanager.instance.NormalHit();
                } 
                else if (transform.position.y <= -2.75f && transform.position.y > -3.0f || transform.position.y < -3.0f && transform.position.y >= -3.15f)
                {
                    gamemanager.instance.GoodHit();
                } 
                else if(transform.position.y == -3.0f)
                {
                    gamemanager.instance.PerfectHit(); 
                }

            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Activator")
        {
            canBePressed = true;
            
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.tag == "Activator")
        {
            canBePressed = false;

            
        }
    }
}
