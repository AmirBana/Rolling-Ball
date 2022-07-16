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
    public static bool gameOver;
    private Transform finishcoor;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        gameOver = false;
        UiManager.start += UseGravity;
        rb.useGravity = false;
        finishcoor = GameObject.FindWithTag("Finish").transform;
    }
    void UseGravity()
    {
        rb.useGravity = true;
    }
    // Update is called once per frame
    void Update()
    {
       if(UiManager.startGame)
        {
            if (transform.position.y < finishcoor.position.y)
            {
                gameOver = true;
            }
            if (!gameOver)
            {
                Movement move = new Movement();
                rb.AddForce(move.AddMove(turnSpeed, velocity), ForceMode.Impulse);
            }
        }
    }
}
