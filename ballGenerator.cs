using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballGenerator : MonoBehaviour
{
    private float time = 0;
    public gamemanager music;
    public bool hasStarted;
    private bool end;
    int i = 0;
    public GameObject ball;
    float[] span = new float[] {0.432f,0.69f,0.281f,0.604f,0.28f,1.184f,0.59f,0.3f,0.301f,0.508f,
        1.114f,0.633f,0.3f,0.2f,0.7f,0.2f,0.5f,0.6f,0.6f,0.3f,1.0f,0.2f,0.3f,0.5f,0.3f,0.5f,0.4f,0.2f,0.4f,
        0.3f,0.6f,0.8f,0.3f,0.4f,0.4f,0.6f,0.5f,0.3f,0.1f,0.1f,0.1f,0.4f,0.3f,0.4f,0.4f,0.9f,0.1f,0.2f,0.1f,0.4f,0.3f,1.1f,0.1f,0.7f,0.1f,0.1f,0.6f,0.3f,0.2f,0.7f,0.3f,0.3f,0.3f,0f};
    float delta = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!hasStarted) { }
        else
        {
            end = false;
            if (!end)
            {
                this.delta += Time.deltaTime;
                if (this.delta > this.span[i])
                {
                    this.delta = 0;
                    GameObject go = Instantiate(ball) as GameObject;
                    go.transform.position = new Vector3(0, 1.5f, 0);
                    time = time + span[i];
                    i++;

                }

                if (this.span[i] == 0)
                {
                    end = true;
      
                }
            }
            if (end)
            {
                this.delta = 0;
                float mt;
                mt = music.theMusic.clip.length;
                span[i] = mt - time;
                
                this.delta += Time.deltaTime;
                if (this.delta > this.span[i])
                {
                    this.delta = 0;
                }
            }
        
        }
        

    }

}