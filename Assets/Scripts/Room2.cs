using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room2 : MonoBehaviour
{
    [SerializeField] GameObject gate;
    private int numBottlesFallen;

    public int NumBottlesFallen { get => numBottlesFallen; set => numBottlesFallen = value; }

    public void IncreaseBottlesFallen()
    {
        numBottlesFallen++;
        if (numBottlesFallen == 15)
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
