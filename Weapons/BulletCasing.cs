using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCasing : MonoBehaviour
{
    AudioSource source;

    private void Start()
    {
        source = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Ground")
        {
            StartCoroutine("CasingLifeTime");

            source.Play();
        }
    }

    IEnumerator CasingLifeTime()
    {
        yield return new WaitForSeconds(2f);

        Destroy(gameObject);
    }
}
