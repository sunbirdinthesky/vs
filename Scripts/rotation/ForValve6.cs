using UnityEngine;
using System.Collections;

public class ForValve6 : MonoBehaviour {

    Valve self;
	// Use this for initialization
	void Start () {
        self = GetComponent<Valve>();
        self.setValue(0f);
    }

    // Update is called once per frame
    void Update () {
        transform.localEulerAngles = new Vector3(0f, 0f, -90f * self.getValue());
	}
}
