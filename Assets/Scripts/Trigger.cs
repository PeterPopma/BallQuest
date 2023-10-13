using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    [SerializeField] Room9 room9;
    AudioSource soundTrigger;

    // Start is called before the first frame update
    void Start()
    {
        soundTrigger = GameObject.Find("/Sound/Switch").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Ball>() != null)
        {
            soundTrigger.Play();
            room9.IncreaseTriggerValue();
        }
    }
}
