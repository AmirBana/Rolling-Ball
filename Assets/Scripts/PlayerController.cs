using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    struct Movement
    {
        private float horizontal;
        private float turnSpeed;
        private float velocity;
        public Vector3 AddMove(float turnSpeed,float velocity)
        {
            horizontal = Input.GetAxis("Horizontal");
            this.turnSpeed = turnSpeed;
            this.velocity = velocity;
            return new Vector3(horizontal * this.turnSpeed, 0f, 1f * this.velocity);
        }
    }
    private Rigidbody rb;
    public float turnSpeed=5f;
    public float velocity=10f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement move = new Movement();
        rb.AddForce(move.AddMove(turnSpeed, velocity), ForceMode.Impulse);
    }
}
