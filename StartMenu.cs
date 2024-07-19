using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMenu : MonoBehaviour {

    public void Starter() {
        Messenger.Broadcast(GameEvent.START_GAME);
        Destroy(this.gameObject);
    }
}
