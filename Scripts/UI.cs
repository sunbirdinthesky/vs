using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UI : MonoBehaviour {
    public Text messageBoard;
	// Use this for initialization
	void Start () {
        messageBoard.transform.localPosition = new Vector3(Screen.width / 2.0f - 110, -Screen.height / 2.0f + 35, 0f);
	}
	
	// Update is called once per frame
	void Update () {
        RaycastHit hit;
        Vector2 v = new Vector2(Screen.width / 2, Screen.height / 2); //屏幕中心点
        Ray tmp = Camera.main.ScreenPointToRay(v);
        Debug.DrawRay(Camera.main.transform.position, tmp.direction);
        if (Physics.Raycast(Camera.main.ScreenPointToRay(v), out hit, 3f, LayerMask.GetMask("tips"))) {
            messageBoard.text = hit.collider.gameObject.name;
            return;
        }
        messageBoard.text = "N/A";
    }
}
