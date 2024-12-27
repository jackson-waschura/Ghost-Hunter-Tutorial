using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Vector2 position = transform.position;
        position.x = 0;
        transform.position = position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
