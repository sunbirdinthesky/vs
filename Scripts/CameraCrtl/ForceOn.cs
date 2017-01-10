using UnityEngine;
using System.Collections;
using UnityStandardAssets.Characters.FirstPerson;
public class ForceOn : MonoBehaviour {
    public FirstPersonController FPSContrler;
    public CourseLock courseLock;
    public CharacterController characterController;
    public float moveSpeed = 0.75f;

    bool lockCamera = false;
    bool resume = false;
    bool blocked = false;
    Vector3 lastPos = new Vector3();
    Vector3 targetPos = new Vector3();
    bool isUI;

    public void faceTo (Vector3 target, bool isUI) {
        if (blocked)
            return;
        this.isUI = isUI;
        lastPos = Camera.main.transform.position;
        targetPos = target;
        lockCamera = true;
        FPSContrler.enabled = false;
        characterController.enabled = false;
        blocked = true;
    }

    public void cancelFaceTo () {
        if (!blocked)
            return;
        lockCamera = false;
        resume = true;
    }

    
    void Update () {
        if (lockCamera) {
            Camera.main.transform.LookAt(targetPos);
            Vector3 newTargetPos;
            if (isUI)
                newTargetPos = targetPos + new Vector3(-1.5f, 0f, 0f);
            else
                newTargetPos = targetPos + new Vector3(0f, 0f, -1.5f);
            Vector3 dis = newTargetPos - Camera.main.transform.position;
            //Debug.Log(dis.magnitude);

            if (isDisTooSmall(dis)) {
                lockCamera = false;

                return;
            }
            Camera.main.transform.position += dis * moveSpeed * Time.deltaTime;
        }
        if (resume) {
            Camera.main.transform.LookAt(targetPos);
            Vector3 dis = lastPos - Camera.main.transform.position;
            //Debug.Log(dis.magnitude);
            if (isDisTooSmall(dis)) {
                resume = false;
                characterController.enabled = true;
                FPSContrler.enabled = true;
                blocked = false;
                return;
            }
            Camera.main.transform.position += dis * moveSpeed * Time.deltaTime;
        }
    }

    bool isDisTooSmall (Vector3 val) {
        return val.magnitude < 1e-2f;
    }
	// Use this for initialization
}
