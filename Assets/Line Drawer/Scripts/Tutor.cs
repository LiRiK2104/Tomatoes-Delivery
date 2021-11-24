using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutor : MonoBehaviour
{
    public GameObject[] images = new GameObject[2];
    private int index = 1;

    private void OnEnable()
    {
        index = 0;
        NextImage();
    }

    public void NextImage()
    {
        if (index >= images.Length)
        {
            gameObject.SetActive(false);
            return;
        }
        foreach (var item in images)
        {
            item.SetActive(false);
        }
        images[index].SetActive(true);
        index++;
    }
}
