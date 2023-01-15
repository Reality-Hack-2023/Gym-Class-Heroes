using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Recording : MonoBehaviour
{
    public float delay = 3f;
    public UnityEvent delayedEvent;

    public Material startMat = null;
    public Material recordedMat = null;

    public Renderer rend;
    public GameObject recordingIcon = null;
    public GameObject speakerIcon = null;

    public CountdownTimer timer;

    Coroutine coroutine;


    // this audiosource
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private GameObject memory = null;

    private bool hasMemory = false;
    private bool isRecording = false;

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
        audioSource.clip = null;
        rend.material = startMat;
        recordingIcon.gameObject.SetActive(false);
        speakerIcon.gameObject.SetActive(false);
    }


    public void StartRecording()
    {

        // if there is no recording
        if (!hasMemory)
        {
            timer.gameObject.SetActive(true);
            timer.startTimer = true;

            coroutine = StartCoroutine(Record());

        }

        // if there is a recording
        else
        {
            // play it
            audioSource.Play();
            speakerIcon.gameObject.SetActive(true);
        }
    }

    public void StopRecording()
    {
        StopCoroutine(coroutine);
        recordingIcon.gameObject.SetActive(false);
        speakerIcon.gameObject.SetActive(false);
        // stop recording
        Microphone.End(mic);
        if (!hasMemory || isRecording)
        {
            if (timer.timerDone)
            {
                CreateMemory.Instance.Create();
                rend.material = recordedMat;
                
                StartCoroutine(FireAfterDelay());
            }

        }
        if (!hasMemory && !isRecording)
        {
            timer.startTime = 3.0f;
            timer.gameObject.SetActive(false);
            rend.material = startMat;
        }
        else
        {
            rend.material = recordedMat;
            StartCoroutine(FireAfterDelay());
            audioSource.Stop();
        }
        isRecording = false;


    }


    private IEnumerator FireAfterDelay()
    {
        yield return new WaitForSeconds(delay);
        delayedEvent?.Invoke();
    }

    private IEnumerator Record()
    {
        yield return new WaitForSeconds(3.0f);
        isRecording = true;
        recordingIcon.gameObject.SetActive(true);
        // get the oculus microphone from the audio manager
        mic = memoryAudioManager.microphone;

        // record the clip
        audioSource.clip = Microphone.Start(mic, false, 10, 44100);

        hasMemory = true;
    }
}
