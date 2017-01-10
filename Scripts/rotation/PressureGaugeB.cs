using UnityEngine;
using System.Collections;

public class PressureGaugeB : MonoBehaviour {
    PressureGauge self;
    Transform needel;

    void Start() {
        foreach (Transform tmp in transform) {
            if (tmp.name == "needel") {
                needel = tmp;
                break;
            }
        }
        self = this.gameObject.GetComponent<PressureGauge>();
    }

    void Update() {//just test
        //0pa = -3, 25kPa = -95.2, z axie
        float tmp = (180f - 95.2f + 180f) * self.getValue() / 25f;
        if (tmp > 180f) {
            tmp = tmp - 360f;
        }
        needel.localRotation = Quaternion.Euler(new Vector3(0f, 0f, tmp));
    }
}
