using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class hpContorl : MonoBehaviour
{
    public Image hp1;
    public Image hp2;
    public static hpContorl Hp;
    // Start is called before the first frame update
    void Start()
    {
       

    }

    // Update is called once per frame
    void Update()
    {
        Hp = this;
    }
    public void DecreaseHp1()
    {
       
        hp1.fillAmount = 0.1f;
    }
    public void DecreaseHp2(float a )
    {
        
        hp2.fillAmount = a;
    }
}
