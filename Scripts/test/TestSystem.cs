using UnityEngine;
using System.Collections;

public class TestSystem : MonoBehaviour {
    public warn warnMessage;
    QuesChecker qc;
    int score = 100;
	// Use this for initialization
	void Start () {
        qc = GetComponent<QuesChecker>();
	}
	
	// Update is called once per frame
	void Update () {
	}

    public void showWarning(string message) {
        warnMessage.showWarning(message);
    }

    public void deCreaseScore (int val) {
        score -= val;
    }
}
