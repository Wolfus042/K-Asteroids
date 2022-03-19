using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    private AsteroidSpawner asteroidSpawner;
    private UFOSpawn ufoSpawner;

    public List<GameObject> asteroidPrefabs;
    public GameObject UFOPrafab;


    private void Start() {
        asteroidSpawner = new AsteroidSpawner(asteroidPrefabs, this);
        ufoSpawner = new UFOSpawn(UFOPrafab, this);
    }

    private void Update() {
        asteroidSpawner.SpawnRoutine();
        ufoSpawner.SpawnRoutine();
    }

    /// <summary>
    /// Seems like only MonoBehaviour can Instantiate objects, so this is my workaround.
    /// Edit: I learned that's not the case, but unwilling to overdo atm.
    /// </summary>
    public GameObject Summon(GameObject obj, Vector3 position, Quaternion rotation) {
        GameObject gameObject = Instantiate(obj, position, rotation);
        return gameObject;
    }
}
