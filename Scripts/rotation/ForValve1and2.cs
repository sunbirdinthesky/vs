using UnityEngine;
using System.Collections;

public class ForValve1and2 : MonoBehaviour {

    Valve self;
	// Use this for initialization
	void Start () {
        self = GetComponent<Valve>();
        self.setValue(0.6f);
    }

    // Update is called once per frame
    void Update () {
        transform.localEulerAngles = new Vector3(90f * self.getValue(), 0f, -90f);
	}
}
