using UnityEngine;
using System.Collections;

public class MainPipeline : MonoBehaviour {
    
    public GameObject normalStream;

    public GameObject specialStream;
    // Use this for initialization
    void Start() {
    }

    // Update is called once per frame
    void Update() {
        //normalStream.GetComponent<EllipsoidParticleEmitter>().maxEmission = 1 * 100f;
        //specialStream.GetComponent<EllipsoidParticleEmitter>().maxEmission = 1 * 100f;
    }


    ///// <summary>
    ///// caution : may cause problem
    ///// </summary>
    ///// <param name="index"></param>
    ///// <param name="isVisitable"></param>
    ///// 
    ////0 means normal, 1 means special
    //public void setVisitable(int index, bool isVisitable) {
    //    if (index == 0) {
    //        normal.SetActive(isVisitable);
    //        return;
    //    }
    //    special.SetActive(isVisitable);
    //}

    /// <summary>
    /// level is from 0 to 1
    /// </summary>
    /// <param name="level"></param>
    public void setParticalLevel(float level) {
        //normalStream.GetComponent<EllipsoidParticleEmitter>().maxEmission = level * 100f;
        //specialStream.GetComponent<EllipsoidParticleEmitter>().maxEmission = level * 100f;
        if (level > 0.2f) {
            normalStream.SetActive(true);
            specialStream.SetActive(true);
        }else {
            normalStream.SetActive(false);
            specialStream.SetActive(false);
        }
    }
}
