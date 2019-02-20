using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour {

    public float speed;
    public float backSpeed;
    public float mouseSpeed;
    public float jumpSpeed;
    public float maxSpeed;

    public Animator anim;
    public Transform leave;

    //public bool camSwapped = false;

    public UIController UIStuff;

    private bool isGrounded = true;

    private Vector3 movement;
    private Vector3 rotation;
    private Rigidbody rig;
    public Camera cam;

    private float y;
    private float x;

    //private Vector3 tempPosition;
    private Vector3 offset;

    // Start is called before the first frame update
    void Start() {
        rig = GetComponent<Rigidbody>();
        rig.maxAngularVelocity = mouseSpeed;
        anim = GetComponent<Animator>();
        //tempPosition = new Vector3(85, 25, 85);
        offset = new Vector3(transform.position.x , transform.position.y + 2, transform.position.z);
    }

    void Update() { 


    }

    // Update is called once per frame
    void FixedUpdate() {

        // Handles movement
        if (Input.GetKey(KeyCode.W)) {
            movement = transform.forward * speed;
            anim.SetFloat("Blend", 0);
            anim.SetFloat("Speed", 1);
        } else if (Input.GetKey(KeyCode.A)) {
            movement = -transform.right * speed;
            anim.SetFloat("Blend", .33f);
            anim.SetFloat("Speed", 1);
        } else if (Input.GetKey(KeyCode.S) ) {
            movement = -transform.forward * backSpeed;
            anim.SetFloat("Blend", 1);
            anim.SetFloat("Speed", 1);
        } else if (Input.GetKey(KeyCode.D)) {
            movement = transform.right * speed;
            anim.SetFloat("Blend", .66f);
            anim.SetFloat("Speed", 1);
        } else {
            movement = Vector3.zero;
            anim.SetFloat("Speed", 0);
        }

        if (rig.velocity.magnitude > maxSpeed) {
            rig.velocity = rig.velocity.normalized * maxSpeed;
        }

        movement.y = rig.velocity.y;
        rig.position += movement * Time.deltaTime;

        //Handles mouse rotation
        //if (!camSwapped) {
        //y -= Input.GetAxis("Mouse Y") * mouseSpeed;
        x += Input.GetAxis("Mouse X") * mouseSpeed;
        //cam.transform.position = Quaternion.AngleAxis(x, Vector3.up);
        transform.eulerAngles = new Vector3(0, x, 0);
        //offset = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * mouseSpeed, Vector3.up) * offset;
        //Vector3 normOffset = Vector3.Normalize(offset);
        //normOffset.y = 4;
        //normOffset.x *= 4;
        //normOffset.z *= 4;
        //cam.transform.position = transform.position + normOffset;
        //cam.transform.LookAt(transform.position);
        //}

        // Handles jumping
        if (Input.GetKey(KeyCode.Space) && isGrounded) {
            anim.SetBool("Jump", true);
            rig.velocity = transform.up * jumpSpeed;
            //tempPosition = transform.position;
            isGrounded = false;
        }

    }

    void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.CompareTag("Ground")) {
            anim.SetBool("Jump", false);
            isGrounded = true;
        }
    }

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Exit")) {
            leave.gameObject.SetActive(true);
        }
    }
}