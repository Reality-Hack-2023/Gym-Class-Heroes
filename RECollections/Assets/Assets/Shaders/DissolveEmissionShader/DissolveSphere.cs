using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DissolveSphere : MonoBehaviour {

   
    public float dissolveDuration = 1.5f;
    public Material mat;
    Renderer rend;




    private void Start() {

        rend = GetComponent<MeshRenderer>();

    }

    public void Dissolve()
    {
        StartCoroutine(DissolveRoutine());
    }
   

    //coroutine runs code until it hits a yield statement
    private IEnumerator DissolveRoutine()
    {
        rend.material = mat;
        float timeEllapsed = 0;
        float dissolveThreshold = 0.3f;

        while(timeEllapsed < dissolveThreshold)
        {
            mat.SetFloat("_DissolveAmount", timeEllapsed / dissolveDuration);
            timeEllapsed += Time.deltaTime;
            yield return null;

        }
    }
}
