using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour {
    public float radius = 5.0f;

    // Update is called once per frame
    void Update() {
        if (Input.anyKey) {
            Collider[] hitColliders = Physics.OverlapSphere(transform.position, radius);
            foreach (Collider collider in hitColliders) {
                collider.SendMessage("Starter", SendMessageOptions.DontRequireReceiver);
            }
        }
    }
}