using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class DrawLogTable : MonoBehaviour {
    public GameObject logTableRoot;
	public GameObject line;
    public GameObject point;

    List <record> records = new List<record>();

    class record {
        public float Nu;
        public float Re;
        public record (float Nu, float Re) {
            this.Nu = Nu;
            this.Re = Re;
        }
    }

    class cmp : IComparer<record> {
        public int Compare(record x, record y) {
            if (x.Re < y.Re)
                return -1;
            return 1;
        }
    }

    void Start () {
        //addRecord(50, 10000);
        //addRecord(100, 50000);
        //addRecord(150, 80000);
        //addRecord(200, 100000);
        //draw();
        //clearRecords();
        //addRecord(50, 100000);
        //addRecord(100, 80000);
        //addRecord(150, 50000);
        //addRecord(200, 10000);
        //draw();
    }

    public void addRecord(float Nu, float Re) {
        if (float.IsNaN(Nu) || float.IsNaN(Re)) {
            Debug.Log("LogTable data error! Nan occored!");
            return;
        }
        records.Add(new record(Nu, Re));
    }

    public void clearRecords() {
        records.Clear();
    }
    public void draw () {
        logTableRoot.transform.DestroyChildren();
        records.Sort(new cmp());
        drawPositions();
        drawLine();
    }

    void drawLine () {
        List<float> px = new List<float>();
        List<float> py = new List<float>();
        int len = records.Count;
        for (int i = 0; i < len; i++) {
            float x = Mathf.Log10(records[i].Re / 10000f) * 90f;
            float y = Mathf.Log10(records[i].Nu / 10f) * 56f;
            px.Add(x);
            py.Add(y);
            //Debug.Log(records[i].Re);
        }

       
        for (int i = 0; i < len-1; i++) {
            float b = px[i + 1] - px[i];
            float c = py[i + 1] - py[i];
            float xcenter = (px[i + 1] + px[i]) / 2f;
            float ycenter = (py[i + 1] + py[i]) / 2f;
            float a = Mathf.Sqrt(b * b + c * c);
            float rotationZ = Mathf.Acos(b/a);
            if (float.IsNaN(rotationZ))
                rotationZ = 0;
            if (c < 0f)
                rotationZ = -rotationZ;

            GameObject tmp = (GameObject)Instantiate(line);
            tmp.transform.SetParent(logTableRoot.transform);
            RectTransform t = tmp.GetComponent<RectTransform>();
            t.sizeDelta = new Vector2(a, 100f);
            //Debug.Log("test! " + Quaternion.Euler(0f, 0f, rotationZ * 180f / Mathf.PI));
            t.localRotation = Quaternion.Euler(0f, 0f, rotationZ*180f/Mathf.PI);
            t.localPosition = new Vector3(xcenter, ycenter, 0f);
            t.transform.localScale = new Vector3(1f, 0.005f, 1f);
        }
    }
        
	void drawPositions () {
        int len = records.Count;
		for (int i = 0; i < len; i++) {
			float x = Mathf.Log10(records[i].Re/10000f)*90f;
			float z = Mathf.Log10(records[i].Nu/10f)*56f;
            GameObject tmp = (GameObject)Instantiate(point);
            tmp.transform.SetParent(logTableRoot.transform);
            tmp.transform.localPosition = new Vector2(x, z);
            tmp.transform.localRotation = Quaternion.Euler(0f, 0f, 90f);
            tmp.transform.localScale = new Vector3(0.05f, 0.05f, 1f);
		}
	}
}
