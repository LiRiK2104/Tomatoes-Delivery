using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TomatoSpawner : MonoBehaviour
{
    internal static TomatoSpawner Instance;

    [SerializeField] [Range(1, 50)] internal int TomatoesQuantity;
    [SerializeField] private GameObject _tomatoRef;

    private float _spawnInterval = 0.2f;
    private bool _alreadySpawned = false;


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
    }

    public void StartSpawning()
    {
        if (_alreadySpawned)
            return;

        _alreadySpawned = true;
        StartCoroutine("SpawningTomatoes");
    }
    
    private IEnumerator SpawningTomatoes()
    {
        int spawned = 0;
        
        while (spawned < TomatoesQuantity)
        {
            AudioManager.Instance?.PlaySound(SoundFX.tomatoSpawn);
            Instantiate(_tomatoRef, transform.position, Quaternion.identity, gameObject.transform);
            spawned++;
            yield return new WaitForSeconds(_spawnInterval);
        }
    }
}
