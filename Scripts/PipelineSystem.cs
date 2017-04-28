using UnityEngine;
using System.Collections.Generic;

public class PipelineSystem : MonoBehaviour {//need changed
    List<PressureGauge> pressureGauges = new List<PressureGauge> ();
    List<Valve> valves = new List<Valve> ();
    List<Thormenter> thormenters = new List<Thormenter> ();

    MainPipeline mainPipeLine;
    DataPackage normal;
    DataPackage special;
    Furnace furnace;
    AirBlast airBlast;

    public AirBlastPipline airBlastPipeline;
    public Switch heatOF;

    int[] thormenterIndex;
    int[] valveIndex;
    int[] pressureGaugeIndex;

    // Use this for initialization
    void Start() {
        furnace = GameObject.Find("furnace").GetComponent<Furnace>();
        airBlast = GameObject.Find("airBlast").GetComponent<AirBlast>();
        mainPipeLine = GameObject.Find("mainPipeLine").GetComponent<MainPipeline>();

        // init for array
        thormenterIndex = new int[15];
        valveIndex = new int[6];
        pressureGaugeIndex = new int[2];

        //init for thormenters
        for (int i = 1; i <= 25; i++) {
            GameObject tmp = GameObject.Find("thormenter" + i);
            if (tmp != null) {
                Thormenter tmpl = tmp.GetComponent<Thormenter>();
                thormenterIndex[thormenters.Count] = i;
                thormenters.Add(tmpl);
            }
        }

        //init for valves
        for (int i = 1; i <= 6; i++) {
            GameObject tmp = GameObject.Find("valve" + i);
            if (tmp != null) {
                Valve tmpl = tmp.GetComponent<Valve>();
                valveIndex[valves.Count] = i;
                valves.Add(tmpl);
            }
        }

        //init for pressureGauges
        for (int i = 1; i <= 2; i++) {
            GameObject tmp = GameObject.Find("pressureGauge" + i);
            if (tmp != null) {
                PressureGauge tmpl = tmp.GetComponent<PressureGauge>();
                pressureGaugeIndex[pressureGauges.Count] = i;
                pressureGauges.Add(tmpl);
            }
        }

        Debug.Log("PipelineSystem Init()"
            + "thormenters.Count = " + thormenters.Count
            + "valves.Count = " + valves.Count
            + "pressureGauges.Count = " + pressureGauges.Count);
    }

    // Update is called once per frame
    void Update() {
        //thormenters[0].setValue(102.3f);
        getValues();
        if (valves[5].getValue() >= 0.95f)
            sendValuesNormal();
        else if (valves[4].getValue() >= 0.95f)
            sendValuesSpecal();
        else
            sendValuesZero();
        mainPipeLine.setParticalLevel(furnace.getValue());
    }

    void getValues() {
        normal = emulaterNormal();
        special = emulaterSpecial();
    }

    void sendValuesNormal() {
        airBlastPipeline.setValue(normal.v0);
        //send to pressure gauge
        for (int i = 0; i < pressureGauges.Count; i++) {
            switch (pressureGaugeIndex[i]) {
                case 1:
                    pressureGauges[i].setValue(furnace.getValue() * 1.8f);
                    break;
                case 2:
                    pressureGauges[i].setValue(normal.p0/1000f);
                    break;
            }
        }

        //send to thormenters
        for (int i = 0; i < thormenters.Count; i++) {
            switch (thormenterIndex[i]) {
                case 1:
                    thormenters[i].setValue(normal.t1);
                    break;
                case 6:
                    thormenters[i].setValue(normal.t6);
                    break;
                case 12:
                    thormenters[i].setValue(normal.t12);
                    break;
                case 13:
                    thormenters[i].setValue(normal.t13);
                    break;
                case 14:
                    thormenters[i].setValue(normal.t14);
                    break;
                case 15:
                    thormenters[i].setValue(normal.t15);
                    break;
                case 22:
                    thormenters[i].setValue(0);
                    break;
                case 23:
                    thormenters[i].setValue(0);
                    break;
                case 24:
                    thormenters[i].setValue(0);
                    break;
                case 25:
                    thormenters[i].setValue(0);
                    break;
            }
        }
    }

    void sendValuesSpecal() {
        airBlastPipeline.setValue(special.v0);
        //send to pressure gauge
        for (int i = 0; i < pressureGauges.Count; i++) {
            switch (pressureGaugeIndex[i]) {
                case 1:
                    pressureGauges[i].setValue(furnace.getValue() * 1.8f);
                    break;
                case 2:
                    pressureGauges[i].setValue(special.p0 / 1000f);
                    break;
            }
        }

        //send to thormenters
        for (int i = 0; i < thormenters.Count; i++) {
            switch (thormenterIndex[i]) {
                case 1:
                    thormenters[i].setValue(special.t1);
                    break;
                case 6:
                    thormenters[i].setValue(special.t6);
                    break;
                case 12:
                    thormenters[i].setValue(0);
                    break;
                case 13:
                    thormenters[i].setValue(0);
                    break;
                case 14:
                    thormenters[i].setValue(0);
                    break;
                case 15:
                    thormenters[i].setValue(0);
                    break;
                case 22:
                    thormenters[i].setValue(special.t22);
                    break;
                case 23:
                    thormenters[i].setValue(special.t23);
                    break;
                case 24:
                    thormenters[i].setValue(special.t24);
                    break;
                case 25:
                    thormenters[i].setValue(special.t25);
                    break;

            }
        }
    }

    void sendValuesZero() {
        airBlastPipeline.setValue(0);
        //send to pressure gauge
        for (int i = 0; i < pressureGauges.Count; i++) {
            switch (pressureGaugeIndex[i]) {
                case 1:
                    pressureGauges[i].setValue(0);
                    break;
                case 2:
                    pressureGauges[i].setValue(0);
                    break;
            }
        }

        //send to thormenters
        for (int i = 0; i < thormenters.Count; i++) {
            switch (thormenterIndex[i]) {
                case 1:
                    thormenters[i].setValue(0);
                    break;
                case 6:
                    thormenters[i].setValue(0);
                    break;
                case 12:
                    thormenters[i].setValue(0);
                    break;
                case 13:
                    thormenters[i].setValue(0);
                    break;
                case 14:
                    thormenters[i].setValue(0);
                    break;
                case 15:
                    thormenters[i].setValue(0);
                    break;
                case 22:
                    thormenters[i].setValue(0);
                    break;
                case 23:
                    thormenters[i].setValue(0);
                    break;
                case 24:
                    thormenters[i].setValue(0);
                    break;
                case 25:
                    thormenters[i].setValue(0);
                    break;

            }
        }
    }

    DataPackage emulaterNormal() {
        DataPackage tmpNormal = new DataPackage();
        tmpNormal.t6 = furnace.getValue() * 145f;
        tmpNormal.t15 = tmpNormal.t6 * 0.99f;
        tmpNormal.t13 = tmpNormal.t6 * 0.97f;

        float valve1_2 = valves[0].getValue() + valves[1].getValue(); //放空阀级别
        float windLevel = 1f - valve1_2/2f;
        if (airBlast.GetComponent<AirBlast>().getValue() <= 0.05f)
            windLevel = 0f;

        tmpNormal.v0 = 35f * windLevel;
        tmpNormal.p0 = 10000f * windLevel;
        tmpNormal.t1 = 24f * windLevel;

        tmpNormal.t12 = tmpNormal.t1 * (1f - 0.3f * windLevel);
        tmpNormal.t14 = tmpNormal.t15 * (1f - 0.4f * windLevel);
        
        float mark = 100f;

        while (mark > 1e-3) {
            float td = tmpNormal.t12 + tmpNormal.t14;
            float v1 = Mathf.Pow(1.205f / 1000f, 0.5f) * tmpNormal.v0;
            float p1 = (101325 + tmpNormal.p0) / 101325f * (273f + 20f) / (273f + tmpNormal.t1) * 1.025f;
            float g = p1 * v1;
            float u = (0.0418f * Mathf.Pow(td, 2f) - 11.14f * td + 979.02f) / 1000f;
            float re = 4f * g / 3600f * (Mathf.PI * 18f / 1000f * u / 1000000f);

            float pr = -0.0002f * td + 0.7063f;
            float nu = 0.023f * Mathf.Pow(re, 0.8f) * Mathf.Pow(pr, 0.4f);

            float nuMath = 0.0253f * Mathf.Pow(re, 0.7713f);

            if (nu < nuMath) {
                if (tmpNormal.t14 < tmpNormal.t15 + mark)
                    tmpNormal.t14 += mark;
            }
            else {
                if (tmpNormal.t14 > mark + tmpNormal.t12)
                    tmpNormal.t14 -= mark;
            }
            mark /= 2f;
        }
        return tmpNormal;
    }

    DataPackage emulaterSpecial() {
        DataPackage tmpSpecial = new DataPackage();
        tmpSpecial.t6 = furnace.getValue() * 145f;
        tmpSpecial.t25 = tmpSpecial.t6 * 0.99f;
        tmpSpecial.t23 = tmpSpecial.t6 * 0.97f;

        float valve1_2 = valves[0].getValue() + valves[1].getValue(); //放空阀级别
        float windLevel = 1f - valve1_2 / 2f;
        if (airBlast.GetComponent<AirBlast>().getValue() <= 0.05f)
            windLevel = 0f;

        tmpSpecial.v0 = 25f * windLevel;
        tmpSpecial.p0 = 16000f * windLevel;
        tmpSpecial.t1 = 38f * windLevel;

        tmpSpecial.t22 = tmpSpecial.t1 * (1 - 0.2f * windLevel);
        tmpSpecial.t24 = tmpSpecial.t25 * (1 - 0.2f * windLevel);

      
        float mark = 100f;

        while (mark > 1e-3) {
            float td = tmpSpecial.t22 + tmpSpecial.t24;
            float v1 = Mathf.Pow(1.205f / 1000f, 0.5f) * tmpSpecial.v0;
            float p1 = (101325 + tmpSpecial.p0) / 101325f * (273f + 20f) / (273f + tmpSpecial.t1) * 1.025f;
            float g = p1 * v1;
            float u = (0.0418f * Mathf.Pow(td, 2f) - 11.14f * td + 979.02f) / 1000f;
            float re = 4f * g / 3600f * (Mathf.PI * 18f / 1000f * u / 1000000f);

            float pr = -0.0002f * td + 0.7063f;
            float nu = 0.023f * Mathf.Pow(re, 0.8f) * Mathf.Pow(pr, 0.4f);

            float nuMath = 0.0328f * Mathf.Pow(re, 0.8173f);

            if (nu < nuMath) {
                if (tmpSpecial.t24 < tmpSpecial.t25 + mark)
                    tmpSpecial.t24 += mark;
            }
            else {
                if (tmpSpecial.t24 > mark + tmpSpecial.t22)
                    tmpSpecial.t24 -= mark;
            }
            mark /= 2f;
        }

        return tmpSpecial;
    }
}
