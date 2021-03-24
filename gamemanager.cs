using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gamemanager : MonoBehaviour
{
    public AudioSource theMusic;

    public bool starPlaying;

    public ballGenerator theBG;

    public static gamemanager instance;

    public int currentScorec = 0;
    public int scorePerNote = 100;
    public int scorePerGoodNote = 125;
    public int scorePerPerfectNote = 150;

    public float maxHp = 0;
    public float nowEnemyHp;
    public float nowHp;
    public float normalHp = 0.05f;
    public float goodHp = 0.1f;
    public float perfectHp = 0.15f;

    public int currentMultiplier;
    public int multiplierTracker; 
    public int[] multiplierThresholds;

    public Image hp1;
    public Image hp2;


    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (!starPlaying)
        {
            starPlaying = true;
            theBG.hasStarted = true;
            theMusic.Play();
            maxHp = 10;
            nowEnemyHp = maxHp;
            nowHp = maxHp;
            
        }
    }

    public void NoteHit()
    {
       
        if (currentMultiplier - 1 < multiplierThresholds.Length)
        {
            multiplierTracker++;

            if (multiplierThresholds[currentMultiplier - 1] <= multiplierTracker)
            {
                multiplierTracker = 0;
                currentMultiplier++;
            }
        }



        //currentScorec += scorePerNote * currentMultiplier;
        
    }

    public void NormalHit()
    {
        nowEnemyHp = nowEnemyHp - nowEnemyHp * normalHp* currentMultiplier;
        hp2.transform.localScale = new Vector3 ( (nowEnemyHp / maxHp), hp2.transform.localScale.y, hp2.transform.localScale.z) ;
        currentScorec += scorePerNote * currentMultiplier;
        NoteHit();
    }
    public void GoodHit()
    {
        nowEnemyHp = nowEnemyHp - nowEnemyHp * goodHp*currentMultiplier;
        hp2.transform.localScale = new Vector3((nowEnemyHp / maxHp), hp2.transform.localScale.y, hp2.transform.localScale.z);
        currentScorec += scorePerGoodNote * currentMultiplier;
        NoteHit();
    }
    public void PerfectHit()
    {
        nowEnemyHp = nowEnemyHp - nowEnemyHp * perfectHp*currentMultiplier;
        hp2.transform.localScale = new Vector3((nowEnemyHp / maxHp), hp2.transform.localScale.y, hp2.transform.localScale.z);
        currentScorec += scorePerPerfectNote * currentMultiplier;
        NoteHit();
    }
    public void NoteMissed()
    {
        nowHp = nowHp - nowHp * 0.05f;
        hp1.transform.localScale = new Vector3((nowHp / maxHp), hp1.transform.localScale.y, hp1.transform.localScale.z);
        currentMultiplier = 1;
        multiplierTracker = 0;

      
    }
}
