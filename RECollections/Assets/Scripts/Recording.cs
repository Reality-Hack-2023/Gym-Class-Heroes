using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recording : MonoBehaviour
{
    
    // this audiosource
    [SerializeField] private AudioSource audioSource;

    // CACHED REFERENCES //
    MemoryAudioManager memoryAudioManager;
    // caching the mic from the audio manager
    public string mic = null;


    // Start is called before the first frame update
    void Start()
    {
        // get the audioSource
        audioSource = GetComponent<AudioSource>();
        // get the audio manager object
        memoryAudioManager = FindObjectOfType<MemoryAudioManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void StartRecording()
    {
        
        // if there is no recording
        if (audioSource.clip == null)
        {
            // get the oculus microphone from the audio manager
            mic = memoryAudioManager.microphone;

            // record the clip
            audioSource.clip = Microphone.Start(mic, false, 10, 44100);
        }
        // if there is a recording
        else
        {
            // play it
            audioSource.Play();
        }
    }

    public void StopRecording()
    {
        // stop recording
        Microphone.End(mic);
    }

}
