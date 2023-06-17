using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    public Asteroid asteroidPrefab;
    public float trajectoryvariance = 10.0f;
    public float spawnRate = 2.0f;
    public float spawnDistance = 15.0f;
    public int spawnAmount = 2;

    private void Start()
    {
        Invoke("Spawn", this.spawnRate);
        InvokeRepeating("IncreaseDiff",this.spawnRate, 1.0f);
    }

    private void IncreaseDiff()
    {
        if (this.spawnRate > 1.5f) {
            this.spawnRate -= 0.01f;}
        if (asteroidPrefab._speed <300f) {
            asteroidPrefab._speed +=0.5f;
        }
        if (asteroidPrefab._speed >= (270f)) {
            asteroidPrefab._speed +=0.5f;
        }
    }


    private void Spawn()
    {
        for (int i = 0; i < this.spawnAmount; i++)
        {
            Vector3 spawnDirection = Random.insideUnitCircle.normalized * this.spawnDistance;
            Vector3 spawnPoint = this.transform.position + spawnDirection;

            float variance = Random.Range(-this.trajectoryvariance, this.trajectoryvariance);
            Quaternion rotation = Quaternion.AngleAxis(variance, Vector3.forward);

            Asteroid asteroid = Instantiate(this.asteroidPrefab, spawnPoint, rotation);
            asteroid.asteroidsize = Random.Range(asteroid.minsize,asteroid.maxsize);

            asteroid.settrajectory(rotation * -spawnDirection);
            
        }
        IncreaseDiff();
        Invoke("Spawn", this.spawnRate);
    }



}

