using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBall : MonoBehaviour
{
    [SerializeField] Room5 room5;
    bool respawnActive = true;
    float respawnTime;
    Vector3 initialPosition;

    public bool RespawnActive { get => respawnActive; set => respawnActive = value; }

    // Start is called before the first frame update
    void Start()
    {
        initialPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (respawnActive && respawnTime > 0)
        {
            respawnTime -= Time.deltaTime;
            if (respawnTime < 0)
            {
                GetComponent<Rigidbody>().isKinematic = true;
                transform.position = initialPosition;
            }
        }
    }

    public void SetRespawnTimeout()
    {
        GetComponent<Rigidbody>().isKinematic = false;
        respawnTime = 8;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Lock>() != null)
        {
            respawnActive = false;
            room5.OpenGate();
        }
    }
}
