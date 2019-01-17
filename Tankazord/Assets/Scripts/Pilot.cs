using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pilot : Player
{
    [SerializeField] Transform hull, footL, footR;
    [SerializeField] float turnSensitivity, footSensitivity;
    [SerializeField] Collider foot;
    float turn = 0f, rx = 0f, ry = 0f, lx = 0f, ly = 0f, go = 0f;

    Rigidbody body;
    Animator anim;

    [SerializeField]Vector3 vel;
    private void Awake()
    {
        body = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }

    void Start()
    {
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        turn = Input.GetAxis("Turn") * turnSensitivity;
        rx = Input.GetAxis("RX");
        ry = Input.GetAxis("RY");
        lx = Input.GetAxis("LX");
        ly = Input.GetAxis("LY");

        turn *= Time.fixedDeltaTime;

        transform.Rotate(0, turn, 0);

        anim.SetFloat("RLeg", ry);
        anim.SetFloat("LLeg", ly);

        Vector3 mov = transform.forward * go * footSensitivity;

        body.velocity = new Vector3(mov.x, body.velocity.y, mov.z);

    }

    public void Walk(float speed)
    {
        go = speed;
    }
}
