using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MemoryAudioManager : MonoBehaviour
{
    // the name of the microphone
    public string microphone = null;

    // Start is called before the first frame update
    void Start()
    {
        // Get list of Microphone devices and print the names to the log
        foreach (var device in Microphone.devices)
        {
            // check if the microphone is the oculus' microphone
            if (device == "Headset Microphone (Oculus Virtual Audio Device)")
            {
                // if it is assign it to the microphone variable
                microphone = device;
                // log to console
                Debug.Log("The Oculus Microphone is named: " + microphone);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
