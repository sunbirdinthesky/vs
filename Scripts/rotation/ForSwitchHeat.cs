using UnityEngine;
using System.Collections;

public class ForSwitchHeat : MonoBehaviour {

    Switch self;
	// Use this for initialization
	void Start () {
        self = GetComponent<Switch>();
    }

    // Update is called once per frame
    void Update () {
        transform.localEulerAngles = new Vector3(0f, 0f, 90f * self.getValue());
	}
}
