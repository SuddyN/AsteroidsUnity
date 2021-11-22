using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager: MonoBehaviour {
    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {
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
        if (shoot) {
            // TODO: SHOOT
        }
    }
}
