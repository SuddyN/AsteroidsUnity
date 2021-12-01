using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementManager: MonoBehaviour {

    public float rotateSpeed = 360.0f;
    public float playAreaWidth = 16;
    public float playAreaHeight = 9;

    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        boundaryCheck();
        validateMovement();
        Managers.Game.playerObject.transform.Translate(Managers.Game.playerVelocity * Time.deltaTime);
    }

    private void validateMovement() {
        Managers.Game.playerVelocity.z = 0;
        if (Managers.Game.playerVelocity.magnitude > 3) {
            Managers.Game.playerVelocity = Managers.Game.playerVelocity.normalized * 3;
        }
    }

    private void boundaryCheck() {
        Vector3 pos = Managers.Game.playerObject.transform.position;
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
        Managers.Game.playerObject.transform.SetPositionAndRotation(pos, Managers.Game.playerObject.transform.rotation);
    }

    public void boost() {
        Managers.Game.playerVelocity.y += 2.0f * Time.deltaTime;
    }

    public void brake() {
        Managers.Game.playerVelocity.y -= 2.0f* Time.deltaTime;
    }

    public void rotateClockwise() {
        float rotation = -rotateSpeed * Time.deltaTime;
        Managers.Game.playerObject.transform.Rotate(0, 0, rotation);
        Managers.Game.playerVelocity = Quaternion.Euler(0, 0, -rotation) * Managers.Game.playerVelocity;
    }

    public void rotateCounterClockwise() {
        float rotation = rotateSpeed * Time.deltaTime;
        Managers.Game.playerObject.transform.Rotate(0, 0, rotation);
        Managers.Game.playerVelocity = Quaternion.Euler(0, 0, -rotation) * Managers.Game.playerVelocity;
    }
}
