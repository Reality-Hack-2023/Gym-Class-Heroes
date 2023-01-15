using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Decay : MonoBehaviour
{
    Animator animator;
    private float timer = 0.0f;
    private bool startTimer = true;
    public float glitchTime = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        
    }

    void Update()
    {
        if(startTimer == true)
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
            animator.SetBool("startGlitch", true);
            startTimer = false;
        }
    }
}
