using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WagonStorage : MonoBehaviour
{
    private int _inStorage = 0;


    private void Start()
    {
        ChangeQuantityInUI();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Tomato")
        {
            _inStorage++;
            ChangeQuantityInUI();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Tomato")
        {
            _inStorage--;
            ChangeQuantityInUI();
        }
    }

    private void ChangeQuantityInUI()
    {
        if (UIManager.Instance != null)
        {
            UIManager.Instance.ChangeTomatoesAmount(_inStorage);
        }
    }
}
