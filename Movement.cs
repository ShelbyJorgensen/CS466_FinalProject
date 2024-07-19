using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;

public class Movement : MonoBehaviour {

    public GameObject[] path;
    public GameObject[] doors;

    int current = 0;
    int count = 0;
    float rotSpeed;
    public float speed;
    float wPradius = 1;

    bool canMove = true;
    bool started = false;
    private int wrongCount;
    private int enemies;

    private void Start() {
        wrongCount = 0;
        enemies = 0;
    }

    // Update is called once per frame
    void Update() {
        if (started) {
            if (current == 0 || current == 10 || current == 19 || current == 29 || current == 39 || current == 49 || current == 59 || current == 69 || current == 79 || current == 89) {
                DoorOpenDevice currDoor = doors[count].GetComponent<DoorOpenDevice>();
                if (currDoor.IsOpen() == false) {
                    canMove = false;
                }

                if (canMove == true) {
                    current++;
                    count++;
                    Destroy(doors[count - 1]);
                }
            } else if (current == 3 || current == 12 || current == 21 || current == 31 || current == 41 || current == 51 || current == 61 || current == 71 || current == 81 || current == 91) {
                Messenger.Broadcast(GameEvent.SPAWN);
                if (enemies > 0) {
                    canMove = false;
                }
                else if (enemies <= 0) {
                    canMove = true;
                    current++;
                }
            } else if (current == 95) {
                
            } else if (Vector3.Distance(path[current].transform.position, transform.position) < wPradius) {
                current++;
            }
            transform.position = Vector3.MoveTowards(transform.position, path[current].transform.position, Time.deltaTime * speed);
        }
    }

    private void OnEnable() {
        Messenger.AddListener(GameEvent.CORRECT, Selection);
        Messenger.AddListener(GameEvent.WRONG, SelectionWrong);
        //Messenger.AddListener(GameEvent.OUT_OF_TIME, SelectionWrong);
        Messenger.AddListener(GameEvent.ENEMY_KILLED, OnKill);
        Messenger.AddListener(GameEvent.START_GAME, OnStart);
    }

    private void Selection() {
        canMove = true;
    }

    private void SelectionWrong() {
        canMove = true;
        wrongCount++;
        enemies = wrongCount;
    }

    private void OnKill() {
        enemies--;
    }

    public void OnStart() {
        started = true;
    }
}
