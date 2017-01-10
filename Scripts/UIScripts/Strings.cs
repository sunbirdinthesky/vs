using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Strings : MonoBehaviour {
    Dictionary<string, string> map = new Dictionary<string, string>();

    void Start () {
        map.Add("valve1", "阀门1");
        map.Add("valve2", "阀门2");
        map.Add("valve3", "阀门3");
        map.Add("valve4", "阀门4");
        map.Add("valve5", "阀门5");
        map.Add("valve6", "阀门6");

        map.Add("pressureGauge1", "压力表（P0，Kpa）");
        map.Add("pressureGauge2", "压力表（P0，Kpa）");
        map.Add("airBlastPipeline", "流量计（V0，m3/h）");

        map.Add("Heat", "加热旋钮");
        map.Add("MainOF", "主电源开关");
        map.Add("WindOF", "风机开关");
        map.Add("HeatOF", "加热釜开关");

        map.Add("normal", "普通管");
        map.Add("special", "螺纹管");

        map.Add("ET1", "T1");
        map.Add("ET6", "T6");

        map.Add("ET12", "T12");
        map.Add("ET13", "T13");
        map.Add("ET14", "T14");
        map.Add("ET15", "T15");

        map.Add("ET22", "T22");
        map.Add("ET23", "T23");
        map.Add("ET24", "T24");
        map.Add("ET25", "T25");

        map.Add("door", "结束实验");

        map.Add("Calculate", "计算"); 
        map.Add("outsideMark", "流量计（V0，m3/h）");

        map.Add("digitalInstrumentLeft", "温度计");
        map.Add("digitalInstrumentMid", "温度计");
        map.Add("digitalInstrumentRight", "温度计"); 

        map.Add("keeperWaterLevel", "液封水位");
        map.Add("heatrWaterLevel", "加热釜水位");
    }

    public string getMapString (string key) {
        if (map.ContainsKey(key))
            return map[key];
        return key;
    }
}
