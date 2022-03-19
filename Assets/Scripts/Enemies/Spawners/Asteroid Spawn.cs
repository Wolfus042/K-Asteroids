using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner
{
    private float centerBorderOffset;
    private float xPos;
    private float yPos;

    private List<GameObject> asteroidPrefabs;
    private GameObject summonedAsteroid;

    private Spawner spawner;

    private float silentTime = 0f;
    public AsteroidSpawner (List<GameObject> _asteroidPrefabs, Spawner _spawner) {
        asteroidPrefabs = _asteroidPrefabs;
        spawner = _spawner;
        centerBorderOffset = Settings.current.spawnOffset * 0.5f;
    }

    public void SpawnRoutine() {
        silentTime += Time.deltaTime;
        if (silentTime >= Settings.current.asteroidSpawnFrequency) {
            silentTime = 0f;
            SpawnRandomAsteroid();
        }
    }

    public Vector3 FindRandomCenterPoint() {
        Vector3 result = new Vector3(Random.Range((Settings.current.width - centerBorderOffset) / -2, (Settings.current.width - centerBorderOffset) / 2), Random.Range((Settings.current.height - centerBorderOffset) / -2, (Settings.current.height - centerBorderOffset) / 2), 0f);
        //Debug.Log("CENTER VECTOR x: " + result.x.ToString("F2") + " y:" + result.y.ToString("F2"));
        return result;
    }

    public int RandomAsteroidNumber() {
        return Random.Range(0,asteroidPrefabs.Count);
    }

    public void SpawnRandomAsteroid() {
        yPos = Random.Range(Settings.current.height / -2f - Settings.current.spawnOffset, Settings.current.height / 2f + Settings.current.spawnOffset);
        if ( (yPos > Settings.current.height / 2f) || (yPos < Settings.current.height / -2f) ) {
            xPos = Random.Range(Settings.current.width / -2f - Settings.current.spawnOffset, Settings.current.width / 2f + Settings.current.spawnOffset);
        } else {
            xPos = Random.Range(Settings.current.width / -2f - Settings.current.spawnOffset, Settings.current.width / -2f);
            if (Random.Range(0, 2) % 2 == 1) {
                xPos *= -1;
            }
        }
        summonedAsteroid = spawner.Summon(asteroidPrefabs[RandomAsteroidNumber()], new Vector3(xPos, yPos, 0), Quaternion.identity);
        Vector3 direction = FindRandomCenterPoint() - summonedAsteroid.transform.position;
        summonedAsteroid.transform.up = direction;

        //summonedAsteroid.transform.rotation = Quaternion.FromToRotation(Vector3.up, FindRandomCenterPoint());
    }

    /*
    public void OldSpawnRandomAsteroid() {
        xPos = Random.Range(Settings.current.width / 2f, Settings.current.width / 2f + centerBorderOffset);
        if (Random.Range(0,2) % 2 == 1) {
            xPos *= -1;
        }
        
        yPos = Random.Range(Settings.current.height / 2f, Settings.current.height / 2f + centerBorderOffset);
        if (Random.Range(0, 2) % 2 == 1) {
            yPos *= -1;
        }

        summonedAsteroid = spawner.Summon(asteroidPrefab, new Vector3(xPos, yPos, 0), Quaternion.identity);
        summonedAsteroid.transform.rotation = Quaternion.FromToRotation(Vector3.up, FindRandomCenterPoint());
        //summonedAsteroid.transform.Rotate( new Vector3 (0, 0, Random.Range (0f, 360f) ) );
    }*/
}
