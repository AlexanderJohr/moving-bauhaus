using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraShake : MonoBehaviour {

    private Camera mainCam;
    private float shakeAmount = 0;

	void Awake ()
    {
        mainCam = Camera.main;
	}
	

	public void Shake (float amt, float length)
    {
        shakeAmount = amt;
        InvokeRepeating("DoShake", 0, 0.01f);
        Invoke("StopShake", length);
	}

    void DoShake()
    {
        Vector3 camPos = mainCam.transform.position;

        if(shakeAmount > 0)
        {
            float offSetY = Random.value * shakeAmount * 2 - shakeAmount;
            camPos.y = camPos.y + offSetY;
        }

        mainCam.transform.position = camPos;
    }

    void StopShake()
    {
        CancelInvoke("DoShake");
        mainCam.transform.localPosition = Vector3.zero;
    }
}
