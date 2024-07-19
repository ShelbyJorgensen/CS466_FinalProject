using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeviceOperator : MonoBehaviour {
    public float radius = 5.0f;

    // Update is called once per frame
    void Update() {
        if(Input.GetKeyDown(KeyCode.E)) {
            Collider[] hitColliders = Physics.OverlapSphere(transform.position, radius);
            foreach(Collider collider in hitColliders) { 
                collider.SendMessage("Operate", SendMessageOptions.DontRequireReceiver);
            }
        }
    }
}
