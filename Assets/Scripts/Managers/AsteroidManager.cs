using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidManager: MonoBehaviour {

    public float rotationConstant;
    public float movementConstant;
    public GameObject spawnObject;

    // Start is called before the first frame update
    void Start() {
        GetComponent<Rigidbody>().angularVelocity = Random.insideUnitSphere * rotationConstant;
        GetComponent<Rigidbody>().velocity = Random.insideUnitCircle;
    }

    // Update is called once per frame
    void Update() {
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
        if (spawnObject != null) {
            Instantiate(spawnObject, gameObject.transform.position, gameObject.transform.rotation);
        }
        Destroy(gameObject);
    }
}
