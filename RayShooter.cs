using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class RayShooter : MonoBehaviour {
    private Camera _camera;

    // Start is called before the first frame update
    void Start() {
        _camera = GetComponent<Camera>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    void OnGUI() {
        int size = 12;
        float posX = _camera.pixelWidth / 2 - size / 4;
        float posY = _camera.pixelHeight / 2 - size / 2;
        GUI.Label(new Rect(posX, posY, size, size), "0");
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetMouseButtonDown(0)) {
            Vector3 point = new Vector3(_camera.pixelWidth / 2, _camera.pixelHeight / 2, 0);
            Ray ray = _camera.ScreenPointToRay(point);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit)) {
                GameObject hitObject = hit.transform.gameObject;
                CorrectAnswer correct = hitObject.GetComponent<CorrectAnswer>();
                WrongAnswer wrong = hitObject.GetComponent<WrongAnswer>();
                CannonBall cannonBall = hitObject.GetComponent<CannonBall>();
                Cannon cannon = hitObject.GetComponent<Cannon>();
                if (correct != null) {
                    correct.CorrectHit();
                } else if (wrong != null) {
                    wrong.WrongHit();
                } else if (cannonBall != null) {
                    cannonBall.setAlive(false);
                } else if (cannon != null) {
                    cannon.EnemyKill();
                } else {
                    StartCoroutine(SphereIndicator(hit.point));
                }
            }
        }
    }

    private IEnumerator SphereIndicator(Vector3 pos) {
        GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        sphere.transform.position = pos;
        yield return new WaitForSeconds(1);
        Destroy(sphere);
    }
}
