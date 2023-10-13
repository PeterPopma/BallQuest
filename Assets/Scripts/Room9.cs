using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room9 : MonoBehaviour
{
    [SerializeField] GameObject gate;
    [SerializeField] GameObject engine;
    [SerializeField] GameObject trigger;

    float triggerValue;
    Vector3 triggerPosition;

    // Start is called before the first frame update
    void Start()
    {
        triggerPosition = trigger.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (triggerValue > 0)
        {
            triggerValue -= (Time.deltaTime *.1f);
            trigger.transform.position = new Vector3(triggerPosition.x, triggerPosition.y - triggerValue, triggerPosition.z);
        }
    }

    public void IncreaseTriggerValue()
    {
        triggerValue++;
        if (triggerValue > 2.5f)
        {
            triggerValue = 2.5f;
            if (engine != null)
            {
                engine.GetComponent<Engine>().Explode();
            }
            OpenGate();

        }
        trigger.transform.position = new Vector3(triggerPosition.x, triggerPosition.y - triggerValue, triggerPosition.z);
    }

    public void OpenGate()
    {
        gate.SetActive(false);
        Game.Instance.PlayOpenGateSound();
    }

}
