using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bottle : MonoBehaviour
{
    bool hasFallen;

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
            Game.Instance.IncreaseBottlesFallen();
        }
    }
}
