using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReplaceScript : MonoBehaviour
{

    public GameObject collectablePrefab;
    //public int count;

    private GameObject[] spheres;

    // Start is called before the first frame update
    void Start() {
        spheres = GameObject.FindGameObjectsWithTag("EditorOnly");
        Debug.Log(spheres.Length);
        Change();
    }

    private void Change() {
        for (int i = 0; i < spheres.Length; i++) {
            Debug.Log(i);
            Instantiate(collectablePrefab, spheres[i].transform.position, Quaternion.identity);
            Destroy(spheres[i]);
        }
    }

    // Update is called once per frame
    void Update() {
        
    }
}
