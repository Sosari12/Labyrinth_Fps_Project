using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{

    public Text timerText;
    private float timerNumber;
    int seconds;
    float minutes;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timerNumber += Time.deltaTime;
        seconds = (int)(timerNumber % 60);
        minutes = Mathf.Floor(timerNumber / 60);
        timerText.text ="Time: "+ minutes + ":" + seconds;
    }


}
