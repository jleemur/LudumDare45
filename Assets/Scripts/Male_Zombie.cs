using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Male_Zombie_Script : MonoBehaviour
{
    private Rigidbody2D zombieRigidBody;

    // Start is called before the first frame update
    void Start() {
        zombieRigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update() {
        float horizontal = Input.GetAxis("Horizontal");
        handleMovement(horizontal);
    }

    private void handleMovement(float horizontal) {
        zombieRigidBody.velocity = new Vector2(horizontal, zombieRigidBody.velocity.y);
    }
}
