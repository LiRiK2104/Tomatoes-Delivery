using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class LoadNextScene : MonoBehaviour
{
    public static LoadNextScene Instance;

    internal int index = 0;
    internal int deliveredTomatoes = 0;
    internal int allTomatoes = 50;

    internal bool Finished = false;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        UIManager.Instance.Invoke("OpenTutor", 3);
    }

    public void LoadNext()
    {
        Finished = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        index++;
    }
}
