using UnityEngine;
using System.Collections;

public class ForValve5 : MonoBehaviour {

    Valve self;
	// Use this for initialization
	void Start () {
        self = GetComponent<Valve>();
        self.setValue(1f);
    }

    // Update is called once per frame
    void Update () {
        transform.localEulerAngles = new Vector3(90f * self.getValue() - 90f, 0f, 0f);
	}
}
