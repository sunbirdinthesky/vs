using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using HighlightingSystem;

public class MessageDistributer : MonoBehaviour {
    public bool test = false;
    messageAdapter adapter;
    Missions mission;
    public ForceOn forceOn;
    bool isEscPressed = false;
    bool firstStart = true;

    void init() {
        if (test) {
            adapter.addMissionMessage("请自行操作设备");
            adapter.addMissionMessage("系统不会给出操作提示");
        }
        //adapter.addMissionMessage("欢迎使用本系统");
        adapter.addMissionMessage("请遵照系统的提示进行操作");
        //adapter.addMissionMessage("按任意键继续");
        adapter.setSliderVisiable(false);
    }

    void Start () {
        adapter = transform.GetComponent<messageAdapter>();
        mission = transform.GetComponent<Missions>();
    }
	
	// Update is called once per frame
	void Update () {
        if (firstStart) {
            init();
            firstStart = false;
        }

        if (Input.GetKeyUp(KeyCode.Escape)) {
            Application.Quit();
        }

        Ray ray= Camera.main.ScreenPointToRay(new Vector2(Display.main.systemWidth/2, Display.main.systemHeight / 2));
        RaycastHit hitInfo;
        if (Physics.Raycast(ray, out hitInfo, 15f)) {
            Debug.DrawLine(ray.origin, hitInfo.point);//划出射线，只有在scene视图中才能看到
            string message = GetComponent<Strings>().getMapString(hitInfo.collider.gameObject.name);

            addMouseOnHightlight(hitInfo.collider.gameObject);
            //Debug.Log(hitInfo.collider.gameObject.layer);
            //Debug.Log(hitInfo.collider.gameObject.name);

            Valve tmpValve = hitInfo.collider.gameObject.GetComponent<Valve>();
            Switch tmpSwitch = hitInfo.collider.gameObject.GetComponent<Switch>();
            //AirBlastPipline tmpAirBlast = hitInfo.collider.gameObject.GetComponent<AirBlastPipline>();
            //PressureGauge tmpPressureGauge = hitInfo.collider.gameObject.GetComponent<PressureGauge>();
            //if (tmpValve != null)
            //    message = message + "(当前值为：" + string.Format("{0:0.00}", tmpValve.getValue()) + ")";
            //if (tmpSwitch != null)
            //    message = message + "(当前值为：" + string.Format("{0:0.00}", tmpSwitch.getValue()) + ")";
            //if (tmpAirBlast != null)
            //    message = message + "(当前值为：" + string.Format("{0:0.00}", tmpAirBlast.getValue()) + ")";
            //if (tmpPressureGauge != null)
            //    message = message + "(当前值为：" + string.Format("{0:0.00}", tmpPressureGauge.getValue()) + ")";

            adapter.setObjectMessage(message);
            Debug.DrawLine(hitInfo.collider.gameObject.transform.position, GameObject.Find(hitInfo.collider.gameObject.name).transform.position, Color.red);

            

            if (tmpValve != null) {
                adapter.setSliderVisiable(true);
                adapter.setValveValue(tmpValve.getValue()); //阀门和开关
            }
            else if (tmpSwitch != null) {
                adapter.setSliderVisiable(true);
                adapter.setValveValue(tmpSwitch.getValue());
            }


            if (Input.GetMouseButtonUp(0)) {
                objectOnLeftClick(hitInfo.collider.gameObject);
            }
            if (Input.GetMouseButtonUp(1)) {
                objectOnRightClick(hitInfo.collider.gameObject);
            }
            if (Input.GetKey(KeyCode.Q)) {
                valueTurnDown(hitInfo.collider.gameObject);
            }
            if (Input.GetKey(KeyCode.E)) {
                valueTurnUp(hitInfo.collider.gameObject);
            }

        }
        else {
            adapter.setObjectMessage();
            adapter.setSliderVisiable(false);
        }

        highlight();
    }

    void highlight () {
        Highlighter tmp = mission.getMissionObject().GetComponent<Highlighter>();
        if (tmp == null) {
            mission.getMissionObject().AddComponent<Highlighter>();
            tmp = mission.getMissionObject().GetComponent<Highlighter>();
        }

        tmp.FlashingOn(Color.blue, Color.cyan, 2f);
    }

    void addMouseOnHightlight (GameObject target) {
        Highlighter tmp = target.GetComponent<Highlighter>();
        if (tmp == null) {
            target.AddComponent<Highlighter>();
            tmp = target.GetComponent<Highlighter>();
        }

        tmp.On();

    }

    void valueTurnUp (GameObject tmp) {
        Valve tmpValve = tmp.GetComponent<Valve>();
        Switch tmpSwitch = tmp.GetComponent<Switch>();
        if (tmpValve != null && tmpValve.getValue() <= 0.99f) {
            tmpValve.setValue(tmpValve.getValue() + 0.01f);
            adapter.setValveValue(tmpValve.getValue());
        }
        if (tmpSwitch != null && tmpSwitch.getValue() <= 0.99f) {
            tmpSwitch.setValue(tmpSwitch.getValue() + 0.01f);
            adapter.setValveValue(tmpSwitch.getValue());
        }
    }

    void valueTurnDown (GameObject tmp) {
        Valve tmpValve = tmp.GetComponent<Valve>();
        Switch tmpSwitch = tmp.GetComponent<Switch>();
        if (tmpValve != null && tmpValve.getValue() >= 0.01f) {
            tmpValve.setValue(tmpValve.getValue() - 0.01f);
            adapter.setValveValue(tmpValve.getValue());
        }
        if (tmpSwitch != null && tmpSwitch.getValue() >= 0.01f) {
            tmpSwitch.setValue(tmpSwitch.getValue() - 0.01f);
            adapter.setValveValue(tmpSwitch.getValue());
        }
    }

    void objectOnLeftClick (GameObject target) {
        if (!target.name.Equals("Calculate")) {
            if (target.GetComponent<RectTransform>() != null)
                forceOn.faceTo(target.transform.position, true);
            else
                forceOn.faceTo(target.transform.position, false);
        }
        InputField tmp = target.transform.GetComponent<InputField>();
        if (tmp != null) {
            tmp.ActivateInputField();
        }
    }

    void objectOnRightClick (GameObject target) {
        if (!target.name.Equals("Calculate")) {
            forceOn.cancelFaceTo();
        }
        InputField tmp = target.transform.GetComponent<InputField>();
        if (tmp != null) {
            tmp.DeactivateInputField();
        }
    }
}
