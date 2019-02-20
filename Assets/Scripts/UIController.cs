using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour {

    public static int cCount = 0;
    public Text text;
    public GameObject button;
    public Camera cam;

    public Transform leave;

    void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            button.SetActive(true);
        }

        text.text = cCount.ToString() + "/11";
    }

    //public void FirstPerson() {
    //    cam.transform.localPosition = new Vector3(0, 0, 0);
    //}

    //public void ThirdPerson() {
    //    cam.transform.localPosition = new Vector3(0, 2, -6);
    //}

    //public void HideCursor() {
    //    Cursor.lockState = CursorLockMode.Locked;
    //    button.SetActive(false);
    //}

    public void MainMenu(string name) {
        SceneManager.LoadScene(name);
    }

    public void Return() {
        leave.gameObject.SetActive(false);
    }
}
