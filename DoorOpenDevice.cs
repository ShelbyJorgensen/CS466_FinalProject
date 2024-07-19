using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpenDevice : MonoBehaviour {
    [SerializeField] Vector3 dPos;
    private bool open = false;

    public void Operate() {
        if (!open) {
            Vector3 pos = transform.position - dPos;
            transform.position = pos;
            open = !open;
            Messenger.Broadcast(GameEvent.DOOR_OPEN);
        }
    }

    public bool IsOpen() {
        return open;
    }
}
