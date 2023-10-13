using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room8 : MonoBehaviour
{
    [SerializeField] GameObject gate;
    int numTargets = 3;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DecreaseTargets()
    {
        numTargets--;
        if (numTargets == 0)
        {
            OpenGate();
        }
    }

    public void OpenGate()
    {
        gate.SetActive(false);
        Game.Instance.PlayOpenGateSound();
    }

}
