using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bottle : MonoBehaviour
{
    [SerializeField] Room2 room2;

    bool hasFallen = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if ((collision.gameObject.GetComponent<Ball>()!=null || collision.gameObject.GetComponent<Bottle>() != null) && !hasFallen)
        {
            hasFallen = true;
            room2.IncreaseBottlesFallen();
        }
    }
}
