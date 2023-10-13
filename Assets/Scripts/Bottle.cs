using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bottle : MonoBehaviour
{
    [SerializeField] Room2 room2;
    AudioSource soundBottles;

    bool hasFallen = false;

    // Start is called before the first frame update
    void Start()
    {
        soundBottles = GameObject.Find("/Sound/Bottles").GetComponent<AudioSource>();
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
            soundBottles.Play();
        }
    }
}
