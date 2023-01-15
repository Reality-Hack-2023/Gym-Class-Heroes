using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    public GameObject grabMeText = null;
    public GameObject speakerIcon = null;
    public bool hasTutored = false;

    CreateMemory memoryManager;
    [SerializeField] private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        grabMeText.SetActive(true);
        speakerIcon.SetActive(false);
        memoryManager = FindObjectOfType<CreateMemory>();
        // get the audioSource
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Grabbed()
    {
        
        grabMeText.SetActive(false);
        speakerIcon.SetActive(true);
        memoryManager.enabled = true;
        audioSource.Play();
        if (!hasTutored)
        {
            CreateMemory.Instance.Create();
            hasTutored = true;
        }
    }

    public void LetGo()
    {
        speakerIcon.SetActive(false);
        audioSource.Stop();
    }
}
