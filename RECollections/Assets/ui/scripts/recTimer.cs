using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class recTimer : MonoBehaviour
{
    public Text timerText;
    public float timer = 0.0f;
    public bool recording = false;

    // Start is called before the first frame update
    void Start()
    {
        timerText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (recording)
        {
            timer += Time.deltaTime;
            timerText.text = timer.ToString("F2");
        }
    }
}

// Path: Assets/ui/scripts/recordButton.cs