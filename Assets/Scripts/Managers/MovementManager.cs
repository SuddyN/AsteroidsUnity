using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementManager: MonoBehaviour {

    public float rotateSpeed = 30.0f;

    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        validateMovement();
        Managers.Game.playerObject.transform.Translate(Managers.Game.playerVelocity * Time.deltaTime);
    }

    void validateMovement() {
        Managers.Game.playerVelocity.z = 0;
        if (Managers.Game.playerVelocity.magnitude > 3) {
            Managers.Game.playerVelocity = Managers.Game.playerVelocity.normalized * 3;
        }
    }

    public void boost() {

    }

    public void brake() {

    }

    public void rotateClockwise() {
        Managers.Game.playerObject.transform.Rotate(0, 0, -rotateSpeed * Time.deltaTime);
    }

    public void rotateCounterClockwise() {
        Managers.Game.playerObject.transform.Rotate(0, 0, rotateSpeed * Time.deltaTime);
    }
}
