using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    [SerializeField] Room3 room3;
    AudioSource soundSwitch;

    // Start is called before the first frame update
    void Start()
    {
        soundSwitch = GameObject.Find("/Sound/Switch").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Ball>() != null)
        {
            room3.LowerSwitch();
            soundSwitch.Play();
        }
    }
}
