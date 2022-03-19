using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFOSpawn { 

    private float centerBorderOffset;
    private float xPos;
    private float yPos;

    private GameObject ufoPrefab;
    private GameObject summonedUFO;
    private Vector3 wanderDirection;

    private Spawner spawner;

    private float silentTime = 0f;

    public UFOSpawn(GameObject _ufoPrefab, Spawner _spawner) {
        ufoPrefab = _ufoPrefab;
        spawner = _spawner;
        centerBorderOffset = Settings.current.spawnOffset * 0.5f;

    }

    public void SpawnRoutine() {
        silentTime += Time.deltaTime;
        if (silentTime >= Settings.current.UFOSpawnFrequency) {
            silentTime = 0f;
            SpawnUFO();
        }
    }



    public void SpawnUFO() {
        yPos = Random.Range(Settings.current.height / -2f - Settings.current.spawnOffset, Settings.current.height / 2f + Settings.current.spawnOffset);
        if ((yPos > Settings.current.height / 2f) || (yPos < Settings.current.height / -2f)) {
            xPos = Random.Range(Settings.current.width / -2f - Settings.current.spawnOffset, Settings.current.width / 2f + Settings.current.spawnOffset);
        } else {
            xPos = Random.Range(Settings.current.width / -2f - Settings.current.spawnOffset, Settings.current.width / -2f);
            if (Random.Range(0, 2) % 2 == 1) {
                xPos *= -1;
            }
        }
        //Debug.Log("Vector ready: X:" + xPos.ToString() + "|| Y:" + yPos.ToString());
        summonedUFO = GameObject.Instantiate(ufoPrefab, new Vector3(xPos, yPos, 0), Quaternion.identity);
        //Debug.Log("Saucer?");


        //wanderDirection = FindRandomCenterPoint() - summonedUFO.transform.position;
        
        /*Debug.Log("WanderVector: " + wanderDirection.x.ToString() + " " + wanderDirection.y.ToString());
        UFO newTarelka = summonedUFO.GetComponent<UFO>();
        newTarelka.RecieveWanderDirection(wanderDirection);

        //summonedUFO.GetComponent<UFO>().RecieveWanderDirection(wanderDirection);*/

    }
}
