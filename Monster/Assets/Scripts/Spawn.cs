using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour {

    public GameObject[] obj;
	// Use this for initialization
	void Start () {
        InvokeRepeating("SpawnObject", 0, 1);
	}
	
	// Update is called once per frame
	void Update () {
        
	}

    private void SpawnObject()
    {
        int index = (int)Random.Range(0.0f, obj.Length);
        Instantiate(obj[index], transform.position, transform.rotation);
    }
}
