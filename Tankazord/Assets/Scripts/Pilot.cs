using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pilot : Player
{
    [SerializeField] Transform hull, footL, footR;
    [SerializeField] float sensitivity;
    float turn = 0f, rx = 0f, ry = 0f, lx = 0f, ly = 0f;
    Vector3 L, R;
    // Start is called before the first frame update
    void Start()
    {
        L = footL.transform.localPosition;
        R = footR.transform.localPosition;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        turn = Input.GetAxis("Turn") * sensitivity;
        rx = Input.GetAxis("RX");
        ry = Input.GetAxis("RY");
        lx = Input.GetAxis("LX");
        ly = Input.GetAxis("LY");


        turn *= Time.fixedDeltaTime;

        hull.Rotate(0, turn, 0);

        footL.localPosition = L + new Vector3(lx, 0f, ly);

        footR.localPosition = R + new Vector3(rx, 0f, ry);
    }
}
