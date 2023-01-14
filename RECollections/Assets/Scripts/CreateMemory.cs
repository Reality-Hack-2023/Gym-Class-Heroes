using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateMemory : MonoBehaviour
{
    // memory prefab
    public GameObject memory = null;
    public GameObject rightHand = null;


    public void Create()
    {
        Instantiate(memory, rightHand.transform.position, Quaternion.identity);
    }
}
