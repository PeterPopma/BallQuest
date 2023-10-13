using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room6 : MonoBehaviour
{
    [SerializeField] GameObject gate;
   
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OpenGate()
    {
        gate.SetActive(false);
        Game.Instance.PlayOpenGateSound();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Ball>() != null)
        {
            OpenGate();
        }
    }
}
