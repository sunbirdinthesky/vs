using UnityEngine;
using System.Collections;

public class CourseLock : MonoBehaviour {
    public bool OF = false;

	// Use this for initialization
	void Start () {
        Cursor.lockState = CursorLockMode.Locked;

	}
	
	// Update is called once per frame
	void Update () {
        Cursor.visible = true;
    }

    void Lock() {
        if (OF == true)
        {
            Cursor.lockState = CursorLockMode.None;
        }
        else if (OF == false) 
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
    }
}
