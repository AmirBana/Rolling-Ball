using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeManager : MonoBehaviour
{
    private CapsuleCollider collider;
    public Action shouldGenerate;
    // Start is called before the first frame update
    void Start()
    {
        collider = GetComponent<CapsuleCollider>();
    }

    // Update is called once per frame
    void Update()
    {
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collider.gameObject.CompareTag("Player"))
        {
            if (shouldGenerate != null)
            {
                shouldGenerate();
                shouldGenerate = null;
            }
        }
    }
}
