using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ApplesHelper : MonoBehaviour {

    public int speed;
    public GameObject pers;
    public bool isDamaging;
    public int healthPoints;

    // Use this for initialization
    void Start () {
        InvokeRepeating("DestroyObject", 3, 3);
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
	}

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name == pers.name)
        {
            col.SendMessage((isDamaging) ? "TakeDamage" : "Healing", healthPoints);
            Destroy(this.gameObject);
        }
    }

    private void DestroyObject()
    {
        Destroy(this.gameObject);
    }
}
