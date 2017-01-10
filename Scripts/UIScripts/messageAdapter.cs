using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class messageAdapter : MonoBehaviour {
    public GameObject missionMessageRoot;
    public GameObject objectMessage;
    public GameObject slider;
    public float messageDelayTime;
    Queue<string> messageQueeu = new Queue<string>();


    public void setValveValue(float value) {
        slider.GetComponent<UISlider>().value = value;
    }

    public void setSliderVisiable(bool isVisiable) {
        slider.SetActive(isVisiable);
    }

    public void addMissionMessage(string message) {
        messageQueeu.Enqueue(message);
    }

    public void setObjectMessage(string message) {
        //Debug.Log("message" + message);
        objectMessage.SetActive(false);
        objectMessage.GetComponent<UILabel>().text = message;
        objectMessage.SetActive(true);
    }

    public void setObjectMessage() {
        objectMessage.GetComponent<UILabel>().text = "";
    }

    float delay = 0;
    void Update() {
        if (delay < messageDelayTime) {
            delay += Time.deltaTime;
            return;
        }
        if (messageQueeu.Count != 0) {
            delay = 0;
            missionMessageRoot.GetComponent<UILabel>().text = messageQueeu.Dequeue();
        }
    }
}