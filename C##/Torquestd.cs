using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torquestd : MonoBehaviour
{
    // Start is called before the first frame update

    ArticulationBody artbb;

    public Vector3 Tvec;
    void Start()
    {
        artbb = GetComponent<ArticulationBody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            artbb.AddRelativeTorque(Tvec);
        }

        if (Input.GetKeyDown(KeyCode.Return))
        {
            artbb.AddTorque(Tvec);
        }
    }
}
