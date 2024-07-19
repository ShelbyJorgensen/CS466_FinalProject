using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CorrectAnswer : MonoBehaviour {

    public void CorrectHit() {
        Messenger.Broadcast(GameEvent.CORRECT);
        Destroy(this.gameObject);
    }
}
