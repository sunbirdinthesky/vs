using UnityEngine;
using System.Collections;

public class outsideMask : MonoBehaviour {
    float zero = -0.0444f;
    float max = 0.0033f;
    float length = 40;
	// Update is called once per frame
	void Update () {
        float val = transform.parent.parent.GetComponent<AirBlastPipline>().getValue();
        transform.localPosition = new Vector3(-0.0054f, val*(max - zero)/40 + zero , -0.0019f);
	}
}
