using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineSelfdestroying : MonoBehaviour
{
    [SerializeField] [Range(1, 5)] internal int TimeToDestroy = 3;
    private bool _selfDestroyingStarted = false;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Wheel" && !_selfDestroyingStarted)
        {
            StartCoroutine("SelfDestroying");
        }
    }

    private IEnumerator SelfDestroying()
    {
        float timer = TimeToDestroy;
        bool collidersDisabled = false;

        while (timer > 0)
        {
            yield return null;
            if (timer <= TimeToDestroy / 2 && !collidersDisabled)
            {
                foreach (var item in GetComponent<Line>().Colliders)
                {
                    item.enabled = false;
                }
                collidersDisabled = true;
            }
            timer -= Time.deltaTime;
        }
        Destroy(gameObject);
    }
}
