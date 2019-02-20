using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour {

    Animation anim;

    // Start is called before the first frame update
    void Start() {
        anim = GetComponent<Animation>();
    }

    // Update is called once per frame
    void Update() {
        
    }

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player") && UIController.cCount >= 11) {
            GetComponent<BoxCollider>().enabled = false;
            anim.Play();
        }
    }
}
