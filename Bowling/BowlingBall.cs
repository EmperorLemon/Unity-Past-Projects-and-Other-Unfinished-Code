using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowlingBall : MonoBehaviour
{
    private BowlingManager manager;

    private void Awake()
    {
        manager = FindObjectOfType<BowlingManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Void"))
        {
            Destroy(gameObject);
        }

        if (other.gameObject == manager.triggers[0] && other.gameObject.CompareTag("Ball Trigger"))
        {
            manager.rollingAgain[0] = true;
        }

        if (other.gameObject == manager.triggers[1] && other.gameObject.CompareTag("Ball Trigger"))
        {
            manager.rollingAgain[1] = true;
        }

        if (other.gameObject == manager.triggers[2] && other.gameObject.CompareTag("Ball Trigger"))
        {
            manager.rollingAgain[2] = true;
        }

        if (other.gameObject == manager.triggers[3] && other.gameObject.CompareTag("Ball Trigger"))
        {
            manager.rollingAgain[3] = true;
        }

        if (other.gameObject == manager.triggers[4] && other.gameObject.CompareTag("Ball Trigger"))
        {
            manager.rollingAgain[4] = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == manager.triggers[0] && other.gameObject.CompareTag("Ball Trigger"))
        {
            manager.rollingAgain[0] = false;
        }

        if (other.gameObject == manager.triggers[1] && other.gameObject.CompareTag("Ball Trigger"))
        {
            manager.rollingAgain[1] = false;
        }

        if (other.gameObject == manager.triggers[2] && other.gameObject.CompareTag("Ball Trigger"))
        {
            manager.rollingAgain[2] = false;
        }

        if (other.gameObject == manager.triggers[3] && other.gameObject.CompareTag("Ball Trigger"))
        {
            manager.rollingAgain[3] = false;
        }

        if (other.gameObject == manager.triggers[4] && other.gameObject.CompareTag("Ball Trigger"))
        {
            manager.rollingAgain[4] = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.gameObject == manager.lanes[0] && collision.collider.CompareTag("Bowling Lane"))
        {
            manager.rolling[0] = true;
        }

        if (collision.collider.gameObject == manager.lanes[1] && collision.collider.CompareTag("Bowling Lane"))
        {
            manager.rolling[1] = true;
        }

        if (collision.collider.gameObject == manager.lanes[2] && collision.collider.CompareTag("Bowling Lane"))
        {
            manager.rolling[2] = true;
        }

        if (collision.collider.gameObject == manager.lanes[3] && collision.collider.CompareTag("Bowling Lane"))
        {
            manager.rolling[3] = true;
        }

        if (collision.collider.gameObject == manager.lanes[4] && collision.collider.CompareTag("Bowling Lane"))
        {
            manager.rolling[4] = true;
        }
    }    
    
    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.gameObject == manager.lanes[0] && collision.collider.CompareTag("Bowling Lane"))
        {
            manager.rolling[0] = false;
        }

        if (collision.collider.gameObject == manager.lanes[1] && collision.collider.CompareTag("Bowling Lane"))
        {
            manager.rolling[1] = false;
        }

        if (collision.collider.gameObject == manager.lanes[2] && collision.collider.CompareTag("Bowling Lane"))
        {
            manager.rolling[2] = false;
        }

        if (collision.collider.gameObject == manager.lanes[3] && collision.collider.CompareTag("Bowling Lane"))
        {
            manager.rolling[3] = false;
        }

        if (collision.collider.gameObject == manager.lanes[4] && collision.collider.CompareTag("Bowling Lane"))
        {
            manager.rolling[4] = false;
        }
    }
}
