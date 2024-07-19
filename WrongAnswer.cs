using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WrongAnswer : MonoBehaviour {

    public void WrongHit() {
        Messenger.Broadcast(GameEvent.WRONG);
        Destroy(this.gameObject);
    }
}
