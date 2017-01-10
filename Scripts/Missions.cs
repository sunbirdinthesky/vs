using UnityEngine;
using System.Collections;
using HighlightingSystem;
using UnityEngine.SceneManagement;

public class Missions : MonoBehaviour {
    public GameObject[] valuePool;
    messageAdapter adapter;
    int[] missionCompleted;
    int missionCounts;
    GameObject missionObject;
    GameObject swap = new GameObject("swap");
    int workingMission = 0;

    public GameObject getMissionObject() {
        return missionObject;
    }

	// Use this for initialization
	void Start () {

        missionCounts = valuePool.Length+1;
        missionCompleted = new int[missionCounts];
        adapter = transform.GetComponent<messageAdapter>();
	}

    void removeFlash () {
        if (getMissionObject().GetComponent<Highlighter>() != null) {
            getMissionObject().GetComponent<Highlighter>().FlashingOff();
        }
    }


    // Update is called once per frame
    void Update () {
        switch (workingMission) {
            case 0:
                if (missionCompleted[workingMission] == 0) {
                    missionCompleted[workingMission] = 1;
                    missionObject = valuePool[workingMission];
                    adapter.addMissionMessage("1.请检查1号阀门状态");
                }
                if (missionObject.GetComponent<Valve>().getValue() >= 0.95f) {
                    removeFlash();
                    missionObject = swap;
                    workingMission++;
                }
                break;

            case 1:
                if (missionCompleted[workingMission] == 0) {
                    missionCompleted[workingMission] = 1;
                    missionObject = valuePool[workingMission];
                    adapter.addMissionMessage("2.请检查2号阀门状态");
                }
                if (missionObject.GetComponent<Valve>().getValue() >= 0.95f) {
                    removeFlash();
                    missionObject = swap;
                    workingMission++;
                }
                break;

            case 2:
                if (missionCompleted[workingMission] == 0) {
                    missionCompleted[workingMission] = 1;
                    missionObject = valuePool[workingMission];
                    adapter.addMissionMessage("3.请检查4号阀门状态");
                }
                if (missionObject.GetComponent<Valve>().getValue() >= 0.95f) {
                    removeFlash();
                    missionObject = swap;
                    workingMission++;
                }
                break;

            case 3:
                if (missionCompleted[workingMission] == 0) {
                    missionCompleted[workingMission] = 1;
                    missionObject = valuePool[workingMission];
                    adapter.addMissionMessage("4.请检查6号阀门状态");
                }
                if (missionObject.GetComponent<Valve>().getValue() >= 0.95f) {
                    removeFlash();
                    missionObject = swap;
                    workingMission++;
                }
                break;

            case 4:
                if (missionCompleted[workingMission] == 0) {
                    missionCompleted[workingMission] = 1;
                    missionObject = valuePool[workingMission];
                    adapter.addMissionMessage("5.请检查3号阀门状态");
                }
                if (missionObject.GetComponent<Valve>().getValue() <= 0.05f) {
                    removeFlash();
                    missionObject = swap;
                    workingMission++;
                }
                break;

            case 5:
                if (missionCompleted[workingMission] == 0) {
                    missionCompleted[workingMission] = 1;
                    missionObject = valuePool[workingMission];
                    adapter.addMissionMessage("6.请检查5号阀门状态");
                }
                if (missionObject.GetComponent<Valve>().getValue() <= 0.05f) {
                    removeFlash();
                    missionObject = swap;
                    workingMission++;
                }
                break;


            case 6:
                if (missionCompleted[workingMission] == 0) {
                    missionCompleted[workingMission] = 1;
                    missionObject = valuePool[workingMission];
                    adapter.addMissionMessage("7.请检查加热釜水位");
                }
                if (missionObject.GetComponent<Valve>().getValue() >= 0.7f) {
                    removeFlash();
                    missionObject = swap;
                    workingMission++;
                }
                break;

            case 7:
                if (missionCompleted[workingMission] == 0) {
                    missionCompleted[workingMission] = 1;
                    missionObject = valuePool[workingMission];
                    adapter.addMissionMessage("8.请检查液封水位");
                }
                if (missionObject.GetComponent<Valve>().getValue() >= 0.7f) {
                    removeFlash();
                    missionObject = swap;
                    workingMission++;
                }
                break;

            case 8:
                if (missionCompleted[workingMission] == 0) {
                    missionCompleted[workingMission] = 1;
                    missionObject = valuePool[workingMission];
                    adapter.addMissionMessage("9.请打开总开关");
                }
                if (missionObject.GetComponent<Switch>().getValue() >= 0.95f) {
                    removeFlash();
                    missionObject = swap;
                    workingMission++;
                }
                break;

            case 9:
                if (missionCompleted[workingMission] == 0) {
                    missionCompleted[workingMission] = 1;
                    missionObject = valuePool[workingMission];
                    adapter.addMissionMessage("10.请打开加热釜开关");
                }
                if (missionObject.GetComponent<Switch>().getValue() >= 0.95f) {
                    removeFlash();
                    missionObject = swap;
                    workingMission++;
                }
                break;

            case 10:
                if (missionCompleted[workingMission] == 0) {
                    missionCompleted[workingMission] = 1;
                    missionObject = valuePool[workingMission];
                    adapter.addMissionMessage("11.请调节加热旋钮");
                }
                if (missionObject.GetComponent<Switch>().getValue() >= 0.7f) {
                    removeFlash();
                    missionObject = swap;
                    workingMission++;
                }
                break;

            case 11:
                if (missionCompleted[workingMission] == 0) {
                    missionCompleted[workingMission] = 1;
                    missionObject = valuePool[workingMission];
                    adapter.addMissionMessage("12.请打开鼓风机开关");
                }
                if (missionObject.GetComponent<Switch>().getValue() >= 0.95f) {
                    removeFlash();
                    missionObject = swap;
                    workingMission++;
                }
                break;

            case 12:
                if (missionCompleted[workingMission] == 0) {
                    missionCompleted[workingMission] = 1;
                    missionObject = valuePool[workingMission];
                    adapter.addMissionMessage("13.请慢慢关闭阀门1，2并记录数据， 按esc结束");
                }
                if (Input.GetKeyDown(KeyCode.Escape)) {
                    removeFlash();
                    missionObject = swap;
                    workingMission++;
                }
                break;

            case 13:
                if (missionCompleted[workingMission] == 0) {
                    missionCompleted[workingMission] = 1;
                    missionObject = valuePool[workingMission];
                    adapter.addMissionMessage("14.请全开1号阀门");
                }
                if (missionObject.GetComponent<Valve>().getValue() >= 0.95f) {
                    removeFlash();
                    missionObject = swap;
                    workingMission++;
                }
                break;

            case 14:
                if (missionCompleted[workingMission] == 0) {
                    missionCompleted[workingMission] = 1;
                    missionObject = valuePool[workingMission];
                    adapter.addMissionMessage("15.请全开2号阀门");
                }
                if (missionObject.GetComponent<Valve>().getValue() >= 0.95f) {
                    removeFlash();
                    missionObject = swap;
                    workingMission++;
                }
                break;

            case 15:
                if (missionCompleted[workingMission] == 0) {
                    missionCompleted[workingMission] = 1;
                    missionObject = valuePool[workingMission];
                    adapter.addMissionMessage("16.请全开3号阀门");
                }
                if (missionObject.GetComponent<Valve>().getValue() >= 0.95f) {
                    removeFlash();
                    missionObject = swap;
                    workingMission++;
                }
                break;

            case 16:
                if (missionCompleted[workingMission] == 0) {
                    missionCompleted[workingMission] = 1;
                    missionObject = valuePool[workingMission];
                    adapter.addMissionMessage("17.请全开5号阀门");
                }
                if (missionObject.GetComponent<Valve>().getValue() >= 0.95f) {
                    removeFlash();
                    missionObject = swap;
                    workingMission++;
                }
                break;

            case 17:
                if (missionCompleted[workingMission] == 0) {
                    missionCompleted[workingMission] = 1;
                    missionObject = valuePool[workingMission];
                    adapter.addMissionMessage("18.请关闭4号阀门");
                }
                if (missionObject.GetComponent<Valve>().getValue() <= 0.05f) {
                    removeFlash();
                    missionObject = swap;
                    workingMission++;
                }
                break;

            case 18:
                if (missionCompleted[workingMission] == 0) {
                    missionCompleted[workingMission] = 1;
                    missionObject = valuePool[workingMission];
                    adapter.addMissionMessage("19.请关闭6号阀门");
                }
                if (missionObject.GetComponent<Valve>().getValue() <= 0.05f) {
                    removeFlash();
                    missionObject = swap;
                    workingMission++;
                }
                break;

            case 19:
                if (missionCompleted[workingMission] == 0) {
                    missionCompleted[workingMission] = 1;
                    missionObject = valuePool[workingMission];
                    adapter.addMissionMessage("20.请慢慢关闭阀门1，2并记录数据， 按esc结束");
                }
                if (Input.GetKeyDown(KeyCode.Escape)) {
                    removeFlash();
                    missionObject = swap;
                    workingMission++;
                }
                break;

            case 20:
                if (missionCompleted[workingMission] == 0) {
                    missionCompleted[workingMission] = 1;
                    missionObject = valuePool[workingMission];
                    adapter.addMissionMessage("21.请全开1号阀门");
                }
                if (missionObject.GetComponent<Valve>().getValue() >= 0.95f) {
                    removeFlash();
                    missionObject = swap;
                    workingMission++;
                }
                break;

            case 21:
                if (missionCompleted[workingMission] == 0) {
                    missionCompleted[workingMission] = 1;
                    missionObject = valuePool[workingMission];
                    adapter.addMissionMessage("22.请全开2号阀门");
                }
                if (missionObject.GetComponent<Valve>().getValue() >= 0.95f) {
                    removeFlash();
                    missionObject = swap;
                    workingMission++;
                }
                break;

            case 22:
                if (missionCompleted[workingMission] == 0) {
                    missionCompleted[workingMission] = 1;
                    missionObject = valuePool[workingMission];
                    adapter.addMissionMessage("23.请调节加热旋钮至关闭");
                }
                if (missionObject.GetComponent<Switch>().getValue() <= 0.05f) {
                    removeFlash();
                    missionObject = swap;
                    workingMission++;
                }
                break;

            case 23:
                if (missionCompleted[workingMission] == 0) {
                    missionCompleted[workingMission] = 1;
                    missionObject = valuePool[workingMission];
                    adapter.addMissionMessage("24.请关闭加热釜开关");
                }
                if (missionObject.GetComponent<Switch>().getValue() <= 0.05f) {
                    removeFlash();
                    missionObject = swap;
                    workingMission++;
                }
                break;

            case 24:
                if (missionCompleted[workingMission] == 0) {
                    missionCompleted[workingMission] = 1;
                    missionObject = valuePool[workingMission];
                    adapter.addMissionMessage("25.请关闭风机电源");
                }
                if (missionObject.GetComponent<Switch>().getValue() <= 0.05f) {
                    removeFlash();
                    missionObject = swap;
                    workingMission++;
                }
                break;

            case 25:
                if (missionCompleted[workingMission] == 0) {
                    missionCompleted[workingMission] = 1;
                    missionObject = valuePool[workingMission];
                    adapter.addMissionMessage("26.请关闭总电源");
                }
                if (missionObject.GetComponent<Switch>().getValue() <= 0.05f) {
                    removeFlash();
                    missionObject = swap;
                    workingMission++;
                }
                break;

            case 26:
                if (missionCompleted[workingMission] == 0) {
                    missionCompleted[workingMission] = 1;
                    adapter.addMissionMessage("27.实验结束，按esc返回");
                }
                if (Input.GetKeyDown(KeyCode.Escape)) {
                    SceneManager.LoadScene("menu");
                }
                break;

        }
    }
}
