using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pilot : Player
{
    [SerializeField] Transform hull, footL, footR;
    [SerializeField] float turnSensitivity, footSensitivity;
    float turn = 0f, rx = 0f, ry = 0f, lx = 0f, ly = 0f, ryGoal = 1f;
    float timeStep = 1f, timerStep = 0f;
    Rigidbody body;
    [SerializeField]Vector3 vel;
    private void Awake()
    {
        body = GetComponent<Rigidbody>();
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

        if(vel == Vector3.zero)
        {
            if (ry == 1f && ly == -1f && ry == ryGoal)
            {
                timerStep = 0f;
                ryGoal = -1f;
                vel = transform.forward * footSensitivity;
            }
            else if (ly == 1f && ry == -1f && ry == ryGoal)
            {
                timerStep = 0f;
                ryGoal = 1f;
                vel = transform.forward * footSensitivity;
            }
        }
        body.velocity = vel;

        vel = Vector3.Lerp(vel, Vector3.zero, timerStep += Time.fixedDeltaTime);
    }
}
