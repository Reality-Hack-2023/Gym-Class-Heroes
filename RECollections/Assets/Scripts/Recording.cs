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
    private string mic = null;

    // Start is called before the first frame update
    void Start()
    {
        // get the audioSource
        audioSource = GetComponent<AudioSource>();
        // get the audio manager object
        memoryAudioManager = FindObjectOfType<MemoryAudioManager>();
        // get the oculus microphone from the audio manager
        mic = memoryAudioManager.microphone;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartRecording()
    {
        // if there is no recording
        if audioSource.clip != null)
        {
            audioSource.clip = Microphone.Start(mic, false, 10, 44100);
        }
        audioSource.clip = Microphone.Start(mic, false, 10, 44100);
    }

    public void StopRecording()
    {
        Microphone.End(mic);
        audioSource.Play();
    }
}
