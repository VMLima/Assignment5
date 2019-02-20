using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour {

    public Transform MainMenu, Instruction, Credits;

    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        
    }

    public void Play(string name) {
        SceneManager.LoadScene(name);
    }

    public void InstructionOpen(bool clicked) {
        if (clicked == true) {
            Instruction.gameObject.SetActive(clicked);
            MainMenu.gameObject.SetActive(false);
        } else {
            Instruction.gameObject.SetActive(clicked);
            MainMenu.gameObject.SetActive(true);
        }
    }

    public void CreditsOpen(bool clicked) {
        if (clicked == true) {
            Credits.gameObject.SetActive(clicked);
            MainMenu.gameObject.SetActive(false);
        } else {
            Credits.gameObject.SetActive(clicked);
            MainMenu.gameObject.SetActive(true);
        }
    }

    public void QuitGame() {
        Application.Quit();
    }
}
