using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shell : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine("ShellLife");
    }

    IEnumerator ShellLife()
    {
        yield return new WaitForSeconds(2);

        Destroy(gameObject);
    }
}
