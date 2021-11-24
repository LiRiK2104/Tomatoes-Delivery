using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour
{
    private bool finished = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Wagon")
        {
            FinishWagon();
        }
    }

    private void FinishWagon()
    {
        if (!finished)
        {
            finished = true;
            AudioManager.Instance.PlaySound(SoundFX.win);
            Invoke("Finishh", 2);
        }
    }

    private void Finishh()
    {
        LoadNextScene.Instance.deliveredTomatoes += UIManager.Instance.tomatoes.Count;
        LoadNextScene.Instance.LoadNext();
    }
}
