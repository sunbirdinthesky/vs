using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ExcelDEmo : ExcelValue
{
    bool isSmooth = true;
    public void OnClick()
    {
        if (t1.text.Equals("") ||
            t6.text.Equals("") ||
            v0.text.Equals("") ||
            p0.text.Equals("")) {
            Debug.Log("EXCEL:Data ERROR");
            return;
        }

        if (!t12.text.Equals("") &&
            !t13.text.Equals("") &&
            !t14.text.Equals("") &&
            !t15.text.Equals("")) {
            isSmooth = true;
            Debug.Log("EXCEL:SmoothMode");
        }
        else if (!t22.text.Equals("") &&
            !t23.text.Equals("") &&
            !t24.text.Equals("") &&
            !t25.text.Equals("")) {
            isSmooth = false;
            Debug.Log("EXCEL:RoughMode");
        } else {
            Debug.Log("EXCEL:Data ERROR");
            return;
        }
        Calculate();
        ShowValue();
        DrawLogTable tmp = GameObject.Find("logtable").GetComponent<DrawLogTable>();
        tmp.addRecord((float)inNuC, float.Parse(ReAir.text));
        tmp.draw();
    }

    void transValue() {

    }

    void Calculate()
    {
        
        //此处添加光滑管与螺纹管改变的开关
        if (isSmooth == true)
        {
            SmoothPipe();
        }
        else if (isSmooth == false)
        {
            RoughPipe();
        }
    }

    void SmoothPipe()
    {
        inTd = (T12 + T14) / 2;
        inLm = 0.0753 * inTd + 24.45;
        inMu = 0.0492 * inTd + 17.15;
        inPr = -0.0002 * inTd + 0.7063;

        outTd = ((T13 + T15) / 2 + T6) / 2;
        outRo = 0.00002 * System.Math.Pow(outTd, 3) - 0.0059 * System.Math.Pow(outTd, 2) + 0.0191 * outTd + 999.99;
        outLm = -0.00001 * System.Math.Pow(outTd, 2) + 0.0023 * outTd + 0.5565;
        outMu = (0.0418 * System.Math.Pow(outTd, 2) - 11.14 * outTd + 979.02) / 1000;
        outR = -0.0019 * System.Math.Pow(outTd, 2) - 2.1265 * outTd + 2489.3;

        airRo1 = (Atmos + P0) * (273 + 20) * 1.205 / Atmos / (273 + T1);
        airV1 = System.Math.Pow((1.205 / airRo1), 0.5) * V0;
        airG = airRo1 * airV1;
        airRe = 4 * airG / 3600 / (3.1416 * InDia / 1000 * inMu / 1000000);

        hotQ = airG / 3600 * 1.005 * 1000 * (T14 - T12);

        inRe = airRe / 10000;
        inTm = ((T13 - T12) - (T15 - T14)) / System.Math.Log(((T13 - T12) / (T15 - T14)), System.Math.E);
        inAC = hotQ / (inTm * InS);
        inNuC = inAC * InDia / 1000 / (inLm / 1000);
        inAJ = 0.023 * inLm / InDia * System.Math.Pow((inRe * 10000), 0.8) * System.Math.Pow(inPr, 0.4);
        inNuJ = 0.023 * System.Math.Pow((inRe * 10000), 0.8) * System.Math.Pow(inPr, 0.4);

        outT = T6 - (T15 + T13) / 2;
        outTm = ((T6 - T13) + (T6 - T15)) / 2;
        outAJ = 0.725 * System.Math.Pow((System.Math.Pow(outRo, 2) * 9.81 * System.Math.Pow(outLm, 3) * outR * 1000 / (ExDia / 1000 * outT * outMu / 1000)), 0.25);//
        outAC = hotQ / (ExS * outTm);

        hotKC = hotQ / (((T6 - T14) - (T6 - T12)) * ExS / System.Math.Log(((T6 - T14) / (T6 - T12)), System.Math.E));
        hotKCJ = 1 / (ExDia / InDia / inAC + ExDia / (InDia + ExDia) / 2 * (ExDia - InDia) / 2000 / TC + 1 / outAC);
        hotKJ = 1 / (ExDia / InDia / inAJ + ExDia / (InDia + ExDia) / 2 * (ExDia - InDia) / 2000 / TC + 1 / outAJ);

        //以上为光滑管计算公式
    }

    void RoughPipe()
    {
        inTd = (T22 + T24) / 2;
        inLm = 0.0753 * inTd + 24.45;
        inMu = 0.0492 * inTd + 17.15;
        inPr = -0.0002 * inTd + 0.7063;

        outTd = ((T23 + T25) / 2 + T6) / 2;
        outRo = 0.00002 * System.Math.Pow(outTd, 3) - 0.0059 * System.Math.Pow(outTd, 2) + 0.0191 * outTd + 999.99;
        outLm = -0.00001 * System.Math.Pow(outTd, 2) + 0.0023 * outTd + 0.5565;
        outMu = (0.0418 * System.Math.Pow(outTd, 2) - 11.14 * outTd + 979.02) / 1000;
        outR = -0.0019 * System.Math.Pow(outTd, 2) - 2.1265 * outTd + 2489.3;

        airRo1 = (Atmos + P0) * (273 + 20) * 1.205 / (Atmos * (273 + T1));
        airV1 = System.Math.Pow((1.205 / airRo1), 0.5) * V0;
        airG = airRo1 * airV1;
        airRe = 4 * airG / 3600 / (3.1416 * InDia * inMu / (1000 * 1000000));

        hotQ = airG * 1.005 * 1000 * (T24 - T22) / 3600;

        inRe = airRe / 10000;
        inTm = ((T23 - T22) - (T25 - T24)) / System.Math.Log(((T23 - T22) / (T25 - T24)), System.Math.E);
        inAC = hotQ / (inTm * InS);
        inNuC = inAC * InDia / 1000 / (inLm / 1000);
        inAJ = 0.023 * inLm * System.Math.Pow((inRe * 10000), 0.8) * System.Math.Pow(inPr, 0.4) / InDia;
        inNuJ = 0.023 * System.Math.Pow((inRe * 10000), 0.8) * System.Math.Pow(inPr, 0.4);

        outT = T6 - (T25 + T23) / 2;
        outTm = ((T6 - T23) + (T6 - T25)) / 2;
        outAJ = 0.725 * System.Math.Pow((System.Math.Pow(outRo, 2) * 9.81 * System.Math.Pow(outLm, 3) * outR * 1000 / (ExDia * outT * outMu / 1000 / 1000)), 0.25);
        outAC = hotQ / (ExS * outTm);

        hotKC = hotQ / (((T6 - T24) - (T6 - T22)) * ExS / System.Math.Log(((T6 - T24) / (T6 - T22)), System.Math.E));
        hotKCJ = 1 / (ExDia / InDia / inAC + ExDia / (InDia + ExDia) / 2 * (ExDia - InDia) / 2000 / TC + 1 / outAC);
        hotKJ = 1 / (ExDia / InDia / inAJ + ExDia / (InDia + ExDia) / 2 * (ExDia - InDia) / 2000 / TC + 1 / outAJ);

        //以上为螺纹管计算公式
    }

    void ShowValue()
    {
        TdIn.text = inTd.ToString();
        LaIn.text = inLm.ToString();
        MuIn.text = inMu.ToString();
        ReIn.text = inRe.ToString();
        Pr.text = inPr.ToString();
        TmIn.text = inTm.ToString();
        NuC.text = inNuC.ToString();
        ACIn.text = inAC.ToString();
        AJIn.text = inAJ.ToString();
        NuJ.text = inNuJ.ToString();

        TdOut.text = outTd.ToString();
        Ro.text = outRo.ToString();
        LaOut.text = outLm.ToString();
        MuOut.text = outMu.ToString();
        r.text = outR.ToString();
        DT.text = outT.ToString();
        TmOut.text = outTm.ToString();
        AJOut.text = outAJ.ToString();
        ACOut.text = outAC.ToString();

        Ro1.text = airRo1.ToString();
        V1.text = airV1.ToString();
        G.text = airG.ToString();
        ReAir.text = airRe.ToString();

        Q.text = hotQ.ToString();
        KC.text = hotKC.ToString();
        KJ.text = hotKJ.ToString();
        KCJ.text = hotKCJ.ToString();
    }
}
