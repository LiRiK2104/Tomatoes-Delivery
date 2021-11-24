using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovablePlatformCollisions : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Wheel")
        {
            gameObject.GetComponent<WheelsMaterialController>().WheelsObserver.gameObject.transform.SetParent(transform);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Wheel")
        {
            gameObject.GetComponent<WheelsMaterialController>().WheelsObserver.gameObject.transform.SetParent(null);
        }
    }
}
