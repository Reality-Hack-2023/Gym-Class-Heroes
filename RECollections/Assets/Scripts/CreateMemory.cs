using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

/// <summary>
/// Manager of the memories
/// </summary>
public class CreateMemory : MonoBehaviour
{
    public static CreateMemory Instance;

    public Transform spawnLocation = null;
    public float spawnDelay = 4.0f;
    public float spawnMoveDuration = 1.0f;
    public Transform spawnTarget = null;

    public List<GameObject> memories = new List<GameObject>();
    private int currentMemoryIndex = 0;
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    public void Create()
    {
        StartCoroutine(CreateRoutine());
    }

    private IEnumerator CreateRoutine()
    {
        yield return new WaitForSeconds(spawnDelay);
        GameObject newMemory = Instantiate(memories[currentMemoryIndex], spawnLocation.position, Quaternion.identity);
        currentMemoryIndex = currentMemoryIndex >= memories.Count - 1 ? 0 : currentMemoryIndex + 1;

        newMemory.transform.DOMove(spawnTarget.position, spawnMoveDuration);
    }
}
