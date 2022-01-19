using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmptyShell : MonoBehaviour
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
            StartCoroutine("EmptyShellLifetime");

            source.Play();
        }
    }

    IEnumerator EmptyShellLifetime()
    {
        yield return new WaitForSeconds(2);

        Destroy(gameObject);
    }
}
