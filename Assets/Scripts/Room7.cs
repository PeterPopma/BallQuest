using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Room7 : MonoBehaviour
{
    [SerializeField] GameObject gate;
    [SerializeField] TextMeshPro textBallsLeft;
    private int numBallsInBox;
    AudioSource soundBell;

    // Start is called before the first frame update
    void Start()
    {
        soundBell = GameObject.Find("/Sound/Bell").GetComponent<AudioSource>();
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
            soundBell.Play();
            Destroy(collision.gameObject);
            numBallsInBox++;
            textBallsLeft.text = (3 - numBallsInBox).ToString() + "x";
            if (numBallsInBox == 3)
            {
                OpenGate();
                Game.Instance.PlayOpenGateSound();
            }
        }
    }
}
