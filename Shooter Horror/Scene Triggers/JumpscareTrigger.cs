using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpscareTrigger : MonoBehaviour
{
    public GameObject jumpScare;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            StartCoroutine("JumpScareActivate");
        }
    }

    IEnumerator JumpScareActivate()
    {

        yield return new WaitForSeconds(1f);

        GameObject newScaryThing = Instantiate(jumpScare, transform.position, Quaternion.identity) as GameObject;
    }
}
