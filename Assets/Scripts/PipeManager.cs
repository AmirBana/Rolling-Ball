using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeManager : MonoBehaviour
{
    private Rigidbody rb;
    public Action shouldGenerate;
    public float tarqueSpeed;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        tarqueSpeed = PipeGenerator.pipeTarqueSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        if(CompareTag("Left"))
        {
            rb.angularVelocity = new Vector3(0f, 0f, -1f * tarqueSpeed);
        }
        else if(CompareTag("Right"))
        {
            rb.angularVelocity = new Vector3(0f, 0f, 1f * tarqueSpeed);
            // rb.AddTorque(0f,0f, 10f * tarqueSpeed, ForceMode.Impulse);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
            if (collision.gameObject.CompareTag("Player"))
            {
            if (shouldGenerate != null)
                {
                    shouldGenerate();
                    shouldGenerate = null;
                }
            }
    }
    private void OnCollisionExit(Collision collision)
    {
        if(!PlayerController.gameOver)
        {
            if (collision.gameObject.CompareTag("Player"))
                Invoke("DestroyPipe", 5f);
        }
    }
    void DestroyPipe()
    {
        if(PlayerController.gameOver != true) 
            Destroy(gameObject);
    }
   
}
