using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pipe : MonoBehaviour
{
    float speed = 100f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnMouseDrag()
    {
        float h = Input.GetAxis("Mouse X");
        float Y = -h * Time.deltaTime * speed;
        transform.Rotate(0,Y,0);
    }
}
