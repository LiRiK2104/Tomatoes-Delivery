using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    public void Restart()
    {
        AudioManager.Instance?.PlayClick();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
