using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class EasterTomatoUnlocker : MonoBehaviour
{
    public static EasterTomatoUnlocker Instance;

    public TextMesh textCount;
    public TextMesh textCograt;
    [SerializeField] private VideoPlayer _videoPlayer;
    [SerializeField] private SpriteRenderer _easterTomato;

    [Space]
    public List<SpriteRenderer> sps = new List<SpriteRenderer>();
    public Sprite orangeSprite;
    private bool videoPlayed = false;


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

        textCount.text = string.Format("{0}/{1}", LoadNextScene.Instance.deliveredTomatoes, LoadNextScene.Instance.allTomatoes);
    }

    private void Start()
    {
        AudioManager.Instance.PlaySound(SoundFX.fullWin);
    }

    public void Add()
    {
        Debug.Log(LoadNextScene.Instance.deliveredTomatoes + "/" + LoadNextScene.Instance.allTomatoes);
        textCount.text = string.Format("{0}/{1}", LoadNextScene.Instance.deliveredTomatoes, LoadNextScene.Instance.allTomatoes);
        if (LoadNextScene.Instance.deliveredTomatoes >= LoadNextScene.Instance.allTomatoes && !videoPlayed)
        {
            textCount.gameObject.SetActive(false);
            _easterTomato.color = Color.white;
            videoPlayed = true;
            //_videoPlayer.Play();
            foreach (var item in sps)
            {
                item.sprite = orangeSprite;
            }
            textCograt.text = textCograt.text + " : D";
        }
    }
}
