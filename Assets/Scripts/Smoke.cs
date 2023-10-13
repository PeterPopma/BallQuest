using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Smoke : MonoBehaviour
{
    [SerializeField] private Transform vfxSmoke;
    float timeLastSmoke;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time - timeLastSmoke>2.5)
        {
            timeLastSmoke = Time.time;
            Instantiate(vfxSmoke, transform.position, Quaternion.identity);
        }
    }
}
