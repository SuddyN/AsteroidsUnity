using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager: MonoBehaviour {

    public GameObject playerObject;
    public Vector3 playerVelocity;

    public GameObject playField;
    public GameObject game;
    public GameObject bulletPrefab;
    public GameObject asteroidPrefab;
    public int asteroidCount;

    public float asteroidSpawnRate;
    public float spawnRateAcceleration;
    public float spawnRateMin;
    private float spawnTimer;

    private void spawnAsteroid() {
        Vector3 pos;
        do {
            pos = Random.insideUnitCircle * new Vector3(Managers.Movement.playAreaWidth / 2, Managers.Movement.playAreaHeight / 2);
        } while (Vector3.Distance(pos, playerObject.transform.position) < 1.5f);
        GameObject newAsteroid = Instantiate(asteroidPrefab, pos, Random.rotation);
    }

    // Start is called before the first frame update
    void Start() {
        for (int i = 0; i < asteroidCount; i++) {
            spawnAsteroid();
        }
    }

    // Update is called once per frame
    void Update() {
        spawnTimer += Time.deltaTime;

        if (spawnTimer > asteroidSpawnRate) {
            spawnTimer = 0;
            spawnAsteroid();
            if (asteroidSpawnRate > spawnRateMin) {
                asteroidSpawnRate -= spawnRateAcceleration;
            }
        }
    }
}
