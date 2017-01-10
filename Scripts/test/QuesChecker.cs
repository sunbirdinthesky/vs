using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class QuesChecker : MonoBehaviour {
    int value = 0;
    const float checkDurition = 0.5f;
    List<questions> ques = new List<questions>();
    bool[] isWrong = new bool[10];
    float[] timeDelay = new float[10];

    void Start() {
        isWrong.Initialize();
        ques.Add(new wrongValveClosed());
        ques.Add(new MainOFTurnedOffUnormally());
        ques.Add(new MainOFTurnedOnUnormally());
        ques.Add(new HeaterLowWaterLevel());
        ques.Add(new safeValveLowWaterLevel());
        ques.Add(new WindOFTurnedOnUnormally());
    }
    
    void Update() {
        for(int i = 0; i < ques.Count; i++) {
            if (!isWrong[i] && ques[i].isError()) {
                GetComponent<TestSystem>().showWarning(ques[i].getErrorMessage());
                GetComponent<TestSystem>().deCreaseScore(ques[i].getDecreaseScore());
                isWrong[i] = true;
            } else {
                if (timeDelay[i] < 5f)
                    timeDelay[i] += Time.deltaTime;
                else {
                    isWrong[i] = false;
                    timeDelay[i] = 0f;
                }
            }
        }
    }

    public bool[] getIsWrong () {
        return isWrong;
    }
    
    class wrongValveClosed : questions {
        float realTime = 0;
        public override int getDecreaseScore() {
            return -30;
        }

        public override string getErrorMessage() {
            return "您不应当将蒸汽管道完全关闭，这可能会导致爆炸";
        }

        public override bool isError() {
            realTime += Time.deltaTime;
            if (realTime < checkDurition)
                return false;
            realTime = 0f;

            GameObject vlave5 = GameObject.Find("valve5");
            GameObject vlave6 = GameObject.Find("valve6");
            GameObject vlave3 = GameObject.Find("valve3");
            GameObject vlave4 = GameObject.Find("valve4");
            if (vlave3.GetComponent<Valve>().getValue() < 0.05f && vlave4.GetComponent<Valve>().getValue() < 0.05f)
                return true;
            if (vlave5.GetComponent<Valve>().getValue() < 0.05f && vlave6.GetComponent<Valve>().getValue() < 0.05f)
                return true;
            if (vlave3.GetComponent<Valve>().getValue() < 0.05f && vlave6.GetComponent<Valve>().getValue() < 0.05f)
                return true;
            if (vlave4.GetComponent<Valve>().getValue() < 0.05f && vlave5.GetComponent<Valve>().getValue() < 0.05f)
                return true;

            return false;
        }
    }

    class MainOFTurnedOffUnormally : questions {
        float realTime = 0;
        float lastValue = -1f;

        public override int getDecreaseScore() {
            return -10;
        }

        public override string getErrorMessage() {
            return "您不应当在没有关闭其他电源的时候关闭主电源";
        }

        public override bool isError() {
            realTime += Time.deltaTime;
            if (realTime < checkDurition)
                return false;
            realTime = 0f;

            GameObject mainOf = GameObject.Find("MainOF");
            GameObject windOf = GameObject.Find("WindOF");
            GameObject heatOf = GameObject.Find("HeatOF");
            GameObject heat = GameObject.Find("Heat");

            if (windOf.GetComponent<Switch>().getValue() < 0.05f
                && heatOf.GetComponent<Switch>().getValue() < 0.05f
                && heat.GetComponent<Switch>().getValue() < 0.05f)
                return false;

            float tmp = mainOf.GetComponent<Switch>().getValue();
            if (lastValue == -1f) {
                lastValue = tmp;
                return false;
            }

            if (lastValue - tmp > 1e-3) {
                lastValue = tmp;
                return true;
            }

            lastValue = tmp;
            return false;
        }
    }

    class MainOFTurnedOnUnormally : questions {
        float realTime = 0;

        public override int getDecreaseScore() {
            return -10;
        }

        public override string getErrorMessage() {
            return "您不应当在没有打开主电源时打开其他电源";
        }

        public override bool isError() {
            realTime += Time.deltaTime;
            if (realTime < checkDurition)
                return false;
            realTime = 0f;

            GameObject mainOf = GameObject.Find("MainOF");
            GameObject windOf = GameObject.Find("WindOF");
            GameObject heatOf = GameObject.Find("HeatOF");
            GameObject heat = GameObject.Find("Heat");

            if (mainOf.GetComponent<Switch>().getValue() > 0.95f)
                return false;

            if (windOf.GetComponent<Switch>().getValue() < 0.05f
                && heatOf.GetComponent<Switch>().getValue() < 0.05f
                && heat.GetComponent<Switch>().getValue() < 0.05f)
                return false;
            return true;
        }
    }

    class HeaterLowWaterLevel : questions {
        
        float realTime = 0;

        public override int getDecreaseScore() {
            return -30;
        }

        public override string getErrorMessage() {
            return "加热器液面过低，这可能会导致干烧，进而引发严重事故";
        }

        public override bool isError() {
            realTime += Time.deltaTime;
            if (realTime < checkDurition)
                return false;
            realTime = 0f;

            GameObject waterLevel = GameObject.Find("heatWaterLevel");
            GameObject mainOf = GameObject.Find("MainOF");
            if (mainOf.GetComponent<Switch>().getValue() > 0.05f
                && waterLevel.GetComponent<Valve>().getValue() < 0.7f)
                return true;

            return false;
        }
    }

    class safeValveLowWaterLevel : questions {

        float realTime = 0;

        public override int getDecreaseScore() {
            return -20;
        }

        public override string getErrorMessage() {
            return "安全水封液面过低，这可能会导致蒸汽管道泄压";
        }

        public override bool isError() {
            realTime += Time.deltaTime;
            if (realTime < checkDurition)
                return false;
            realTime = 0f;

            GameObject waterLevel = GameObject.Find("keeperWaterLevel");
            GameObject mainOf = GameObject.Find("keeperWaterLevel");
            if (mainOf.GetComponent<Switch>().getValue() > 0.05f
                && waterLevel.GetComponent<Valve>().getValue() < 0.7f)
                return true;

            return false;
        }
    }

    class WindOFTurnedOnUnormally : questions {
        float realTime = 0;
        float lastValue = -1f;

        public override int getDecreaseScore() {
            return -20;
        }

        public override string getErrorMessage() {
            return "您不应当在放空阀未完全开启时打开风机，这可能会损坏流量计";
        }

        public override bool isError() {
            realTime += Time.deltaTime;
            if (realTime < checkDurition)
                return false;
            realTime = 0f;
            
            GameObject windOf = GameObject.Find("WindOF");
            GameObject vlave1 = GameObject.Find("valve1");
            GameObject vlave2 = GameObject.Find("valve2");

            if (vlave1.GetComponent<Switch>().getValue() > 0.95f
                && vlave2.GetComponent<Switch>().getValue() > 0.95f)
                return false;

            float tmp = windOf.GetComponent<Switch>().getValue();
            if (lastValue == -1f) {
                lastValue = tmp;
                return false;
            }

            if (tmp - lastValue > 1e-3) {
                lastValue = tmp;
                return true;
            }

            lastValue = tmp;
            return false;
        }
    }

}
