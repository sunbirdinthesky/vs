using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class onClick : MonoBehaviour {
    public DrawLogTable logTable;
	// Use this for initialization
	public void click () {
        logTable.clearRecords();
        logTable.draw();
    }
}
