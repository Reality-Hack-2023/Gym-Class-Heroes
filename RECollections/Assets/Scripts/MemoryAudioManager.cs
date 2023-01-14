using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MemoryAudioManager : MonoBehaviour
{
    OVRInput.Controller controller = OVRInput.Controller.RTouch;
    GameObject grabObject = null;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (OVRInput.GetDown(OVRInput.Button.PrimaryHandTrigger, controller))
        {
            // grabbing
            
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision != null)
        {
            if (collision.collider.tag == "Recordable")
            {

            }
        }
    }
}
