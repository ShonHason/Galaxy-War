 using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject destroyVFX;
    [SerializeField] int hitPoints = 3;
    [SerializeField] int enemyValue = 10;
    Scoreboard scoreboard;

  private void Start()
    {
        scoreboard = FindFirstObjectByType<Scoreboard>();

        if (!scoreboard)
            Debug.LogError("Scoreboard not found in scene!", this);
    }

    void OnParticleCollision(GameObject other)
    {
        ProcessHit();
    }

    private void ProcessHit()
    {
        hitPoints--;
        if (hitPoints <= 0)
        {
            if (scoreboard)
                scoreboard.IncreaseScore(enemyValue);

            Instantiate(destroyVFX, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
