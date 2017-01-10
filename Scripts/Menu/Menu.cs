using UnityEngine;
using System.Collections;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {

    Canvas MainC, CourseC;
    RectTransform Main;
    RectTransform Sub;
    Tweener tMain;
    Tweener tSub;
    float SubX;

	// Use this for initialization
	void Start () {
        MainC = GameObject.Find("MainCanvas").GetComponent<Canvas>();
        CourseC = GameObject.Find("CourseCanvas").GetComponent<Canvas>();
        Main = GameObject.Find("Menu").GetComponent<RectTransform>();
        Sub = GameObject.Find("SubMenu").GetComponent<RectTransform>();
        SubX = Sub.position.x;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void StartButton()
    {
        tMain = Main.DOMoveX(SubX, 0.5f);
        tSub = Sub.DOMoveX(0, 1f);
        tSub.SetEase<Tweener>(Ease.OutElastic);
        
    }

    public void ReturnButton()
    {
        tSub = Sub.DOMoveX(SubX, 0.5f);
        tMain = Main.DOMoveX(0, 1f);
        tMain.SetEase<Tweener>(Ease.OutElastic);
    }

    public void TrainButton()
    {
        //add main scene here
        Debug.Log("loaging train");
        SceneManager.LoadScene("train");
    }

    public void TestButton() {
        //add test scene here
        //SceneManager.LoadScene();
        Debug.Log("loaging train");
        SceneManager.LoadScene("practice");
    }

    public void CourseButton()
    {
        MainC.planeDistance = 2.5f;
    }

    public void CourseReturn()
    {
        MainC.planeDistance = 0.5f;
    }

    public void ExitButton()
    {
        Application.Quit();
    }

}
