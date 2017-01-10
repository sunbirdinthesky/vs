using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class onClickDoor : MonoBehaviour {

    public void clickDoor() {

        SceneManager.LoadScene("menu");
    }
}
