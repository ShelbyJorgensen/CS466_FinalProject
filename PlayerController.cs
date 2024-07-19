using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    private int _correct;
    private int _wrong;
    
    // Start is called before the first frame update
    private void Start() {
        _correct = 0;
        _wrong = 0;
    }

    public void Correct() {
        _correct++;
        Messenger.Broadcast(GameEvent.CORRECT);
    }

    public void Wrong() {
        _wrong++;
        Messenger.Broadcast(GameEvent.WRONG);
    }
}
