using UnityEngine;
using System.Collections;

public class ForceField : MonoBehaviour {

    void OnTriggerEnter(Collider Co)
    {
        if (Co.tag == "character")
        {
            Co.GetComponent<BaseRobot>().setMoveTowardsPoint(Co.transform.position);
        }
    }

    void OnTriggerStay(Collider Co)
    {
        if (Co.tag == "character")
        {
            Co.GetComponent<BaseRobot>().setMoveTowardsPoint(new Vector3(Co.transform.position.x, 0, 0));
        }
    }

    void OnTriggerExit(Collider Co)
    {
        if (Co.tag == "character")
        {
            Co.GetComponent<BaseRobot>().setMoveTowardsPoint(Co.transform.position);
        }
    }
}
