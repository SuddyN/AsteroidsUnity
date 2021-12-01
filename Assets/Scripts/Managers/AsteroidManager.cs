using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AsteroidManager: MonoBehaviour {

    public float rotationConstant;
    public float movementConstant;
    public GameObject spawnObject;
    private float invulnarableTimer = 0;

    // Start is called before the first frame update
    void Start() {
        GetComponent<Rigidbody>().angularVelocity = Random.insideUnitSphere * rotationConstant;
        GetComponent<Rigidbody>().velocity = Random.insideUnitCircle;
    }

    // Update is called once per frame
    void Update() {

        if (invulnarableTimer > 0) {
            invulnarableTimer -= Time.deltaTime;
        }

        float playAreaWidth = Managers.Movement.playAreaWidth;
        float playAreaHeight = Managers.Movement.playAreaHeight;
        Vector3 pos = gameObject.transform.position;
        pos.z = 0;
        if (pos.x > playAreaWidth / 2) {
            pos.x = -playAreaWidth / 2;
        } else if (pos.x < -playAreaWidth / 2) {
            pos.x = playAreaWidth / 2;
        }
        if (pos.y > playAreaHeight / 2) {
            pos.y = -playAreaHeight / 2;
        } else if (pos.y < -playAreaHeight / 2) {
            pos.y = playAreaHeight / 2;
        }
        gameObject.transform.SetPositionAndRotation(pos, gameObject.transform.rotation);
    }

    private void OnCollisionEnter(Collision collision) {

        if (collision.gameObject == Managers.Game.playerObject) {
            SceneManager.LoadScene("Asteroids");
            Destroy(Managers.Game.gameObject);
        }

        if (invulnarableTimer > 0) {
            return;
        }

        if (spawnObject != null) {
            GameObject newAsteroid0 = Instantiate(spawnObject, gameObject.transform.position, gameObject.transform.rotation);
            newAsteroid0.GetComponent<Rigidbody>().velocity = Quaternion.Euler(0, 0, -90) * gameObject.GetComponent<Rigidbody>().velocity / 2;

            GameObject newAsteroid1 = Instantiate(spawnObject, gameObject.transform.position, gameObject.transform.rotation);
            newAsteroid1.GetComponent<Rigidbody>().velocity = Quaternion.Euler(0, 0, 90) * gameObject.GetComponent<Rigidbody>().velocity / 2;

            newAsteroid0.GetComponent<AsteroidManager>().invulnarableTimer = 0.25f;
            newAsteroid1.GetComponent<AsteroidManager>().invulnarableTimer = 0.25f;

        }

        Destroy(gameObject);
        Destroy(collision.gameObject);
    }
}
