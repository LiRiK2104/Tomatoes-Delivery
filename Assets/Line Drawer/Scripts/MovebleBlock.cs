using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovebleBlock : MonoBehaviour
{
    private Vector3 _posByCursor;

    public void OnMouseDown()
    {
        LinesDrawer.Instance.IsMovingObject = true;
        _posByCursor = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    private void OnMouseDrag()
    {
        transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition) + _posByCursor;
        transform.position = new Vector3(transform.position.x, transform.position.y, 0);
    }

    private void OnMouseExit()
    {
        LinesDrawer.Instance.IsMovingObject = false;
    }
}
