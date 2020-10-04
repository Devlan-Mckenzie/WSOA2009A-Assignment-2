using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroll : MonoBehaviour
{
    public float scrollSpeed = 0.0000001f;
    int Swap = 1;
    float Timer = 0.0f;
    float BackgroundOffset = 0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
        Timer = Timer + Time.deltaTime;
        
        if (Timer > 2f)
        {
            Swap = -Swap;
            Timer = Timer - 2f;
        }
        BackgroundOffset += scrollSpeed * Swap;
        //Vector2 BackgroundOffset = new Vector2(Time.time * scrollSpeed * Swap, 0);
        //GetComponent<MeshRenderer>().material.mainTextureOffset = BackgroundOffset;
        GetComponent<MeshRenderer>().material.mainTextureOffset = new Vector2(BackgroundOffset,0);
    }
}
