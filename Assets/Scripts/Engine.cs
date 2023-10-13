using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Engine : MonoBehaviour
{
    [SerializeField] private Transform vfxSmoke;
    [SerializeField] private Transform vfxSmoke2;
    [SerializeField] private Transform vfxExplosion;
    [SerializeField] private Transform smokePosition;
    Vector3 startPosition;
    AudioSource soundExplosion;
    float timeLastSmoke;

    // Start is called before the first frame update
    void Start()
    {
        soundExplosion = GameObject.Find("/Sound/Nuke").GetComponent<AudioSource>();
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time % 0.2 < .1)
        {
            transform.position = new Vector3(startPosition.x, startPosition.y + (float)(Time.time % 0.2), startPosition.z);
        }
        else
        {
            transform.position = new Vector3(startPosition.x, startPosition.y + .1f - (float)(Time.time % 0.2), startPosition.z);
        }

        if (Time.time - timeLastSmoke > 1.5)
        {
            timeLastSmoke = Time.time;
            Instantiate(vfxSmoke, smokePosition.position, Quaternion.identity);
            Instantiate(vfxSmoke2, smokePosition.position, Quaternion.identity);
        }
    }

    public void Explode()
    {
        soundExplosion.Play();
        Instantiate(vfxExplosion, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
