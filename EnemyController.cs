using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UIElements;

public class EnemyController : MonoBehaviour {
    [SerializeField] GameObject cannonPrefab;
    private GameObject _cannon;
    public GameObject[] placements;
    private int _wrongCounter;
    private int _enemyCounter;
    private bool canSpawn;
    private int _level;
    private float _timer;
    private float _coolDown;
    
    // Start is called before the first frame update
    void Start() {
        _enemyCounter = 0;
        _timer = 0;
        _level = -1;
        _coolDown = 1;
        canSpawn = false;
    }

    // Update is called once per frame
    void Update() {
        if (_cannon == null && _enemyCounter > 0 && canSpawn == true) {
            if (_timer <= 0) {
                _cannon = Instantiate(cannonPrefab) as GameObject;
                int idx = (_level * 4) + Random.Range(0, 4);
                if (_level == 0 || _level == 4 || _level == 8) {
                    if (idx % 4 == 3) {
                        _cannon.transform.Rotate(0, 180, 0);
                    } else if (idx % 4 == 2) {
                        _cannon.transform.Rotate(0, 90, 0);
                    } else if (idx % 4 == 0) {
                        _cannon.transform.Rotate(0, 270, 0);
                    }
                }
                if (_level == 1 || _level == 5 || _level == 9) {
                    if(idx % 4 == 2) {
                        _cannon.transform.Rotate(0, 180, 0);
                    } else if(idx % 4 == 1) {
                        _cannon.transform.Rotate(0, 90, 0);
                    } else if(idx % 4 == 3) {
                        _cannon.transform.Rotate(0, 270, 0);
                    }
                }
                if (_level == 2 || _level == 6) {
                    if (idx % 4 == 1) {
                        _cannon.transform.Rotate(0, 180, 0);
                    } else if(idx % 4 == 2) {
                        _cannon.transform.Rotate(0, 270, 0);
                    } else if( idx % 4 == 0) {
                        _cannon.transform.Rotate(0, 90, 0);
                    }
                }
                if (_level == 3 || _level == 7) {
                    if (idx % 4 == 1) {
                        _cannon.transform.Rotate(0, 270, 0);
                    } else if (idx % 4 == 0) {
                        _cannon.transform.Rotate(0, 180, 0);
                    } else if (idx % 4 == 3) {
                        _cannon.transform.Rotate(0, 90, 0);
                    }
                }
                _cannon.transform.position = placements[idx].transform.position;
            } else {
                _timer -= Time.deltaTime;
            }
        } 
        if (_enemyCounter == 0) {
            canSpawn = false;
        }
    }

    private void OnEnable() {
        Messenger.AddListener(GameEvent.ENEMY_KILLED, OnKill);
        Messenger.AddListener(GameEvent.SPAWN, OnSpawn);
        Messenger.AddListener(GameEvent.DOOR_OPEN, OnOpen);
        Messenger.AddListener(GameEvent.WRONG, OnWrong);
    }

    private void OnKill() {
        _enemyCounter--;
        _timer = _coolDown;
    }

    private void OnSpawn() {
        canSpawn = true;
    }

    private void OnWrong() {
        _wrongCounter++;
        _enemyCounter = _wrongCounter;
    }

    private void OnOpen() {
        _level++;
    }
}
