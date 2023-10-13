using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class BeamCollider : MonoBehaviour
{
    [SerializeField] private Transform vfxExplosion;
    [SerializeField] VisualEffect vfxLaser;
    bool laserActive = false;
    AudioSource soundExplosion;

    // Start is called before the first frame update
    void Start()
    {
        soundExplosion = GameObject.Find("/Sound/Explosion").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (laserActive && Time.time % 5 > 3)
        {
            laserActive = false;
            vfxLaser.enabled = false;
        }
        if (!laserActive && Time.time % 5 <= 3)
        {
            laserActive = true;
            vfxLaser.enabled = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Ball>() != null)
        {
            if (laserActive)
            {
                soundExplosion.Play();
                Instantiate(vfxExplosion, other.gameObject.transform.position, Quaternion.identity);
                Destroy(other.gameObject);
            }
        }
    }
}
