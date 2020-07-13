using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class Spawner : MonoBehaviour
{
    public Enemy prefab;
    public float minimumTimeBetweenSpawns = 3f;
    public int minimumNumberEnemies = 4;
    public int maximumNumberEnemies = 8;
    public int currentEnemyCount = 0;
    public float timeSinceLastSpawn = 3f;
    public Text scoreText;
    private float m_globalSpeed;
    private readonly float m_maxSpeed = 8f;
    private int m_score = 0;

    private void Update ()
    {
        UpdateScoreText();
        m_globalSpeed += 1f;
        timeSinceLastSpawn += Time.deltaTime;
      
        if (HasEnoughTimePassed() && IsMinimumReached())
        {
            return;
        }
        
        if (!IsMaximumReached())
        {
            Spawn();
            timeSinceLastSpawn = 0;
        }
        
        CapGlobalSpeed();
    }

    private void CapGlobalSpeed ()
    {
        if (m_globalSpeed > m_maxSpeed)
        {
            m_globalSpeed = m_maxSpeed;
        }
    }
    
    private void UpdateScoreText ()
    {
        scoreText.text = "Score: " + m_score;
    }
    
    private bool HasEnoughTimePassed ()
    {
        return timeSinceLastSpawn < minimumTimeBetweenSpawns;
    }
    
    private bool IsMinimumReached ()
    {
        return currentEnemyCount > minimumNumberEnemies;
    }
    
    private bool IsMaximumReached ()
    {
        return currentEnemyCount > maximumNumberEnemies;
    }
    
    private void Spawn ()
    {
        Vector3 position = new Vector3(Random.Range(-8, 8), Random.Range(6, 30), 0);
        Enemy obj = Instantiate(prefab, transform);
        obj.transform.position = position;
        obj.speed = Mathf.Max(5f, m_globalSpeed / 60);
        currentEnemyCount += 1;
    }

    // Event consumer called from child objects when destroyed using SendMessageUpwards method
    public void ChildDestroyed ()
    {
        currentEnemyCount = Mathf.Max(0, currentEnemyCount - 1);
        m_score++;
    }
}
