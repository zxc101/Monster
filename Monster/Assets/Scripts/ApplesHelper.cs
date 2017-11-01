using UnityEngine;

public class ApplesHelper : MonoBehaviour {

    public int speed;
    public int healthPoints;
    
    void Start () {
        InvokeRepeating("DestroyObject", 3, 3);
	}

	void Update () {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
	}

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name == "Head")
        {
            col.SendMessage("UpdateHealthAndPoint", healthPoints);
            Destroy(this.gameObject);
        }
    }

    private void DestroyObject()
    {
        Destroy(this.gameObject);
    }
}
