using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Physics.IgnoreCollision(gameObject.GetComponent<Collider>(), Managers.Game.playerObject.GetComponent<Collider>());
    }

    // Update is called once per frame
    void Update() {

        float playAreaWidth = Managers.Movement.playAreaWidth;
        float playAreaHeight = Managers.Movement.playAreaHeight;
        Vector3 pos = gameObject.transform.position;
        pos.z = 0;
        if (pos.x > playAreaWidth / 2) {
            Destroy(gameObject);
        } else if (pos.x < -playAreaWidth / 2) {
            Destroy(gameObject);
        }
        if (pos.y > playAreaHeight / 2) {
            Destroy(gameObject);
        } else if (pos.y < -playAreaHeight / 2) {
            Destroy(gameObject);
        }
    }
}
