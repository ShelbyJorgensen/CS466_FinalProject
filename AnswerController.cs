using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class AnswerController : MonoBehaviour {
    public GameObject[] answers;
    private int idx = 0;

    private void OnEnable() {
        Messenger.AddListener(GameEvent.CORRECT, Hit);
        Messenger.AddListener(GameEvent.WRONG, Hit);
    }

    private void Hit() {
        for (int i = idx; i < idx+4; i++) {
            Destroy(answers[i]);
        }
        idx += 4;
    }
}
