using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hide : MonoBehaviour
{
    public GameObject Block;

    public void HideBlock()
    {
        Block.SetActive(false);
    }
}
