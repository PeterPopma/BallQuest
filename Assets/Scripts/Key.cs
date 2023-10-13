using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    [SerializeField] Room3 room3;
    float timeLeftKeyDropped;
    bool openedGate;
    AudioSource soundKeyFall;

    // Start is called before the first frame update
    void Start()
    {
        soundKeyFall = GameObject.Find("/Sound/KeyFall").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (timeLeftKeyDropped > 0)
        {
            timeLeftKeyDropped -= Time.deltaTime;
            if (timeLeftKeyDropped < 0 && !openedGate)
            {
                room3.ResetKey();
            }
        }        

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Ball>() != null)
        {
            timeLeftKeyDropped = 3;
            room3.DropKey();
        }

        if (collision.gameObject.GetComponent<Lock>() != null)
        {
            soundKeyFall.Play();
            openedGate = true;
            room3.OpenGate();
        }

        if (collision.gameObject.name.Equals("Floor"))
        {
            soundKeyFall.Play();
        }
    }
}
