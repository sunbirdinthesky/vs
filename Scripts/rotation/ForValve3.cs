using UnityEngine;
using System.Collections;

public class ForValve3 : MonoBehaviour {

    Valve self;
	// Use this for initialization
	void Start () {
        self = this.gameObject.GetComponent<Valve>();
        self.setValue(1f);
    }

    // Update is called once per frame
    void Update () {
        transform.localEulerAngles = new Vector3(0f, 0f, -90f * self.getValue());
	}
}
