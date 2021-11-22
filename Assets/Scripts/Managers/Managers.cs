using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(InputManager))]
[RequireComponent(typeof(GameManager))]
public class Managers: MonoBehaviour {

    private static InputManager inputManager;
    public static InputManager Input {
        get {
            return inputManager;
        }
    }

    private static GameManager gameManager;
    public static GameManager Game {
        get {
            return gameManager;
        }
    }

    // Start is called before the first frame update
    void Start() {

    }

    private void Awake() {
        inputManager = GetComponent<InputManager>();
        gameManager = GetComponent<GameManager>();
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update() {

    }
}
