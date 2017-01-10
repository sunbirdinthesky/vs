using UnityEngine;
using System.Collections;

public class init : MonoBehaviour {
    public UIPanel missionPannel;
    public UILabel objectMessage;
    public UISlider valveValue;
    public UIPanel scores;
    public bool test = false;

	// Use this for initialization
	
	// Update is called once per frame
	void Update () {
        if (missionPannel == null) {
            Debug.LogError("Error:missionPanel is null, did you forget to initlalize it?");
            return;
        }
        if (objectMessage == null) {
            Debug.LogError("Error:objectMessage is null, did you forget to initlalize it?");
            return;
        }
        if (valveValue == null) {
            Debug.LogError("Error:vlaveValue is null, did you forget to initlalize it?");
            return;
        }

        int height = Display.main.systemHeight/2;
        int weight = Display.main.systemWidth/2;
        missionPannel.transform.localPosition = new Vector3(-weight+200, -height+30, 0f);
        objectMessage.transform.localPosition = new Vector3(-weight+200, height-30, 0f);
        valveValue.transform.localPosition = new Vector3(weight-180, -height+30, 0f);

        if (test)
            scores.transform.localPosition = new Vector3(weight - 180, height - 30, 0f);
    }
}
