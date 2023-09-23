using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    public static Game Instance;
    private int numBottlesFallen;
    [SerializeField] GameObject gate1;

    public int NumBottlesFallen { get => numBottlesFallen; set => numBottlesFallen = value; }

    public void Awake()
    {
        Instance = this;
    }

    public void IncreaseBottlesFallen()
    {
        Debug.Log("Bottles: " + numBottlesFallen);
        numBottlesFallen++;
        if (numBottlesFallen == 15)
        {
            gate1.SetActive(false);
        }
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
