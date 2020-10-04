using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SinWave_Movement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float frequency = 20f;
    public float magnitude = 0.5f;
    Vector3 pos;    
    // Start is called before the first frame update
    void Start()
    {
        pos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        pos -= transform.right * Time.deltaTime * moveSpeed;
        transform.position = pos + transform.up * Mathf.Sin(Time.time * frequency) * magnitude;
    }
}
