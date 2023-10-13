using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room3 : MonoBehaviour
{
    [SerializeField] GameObject lever;
    [SerializeField] GameObject rope;
    [SerializeField] GameObject key;
    [SerializeField] GameObject gate;
    Vector3 ropePosition = new Vector3(-0.600002289f, 5.56999969f, 3.25999999f);
    Vector3 keyPosition = new Vector3(-0.600002289f, 2.51866961f, 3.25999999f);
    Quaternion keyRotation = new Quaternion(0.0126004936f, 0.706994534f, 0.0126004936f, -0.706994534f);
    float moveKeyValue;
 
    public void LowerSwitch()
    {
        lever.transform.localRotation = Quaternion.Euler(45, 0, 90);
        moveKeyValue = 9;
    }

    public void DropKey()
    {
        rope.SetActive(false);
        key.GetComponent<Rigidbody>().isKinematic = false;
        key.GetComponent<Rigidbody>().AddTorque(Random.onUnitSphere * 0.3f, ForceMode.Impulse);
    }

    public void ResetKey()
    {
        key.GetComponent<Rigidbody>().isKinematic = true;
        key.transform.rotation = keyRotation;
        key.transform.localPosition = keyPosition;
        rope.SetActive(true);
    }

    public void OpenGate()
    {
        gate.SetActive(false);
        Game.Instance.PlayOpenGateSound();
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (moveKeyValue > 0)
        {
            moveKeyValue -= Time.deltaTime * 3;
            key.transform.localPosition = new Vector3(keyPosition.x, keyPosition.y, keyPosition.z - (9 - moveKeyValue));
            rope.transform.localPosition = new Vector3(ropePosition.x, ropePosition.y, ropePosition.z - (9 - moveKeyValue));
        }
    }
}
