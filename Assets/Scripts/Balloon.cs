using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balloon : MonoBehaviour
{
    [SerializeField] Room4 room4;
    [SerializeField] private Transform vfxExplosion;
    const float circleRadius = 4;
    Vector3 startPosition;
    float angle;

    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
        angle = Random.value * Mathf.PI * 2;
    }

    // Update is called once per frame
    void Update()
    {
        angle += Time.deltaTime * 0.5f;
        transform.position = new Vector3(startPosition.x + Mathf.Cos(angle) * circleRadius, startPosition.y + Mathf.Sin(angle) * circleRadius, startPosition.z);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Ball>() != null)
        {
            room4.IncreaseBalloonsDestroyed();
            Instantiate(vfxExplosion, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
