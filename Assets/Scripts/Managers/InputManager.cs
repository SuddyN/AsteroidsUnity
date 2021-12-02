using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InputManager: MonoBehaviour {
    // Start is called before the first frame update

    private float bulletTimer;
    public float fireRate = 0.25f;

    void Start() {

    }

    // Update is called once per frame
    void Update() {

        if (Input.GetKey(KeyCode.Escape)) {
            SceneManager.LoadScene("Asteroids");
            Destroy(Managers.Game.gameObject);
        }

        if (Managers.Game.playerObject == null) {
            return;
        }
        bulletTimer += Time.deltaTime;
        KeyboardInput();
    }

    void KeyboardInput() {
        bool rotateClockwise = Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow);
        bool rotateCounterClockwise = Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow);
        bool boost = Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow);
        bool brake = Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow);
        bool shoot = Input.GetKey(KeyCode.Space);

        if (rotateClockwise && !rotateCounterClockwise) {
            Managers.Movement.rotateClockwise();
        }
        if (rotateCounterClockwise && !rotateClockwise) {
            Managers.Movement.rotateCounterClockwise();
        }
        if (boost && !brake) {
            Managers.Movement.boost();
        }
        if (brake && !boost) {
            Managers.Movement.brake();
        }
        if (shoot && bulletTimer > fireRate) {
            // TODO: SHOOT
            GameManager gm = Managers.Game;
            Vector3 pos = gm.playerObject.transform.position;
            GameObject bullet = Instantiate(gm.bulletPrefab, pos, gm.playerObject.transform.rotation);
            bullet.GetComponent<Rigidbody>().velocity = gm.playerObject.transform.up * 7;
            bulletTimer = 0;
        }

    }
}
