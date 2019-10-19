using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class particle : MonoBehaviour {

    private ParticleSystem ps;

    private void OnEnable()
    {
        ps = GetComponent<ParticleSystem>();
    }

    void Update () {
		if(ps)
        {
            if(!ps.IsAlive())
            {
                Destroy(gameObject);
            }
        }

	}
}
