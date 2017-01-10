using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class warn : MonoBehaviour {
    UILabel warnMessage;
    Queue<string> messageQueue = new Queue<string>();
    float timer = 6f;
    bool busy = false;
    float screenWidth;

    // Use this for initialization
    void Start () {
        warnMessage = GetComponent<UILabel>();
	}
	
	// Update is called once per frame
	void Update () {
        screenWidth = Display.main.systemWidth/2;
	    if (!busy && messageQueue.Count != 0) {
            warnMessage.text = messageQueue.Dequeue();
            busy = true;
            timer = 0;
        }

        if (timer < 10f)
            timer += Time.deltaTime;
        
        if (timer < 1f) {
            transform.localPosition =
                new Vector3(-screenWidth - 120f + 380f * timer, 0f, 0f);
        }
        else if (timer > 5f && timer < 6f) {
            transform.localPosition =
                new Vector3(-screenWidth - 120f + 380f * (6f - timer), 0f, 0f);
        } else if (timer > 7f) {
            busy = false;
        }
	}

    public void showWarning (string message) {
        messageQueue.Enqueue(message);
    }
}
