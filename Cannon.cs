using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Cannon : MonoBehaviour {
    [SerializeField] GameObject cannonBallPrefab;
    private GameObject _cannonBall;
    private float _time = 0;

    // Update is called once per frame
    void Update() {
        if (_cannonBall == null && _time <= 0) {
            _cannonBall = Instantiate(cannonBallPrefab) as GameObject;
            _cannonBall.transform.position = transform.TransformPoint(Vector3.forward * 1.5f);
            _cannonBall.transform.rotation = transform.rotation;
            _time = 2.5f;
            
        }
        _time -= Time.deltaTime;
    }

    public void EnemyKill() {
        Messenger.Broadcast(GameEvent.ENEMY_KILLED);
        Destroy(this.gameObject);
    }
}
