using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [HideInInspector]
    public float bulletDamage = 10;

    private void Start()
    {
        StartCoroutine("BulletLifeTime");
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Monster")
        {
            Debug.Log("Hit");
        }
    }

    IEnumerator BulletLifeTime()
    {
        yield return new WaitForSeconds(2f);

        Destroy(gameObject);
    }
}
