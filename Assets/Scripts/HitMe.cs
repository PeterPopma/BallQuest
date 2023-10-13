using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitMe : MonoBehaviour
{
    AudioSource soundWoosh;
    float shakeValue;
    [SerializeField] GameObject hitBall;
    float speed = 100.0f; // how fast it shakes
    float amount = 0.3f; // how much it shakes
    float startPositionX;

    // Start is called before the first frame update
    void Start()
    {
        soundWoosh = GameObject.Find("/Sound/Woosh").GetComponent<AudioSource>();
        startPositionX = transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        if (shakeValue > 0)
        {
            shakeValue -= Time.deltaTime;
            transform.position = new Vector3(startPositionX + Mathf.Sin(Time.time * speed) * amount, transform.position.y, transform.position.z);
            if (shakeValue < 0)
            {
                hitBall.GetComponent<HitBall>().SetRespawnTimeout();
                transform.position = new Vector3(startPositionX, transform.position.y, transform.position.z); 
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Ball>() != null)
        {
            soundWoosh.Play();
            shakeValue = 0.3f;
        }
    }
}
