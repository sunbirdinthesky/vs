using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PowerBox : MonoBehaviour {
    List<DigitalInstrument> digitalInstruments = new List<DigitalInstrument> ();
    List<Switch> switchs = new List<Switch> ();
    List<Thormenter> thormenters = new List<Thormenter> ();
    Furnace furnance;
    AirBlast airBlast;

    List<float> temperatures = new List<float>();
    List<float> switchStates = new List<float>();

    Dictionary <string, int> thormenterNumber = new Dictionary<string, int> ();
    Dictionary<string, int> switchNumber = new Dictionary<string, int> ();
    Dictionary<string, int> digitalInstrumentsNumber = new Dictionary<string, int> ();

    bool furnanceSwitch = false;
    bool airBlastSwitch = false;

    // Use this for initialization
    void Start () {
        furnance = GameObject.Find("furnace").GetComponent<Furnace>();
        airBlast = GameObject.Find("airBlast").GetComponent<AirBlast>();

        GameObject tmp;

        //获得各个温度计的组件，初始化
        for (int i = 1; i <= 25; i++) {
            tmp = GameObject.Find("thormenter" + i);
            if (tmp != null) {
                thormenterNumber.Add("thormenter" + i, thormenters.Count);
                thormenters.Add(tmp.GetComponent<Thormenter>());
            }
        }  

        //获取Switch组件
        tmp = GameObject.Find("Heat");//加热旋钮获取
        if (tmp != null)
        {
            switchNumber.Add("Heat", switchs.Count);
            switchs.Add(tmp.GetComponent<Switch>());
        }

        tmp = GameObject.Find("MainOF");//总电源开关获取
        if (tmp != null)
        {
            switchNumber.Add("MainOF", switchs.Count);
            switchs.Add(tmp.GetComponent<Switch>());
        }

        tmp = GameObject.Find("WindOF");//风机开关获取
        if (tmp != null)
        {
            switchNumber.Add("WindOF", switchs.Count);
            switchs.Add(tmp.GetComponent<Switch>());
        }

        tmp = GameObject.Find("HeatOF");//加热开关获取
        if (tmp != null)
        {
            switchNumber.Add("HeatOF", switchs.Count);
            switchs.Add(tmp.GetComponent<Switch>());
        }
        
        for (int i = 1; i <= 25; i++)
        {
            tmp = GameObject.Find("digitalInstrument" + i);
            if (tmp != null)
            {
                digitalInstrumentsNumber.Add("digitalInstrument" + i, digitalInstruments.Count);
                digitalInstruments.Add(tmp.GetComponent<DigitalInstrument>());
            }
        }

    }
	
	// Update is called once per frame
	void Update () {
        getValues();
        sendValues();
	}

    void getValues () {
        temperatures.Clear(); //获取温度
        foreach (Thormenter tmp in thormenters) {
            temperatures.Add(tmp.getValue());
        }

        switchStates.Clear(); //获取开关状态
        foreach (Switch tmp in switchs) {
            switchStates.Add(tmp.getValue());
        }
    }

    void sendValues()
    {
        int i;
        for (i = 0; i < digitalInstruments.Count; i++)//传递数显
        {
            //Debug.Log("post" + i);
            digitalInstruments[i].setValue(temperatures[i]);
        }


        if (switchStates[1] >= 0.9 && switchStates[3] >= 0.9)//传递加热器
        {
            furnance.setValue(switchStates[0]);
        }
        else
        {
            furnance.setValue(0);
        }


        if (switchStates[1] >= 0.9)//传递风机
        {
            airBlast.setValue(switchStates[2]);
        }
        else
        {
            airBlast.setValue(0);
        }
    }
}
