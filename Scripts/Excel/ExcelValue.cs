using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ExcelValue : MonoBehaviour {

    protected double InDia = 18;
    protected double ExDia = 22;
    protected double TubeLen = 1000;
    protected double Atmos = 101325;
    protected double InS = 0.05655;
    protected double ExS = 0.06912;
    protected double TC = 380;

    static protected double P0;
    static protected double V0;

    static protected double T1;
    static protected double T6;
    static protected double T12;
    static protected double T13;
    static protected double T14;
    static protected double T15;
    static protected double T22;
    static protected double T23;
    static protected double T24;
    static protected double T25;

    static protected double inTd;
    static protected double inLm;
    static protected double inMu;
    static protected double inPr;
    static protected double inRe;
    static protected double inTm;
    static protected double inNuC;
    static protected double inAC;
    static protected double inNuJ;
    static protected double inAJ;

    static protected double outTd;
    static protected double outRo;
    static protected double outLm;
    static protected double outMu;
    static protected double outR;
    static protected double outT;
    static protected double outTm;
    static protected double outAJ;
    static protected double outAC;

    static protected double airRo1;
    static protected double airV1;
    static protected double airG;
    static protected double airRe;

    static protected double hotQ;
    static protected double hotKC;
    static protected double hotKJ;
    static protected double hotKCJ;

    protected InputField t1;
    protected InputField t6;
    protected InputField t12;
    protected InputField t13;
    protected InputField t14;
    protected InputField t15;
    protected InputField t22;
    protected InputField t23;
    protected InputField t24;
    protected InputField t25;
    protected InputField p0;
    protected InputField v0;


    protected Text TdIn;
    protected Text LaIn;
    protected Text MuIn;
    protected Text ReIn;
    protected Text Pr;
    protected Text TmIn;
    protected Text NuC;
    protected Text ACIn;
    protected Text AJIn;
    protected Text NuJ;

    protected Text TdOut;
    protected Text Ro;
    protected Text LaOut;
    protected Text MuOut;
    protected Text r;
    protected Text DT;
    protected Text TmOut;
    protected Text AJOut;
    protected Text ACOut;

    protected Text Ro1;
    protected Text V1;
    protected Text G;
    protected Text ReAir;

    protected Text Q;
    protected Text KC;
    protected Text KJ;
    protected Text KCJ;


    // Use this for initialization
    void Start()
    {
        t1 = GameObject.Find("ET1").GetComponent<InputField>();
        t6 = GameObject.Find("ET6").GetComponent<InputField>();
        t12 = GameObject.Find("ET12").GetComponent<InputField>();
        t13 = GameObject.Find("ET13").GetComponent<InputField>();
        t14 = GameObject.Find("ET14").GetComponent<InputField>();
        t15 = GameObject.Find("ET15").GetComponent<InputField>();
        t22 = GameObject.Find("ET22").GetComponent<InputField>();
        t23 = GameObject.Find("ET23").GetComponent<InputField>();
        t24 = GameObject.Find("ET24").GetComponent<InputField>();
        t25 = GameObject.Find("ET25").GetComponent<InputField>();
        p0 = GameObject.Find("P0").GetComponent<InputField>();
        v0 = GameObject.Find("V0").GetComponent<InputField>();

        TdIn = GameObject.Find("t定In").transform.FindChild("Text").GetComponent<Text>();
        LaIn = GameObject.Find("λIn").transform.FindChild("Text").GetComponent<Text>();
        MuIn = GameObject.Find("μIn").transform.FindChild("Text").GetComponent<Text>();
        ReIn = GameObject.Find("ReIn").transform.FindChild("Text").GetComponent<Text>();
        Pr = GameObject.Find("Pr").transform.FindChild("Text").GetComponent<Text>();
        TmIn = GameObject.Find("ΔtmIn").transform.FindChild("Text").GetComponent<Text>();
        NuC = GameObject.Find("Nu测").transform.FindChild("Text").GetComponent<Text>();
        ACIn = GameObject.Find("α测In").transform.FindChild("Text").GetComponent<Text>();
        AJIn = GameObject.Find("α计In").transform.FindChild("Text").GetComponent<Text>();
        NuJ = GameObject.Find("Nu计").transform.FindChild("Text").GetComponent<Text>();

        TdOut = GameObject.Find("t定Out").transform.FindChild("Text").GetComponent<Text>();
        Ro = GameObject.Find("ρ").transform.FindChild("Text").GetComponent<Text>();
        LaOut = GameObject.Find("λOut").transform.FindChild("Text").GetComponent<Text>();
        MuOut = GameObject.Find("μOut").transform.FindChild("Text").GetComponent<Text>();
        r = GameObject.Find("r").transform.FindChild("Text").GetComponent<Text>();
        DT = GameObject.Find("Δt").transform.FindChild("Text").GetComponent<Text>();
        TmOut = GameObject.Find("ΔtmOut").transform.FindChild("Text").GetComponent<Text>();
        AJOut = GameObject.Find("α计Out").transform.FindChild("Text").GetComponent<Text>();
        ACOut = GameObject.Find("α测Out").transform.FindChild("Text").GetComponent<Text>();

        Ro1 = GameObject.Find("ρ1").transform.FindChild("Text").GetComponent<Text>();
        V1 = GameObject.Find("V1").transform.FindChild("Text").GetComponent<Text>();
        G = GameObject.Find("G").transform.FindChild("Text").GetComponent<Text>();
        ReAir = GameObject.Find("ReAir").transform.FindChild("Text").GetComponent<Text>();

        Q = GameObject.Find("Q").transform.FindChild("Text").GetComponent<Text>();
        KC = GameObject.Find("K测").transform.FindChild("Text").GetComponent<Text>();
        KJ = GameObject.Find("K计").transform.FindChild("Text").GetComponent<Text>();
        KCJ = GameObject.Find("K测计").transform.FindChild("Text").GetComponent<Text>();

      
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void setT1()
    {
        T1 = double.Parse(t1.text);
    }

    public void setT6()
    {
        T6 = double.Parse(t6.text);
    }

    public void setT12()
    {
        T12 = double.Parse(t12.text);
    }

    public void setT13() 
    {
        T13 = double.Parse(t13.text);    
    }

    public void setT14()
    {
        T14 = double.Parse(t14.text);
    }

    public void setT15()
    {
        T15 = double.Parse(t15.text);
    }

    public void setT22()
    {
        T22 = double.Parse(t22.text);
    }

    public void setT23()
    {
        T23 = double.Parse(t23.text);
    }

    public void setT24()
    {
        T24 = double.Parse(t24.text);
    }

    public void setT25()
    {
        T25 = double.Parse(t25.text);
    }

    public void setV0()
    {
        V0 = double.Parse(v0.text);
    }

    public void setP0()
    {
        P0 = double.Parse(p0.text);
    }

    public double getT1()
    {
        return T1;
    }

    public double getT6()
    {
        return T6;
    }

    public double getT12()
    {
        return T12;
    }

    public double getT13()
    {
        return T13;
    }

    public double getT14()
    {
        return T14;
    }

    public double getT15()
    {
        return T15;
    }

    public double getT22()
    {
        return T22;
    }

    public double getT23()
    {
        return T23;
    }

    public double getT24()
    {
        return T24;
    }

    public double getT25()
    {
        return T25;
    }

    public double getV0()
    {
        return V0;
    }

    public double getP0()
    {
        return P0;
    }
}
