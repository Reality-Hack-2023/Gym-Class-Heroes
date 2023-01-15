using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountdownTimer : MonoBehaviour
{
    public float startTime = 3.0f;
    public bool startTimer = false;
    public Text timerText;

    public bool timerDone = false;

    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (startTimer)
        {
            startTime -= Time.deltaTime;
            int startTimeInt = (int)startTime;
            timerText.text = $"{startTimeInt}";
        }
        

        if (startTime <= 0.0f)
        {
            startTimer = false;
            timerDone = true;
            this.gameObject.SetActive(false);
        }
    }
}
