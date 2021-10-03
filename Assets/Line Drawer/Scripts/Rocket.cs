using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    private Vector3 _velocityLimit = new Vector3(50, 0, 0);
    private Vector3 _force = new Vector3(10, 0, 0);
    internal bool IsForcing = true;

    private Rigidbody2D _rb;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }


    /*private void FixedUpdate()
    {
        if (IsForcing)
        {
            _force = new Vector2(Mathf.Cos(transform.localRotation.z), Mathf.Sin(transform.localRotation.z));
            _rb.AddForce(_force, ForceMode2D.Force);
        }
    }

    private void OnDrawGizmos()
    {
        Debug.DrawLine(transform.position, transform.position + _force, Color.red);
        Debug.DrawLine(transform.position, new Vector3(Mathf.Cos(transform.rotation.z), Mathf.Sin(transform.rotation.z)), Color.yellow);
    }*/
}
