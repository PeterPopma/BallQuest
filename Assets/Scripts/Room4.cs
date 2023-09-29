using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room4 : MonoBehaviour
{
    [SerializeField] GameObject gate;
    private int balloonsDestroyed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void IncreaseBalloonsDestroyed()
    {
        balloonsDestroyed++;
        if (balloonsDestroyed == 4)
        {
            gate.SetActive(false);
        }
    }
}
