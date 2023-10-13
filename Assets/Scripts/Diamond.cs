using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diamond : MonoBehaviour
{
    [SerializeField] Room5 room5;
    [SerializeField] int currentColor;
    AudioSource soundChange;

    public int CurrentColor { get => currentColor; set => currentColor = value; }

    // Start is called before the first frame update
    void Start()
    {
        soundChange = GameObject.Find("/Sound/Change").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Ball>() != null)
        {
            soundChange.Play();
            currentColor++;
            if (currentColor > 2)
            {
                currentColor = 0;
            }
            gameObject.GetComponent<Renderer>().material = room5.MatColors[currentColor];
            room5.CheckDiamonds();
        }
    }
}
