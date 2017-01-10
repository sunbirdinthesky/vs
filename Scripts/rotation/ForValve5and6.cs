using UnityEngine;
using System.Collections;

public class ForValve5and6 : MonoBehaviour {

    Valve self;
	// Use this for initialization
	void Start () {
        self = GetComponent<Valve>();
    }

    // Update is called once per frame
    void Update () {
        transform.localEulerAngles.Set(-90f * self.getValue(), 0f, 0f);
	}
}
