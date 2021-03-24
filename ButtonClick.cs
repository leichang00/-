using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonClick : MonoBehaviour
{
    public int sce;//場景編號
    public Text loadText;
    IEnumerator DisplayLoadingScreen(int scene)
    {
        int dp = 0;
        float tp = 0;
  
        AsyncOperation async = SceneManager.LoadSceneAsync(scene);
        async.allowSceneActivation = false;

        while (async.progress < 0.9f)
        {
            tp = (float)async.progress * 1000;
            while (dp < tp) {
                ++dp;
                loadText.text = dp.ToString() + "%";
                yield return new WaitForEndOfFrame();
            }
            tp = 100;
            while (dp < tp)
            {
                ++dp;
                loadText.text = dp.ToString() + "%";
                yield return new WaitForEndOfFrame();
            }
     
        }

        async.allowSceneActivation = true;
    }
    // Start is called before the first frame update
    void Start()
    {
        
        StartCoroutine(DisplayLoadingScreen(sce));
    }

    // Update is called once per frame
    void Update()
    {

    }
}
