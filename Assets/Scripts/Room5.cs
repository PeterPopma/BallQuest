using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room5 : MonoBehaviour
{
    [SerializeField] Material[] matColors;
    [SerializeField] Diamond diamond1;
    [SerializeField] Diamond diamond2;
    [SerializeField] Diamond diamond3;
    [SerializeField] GameObject bridge;
    [SerializeField] GameObject gate;

    public Material[] MatColors { get => matColors; set => matColors = value; }


    // Start is called before the first frame update
    void Start()
    {
        bridge.SetActive(false);
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

    public void CheckDiamonds()
    {
        if (diamond1.CurrentColor==1 && diamond2.CurrentColor==2 && diamond3.CurrentColor==0)
        {
            bridge.SetActive(true);
        }
    }
}
