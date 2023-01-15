using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script swaps material after a certain amount of time

public class SwapMaterial : MonoBehaviour
{

    public Material[] material;
    Renderer rend;
    private float timer = 0.0f;
    private bool startTimer = true;
    public float glitchTime = 0.0f;
    DissolveSphere dissolveSphere;

    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<MeshRenderer>();
        rend.enabled = true;
        rend.sharedMaterial = material[0];
        dissolveSphere = GetComponent<DissolveSphere>();

    }

    // Update is called once per frame
    void Update()
    {
        if (startTimer == true)
        {
            timer += Time.deltaTime;
            Debug.Log(timer);
        }

        StartGlitch();
    }

    void StartGlitch()
    {
        if (timer >= glitchTime)
        {
            rend.sharedMaterial = material[1];
            dissolveSphere.enabled = true;
            startTimer = false;
        }
    }
}