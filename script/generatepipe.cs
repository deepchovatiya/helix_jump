using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class generatepipe : MonoBehaviour
{
    public Material[] allmat;
    public string[] tags;
    void Start()
    {
        gnerate();
    }

    void Update()
    {
        
    }
    void gnerate()
    {
        foreach(Transform t in transform)
        {
            int r = Random.Range(0, allmat.Length);
            t.tag = tags[r];
            if(r==2)
            {
                t.GetComponent<MeshRenderer>().enabled = false;
                t.GetComponent<MeshCollider>().convex = true;
                t.GetComponent<MeshCollider>().isTrigger = true;
                t.transform.position=new Vector3(transform.position.x,transform.position.y-0.3f,transform.position.z);
            }
            else
            {
                t.GetComponent<Renderer>().material = allmat[r];
            }
        }

    }
}

