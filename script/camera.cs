using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour
{
    public Transform ball;  
    private Vector3 offset; 
    void Start()
    {
        offset=transform.position-ball.position;
    }
    void Update()
    {
        transform.position = new Vector3(ball.position.x+offset.x, ball.position.y + offset.y, ball.position.z + offset.z);
    }
}
