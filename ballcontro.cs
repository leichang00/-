using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;
public class ballcontro : MonoBehaviour
{
    public float beatTempo;
    GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        beatTempo = beatTempo / 30f;
        this.player = GameObject.Find("line");
    }

    // Update is called once per frame
    void Update()
    {

        transform.position -= new Vector3(0f, beatTempo * Time.deltaTime, 0f);
        if (transform.position.y < -4.0f)
        {
            gamemanager.instance.NoteMissed();
            Destroy(gameObject);
        }

        /*Vector2 p1 = transform.position;
        Vector2 p2 = this.player.transform.position;
        Vector2 dir = p1 - p2;
        float d = dir.magnitude;
        float r1 = 0.5f;
        float r2 = 0.2f;

        if (d < r1 + r2 && Input.GetMouseButtonDown(0))
        {
            Destroy(gameObject);
        }
       
        */
    }
}