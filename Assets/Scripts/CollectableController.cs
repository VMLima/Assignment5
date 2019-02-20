using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableController : MonoBehaviour {

    //public UIController UIStuff;
    public ParticleSystem particle;
    public ParticleSystem particle2;

    public Animation anim;

    void Start() {
        //UIController = GameObject.FindGameObjectWithTag("GameController").GetComponent<UIController>();
        particle = transform.GetChild(0).GetComponent<ParticleSystem>();
        particle2 = transform.GetChild(1).GetComponent<ParticleSystem>();
        anim = GetComponent<Animation>();
        anim.Play();
    }

    // Update is called once per frame
    void Update() {
        
    }

    void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Player")) {
            UIController.cCount++;
            particle.Play();
            particle2.Stop();
            //Destroy(gameObject);
            transform.GetComponent<MeshRenderer>().enabled = false;
            transform.GetComponent<BoxCollider>().enabled = false;
        }
    }
}
