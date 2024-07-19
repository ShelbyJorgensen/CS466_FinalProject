using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIController : MonoBehaviour {
    [SerializeField] TMP_Text scoreLabel;
    [SerializeField] TMP_Text enemiesLabel;
    [SerializeField] TMP_Text damageLabel;
    [SerializeField] TMP_Text timeLabel;
    private int score;
    private int wrong;
    private int enemies;
    private int damage;
    private float timer;
    private bool startTimer;

    private void Start () {
        score = 0;
        wrong = 0;
        damage = 0;
        timer = 0;
        startTimer = false;
        timeLabel.text = "";
    }

    public void Update() {
        scoreLabel.text = "Score: " + score.ToString() + "/10";
        enemiesLabel.text = "";
        damageLabel.text = "Damage: " + damage.ToString();
        if (startTimer == true) {
            if (timer > 1) {
                timer -= Time.deltaTime;
                int currTime = (int)timer;
                timeLabel.text = "Time: " + currTime.ToString();
            }
            else if (timer <= 1) {
                //Messenger.Broadcast(GameEvent.OUT_OF_TIME);
                Messenger.Broadcast(GameEvent.WRONG);
                startTimer = false;
            }
        } else {
            timeLabel.text = "";
        }
        if (enemies > 0) {
            enemiesLabel.text = "Remaining Enemies: " + enemies.ToString();
        }
    }

    private void OnEnable() {
        Messenger.AddListener(GameEvent.CORRECT, OnCorrect);
        Messenger.AddListener(GameEvent.WRONG, OnWrong);
        Messenger.AddListener(GameEvent.ENEMY_KILLED, OnKill);
        Messenger.AddListener(GameEvent.PLAYER_HIT, OnHit);
        Messenger.AddListener(GameEvent.DOOR_OPEN, OnOpen);
    }

    private void OnCorrect() {
        score++;
        scoreLabel.text = "Score: " + score.ToString() + "/10";
        startTimer = false;
    }

    private void OnWrong() {
        wrong++;
        enemies = wrong;
        startTimer = false;
    }

    private void OnKill() {
        enemies--;
        if (enemies > 0) {
            enemiesLabel.text = "Remaining Enemies: " + enemies.ToString();
        } else if (enemies == 0) {
            enemiesLabel.text = "";
        }
    }

    private void OnHit() {
        damage++;
        damageLabel.text = "Damage: " + damage.ToString();
    }

    private void OnOpen() {
        timer = 10;
        startTimer = true;
    }
}