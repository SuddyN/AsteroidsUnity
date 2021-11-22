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
        bool rotateClockwise = Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow);
        bool rotateCounterClockwise = Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow);
        bool boost = Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow);
        bool brake = Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow);
        bool shoot = Input.GetKeyDown(KeyCode.Space);

        if (rotateClockwise && !rotateCounterClockwise) {
            // TODO: ROTATE CLOCKWISE
        }
        if (rotateCounterClockwise && !rotateClockwise) {
            // TODO: ROTATE COUNTERCLOCKWISE
        }
        if (boost && !brake) {
            // TODO: BOOST
        }
        if (brake && !boost) {
            // TODO: BRAKE
        }
        if (shoot) {
            // TODO: SHOOT
        }
    }
}
