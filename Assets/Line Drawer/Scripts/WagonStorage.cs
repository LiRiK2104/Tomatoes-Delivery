using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WagonStorage : MonoBehaviour
{


    private void Start()
    {
        ChangeQuantityInUI();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Tomato" && !UIManager.Instance.tomatoes.Contains(collision.gameObject))
        {
            UIManager.Instance.tomatoes.Add(collision.gameObject);
            if (LoadNextScene.Instance.index == 3)
            {
                LoadNextScene.Instance.deliveredTomatoes++;
                Debug.Log(LoadNextScene.Instance.deliveredTomatoes);
            }
            ChangeQuantityInUI();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Tomato" && UIManager.Instance.tomatoes.Contains(collision.gameObject))
        {
            UIManager.Instance.tomatoes.Remove(collision.gameObject);
            if (LoadNextScene.Instance.index == 3)
            {
                LoadNextScene.Instance.deliveredTomatoes--;
                Debug.Log(LoadNextScene.Instance.deliveredTomatoes);
            }
            ChangeQuantityInUI();
        }
    }

    private void ChangeQuantityInUI()
    {
        if (UIManager.Instance != null)
        {
            UIManager.Instance.ChangeTomatoesAmount();
        }
    }
}
