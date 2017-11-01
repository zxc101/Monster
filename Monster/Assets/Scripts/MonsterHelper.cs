using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterHelper : MonoBehaviour {
    
    void Start () {
        var screenSize = (int)((float)(Screen.width) / Screen.height*100)/100f;

        //5:4
        if (screenSize == (int)(5f / 4f * 100) / 100f)
        {
            gameObject.transform.position = new Vector3(-2.9f, -2.6f, -2f);
        }

        //4:3
        else if (screenSize == (int)(4f / 3f * 100) / 100f)
        {
            gameObject.transform.position = new Vector3(-3.7f, -2.6f, -2f);
        }

        //3:2
        else if (screenSize == (int)(3f / 2f * 100) / 100f)
        {
            gameObject.transform.position = new Vector3(-4.5f, -2.6f, -2f);
        }

        //16:10
        else if (screenSize == (int)(16f / 10f * 100) / 100f)
        {
            gameObject.transform.position = new Vector3(-5.3f, -2.6f, -2f);
        }

        //16:9
        else if (screenSize == (int)(16f / 9f * 100) / 100f)
        {
            gameObject.transform.position = new Vector3(-6.1f, -2.6f, -2f);
        }
    }

	void Update () {
    }
}
