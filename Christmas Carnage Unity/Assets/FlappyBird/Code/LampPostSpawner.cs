using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LampPostSpawner : MonoBehaviour
{
    public static LampPostSpawner Instance;

    float secondsPassed;
    public float maxSecondsPassed;
    public GameObject lampPostPrefab;
    public float height;

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        SpawnLampPost();
    }

    void Update()
    {
        if (secondsPassed > maxSecondsPassed)
        {
            SpawnLampPost();
            secondsPassed = 0;
        }

        secondsPassed += Time.deltaTime;
    }

    void SpawnLampPost()
    {
        GameObject newPipe = Instantiate(lampPostPrefab);
        newPipe.transform.position = transform.position + new Vector3(0, height, 0);
        Destroy(newPipe, 12);
    }
}
