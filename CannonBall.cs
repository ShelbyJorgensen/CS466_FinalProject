using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBall : MonoBehaviour {
    public float speed = 12f;
    public int damage = 1;
    private bool _alive;
    private float _timer = 0;

    // Start is called before the first frame update
    void Start() {
        _alive = true;
    }

    // Update is called once per frame
    void Update() {
        transform.Translate(0, 0, speed * Time.deltaTime);
        _timer += Time.deltaTime;
        if(!_alive) {
            Destroy(this.gameObject);
        } else if (_timer > 3.5f) {
            Destroy(this.gameObject);
        }
    }

    void OnTriggerEnter(Collider other) {
        PlayerController player = other.GetComponent<PlayerController>();
        CannonBall cannonBall = other.GetComponent<CannonBall>();
        if (player != null) {
            Messenger.Broadcast(GameEvent.PLAYER_HIT);
            Destroy(this.gameObject);
        } else {
            Destroy(this.gameObject);
        }
    }

    public void setAlive(bool alive) {
        _alive = alive;
    }

}
