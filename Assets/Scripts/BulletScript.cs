﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{   
    public int bulletSpeed = 10;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(bulletSpeed,0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
