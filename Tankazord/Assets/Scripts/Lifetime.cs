﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lifetime : MonoBehaviour
{
    [SerializeField] float span;
    float t = 0f;
    // Start is called before the first frame update

    // Update is called once per frame
    void FixedUpdate()
    {
        t += Time.fixedDeltaTime;
        if (t >= span)
            Destroy(gameObject);
    }
}
