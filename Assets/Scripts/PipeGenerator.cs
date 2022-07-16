using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class PipeGenerator : MonoBehaviour
{
    public GameObject[] pipes = new GameObject[2];
    public static Func<bool> shouldGenerate;
    float multiplier;
    public static float pipeTarqueSpeed =1f;
    // Start is called before the first frame update
    void Start()
    {
        multiplier = 6f;
        UiManager.start += BeginGenerate;

    }
    void BeginGenerate()
    {
        for (int i = 0; i < 5; i++) Generator();
        StartCoroutine(AddTaqueSpeed(() => !PlayerController.gameOver));
    }
    // Update is called once per frame
    void Update()
    {

    }
    void Generator()
    {
            GameObject pipe = pipes[Random.Range(0, 2)];
            Vector3 pos = new Vector3(transform.position.x, transform.position.y, transform.position.z + multiplier);
            GameObject newPipe = Instantiate(pipe, pos, pipe.transform.rotation, gameObject.transform);
            newPipe.GetComponent<PipeManager>().shouldGenerate += Generator;
            multiplier += 6f;
    }
    IEnumerator AddTaqueSpeed(Func<bool> isGamerunning)
    {
        while (isGamerunning())
        {
            yield return new WaitForSeconds(1.5f);
            pipeTarqueSpeed += 0.5f;
        }
    }
}
