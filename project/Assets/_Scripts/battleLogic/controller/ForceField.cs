using UnityEngine;
using System.Collections;

public class ForceField : MonoBehaviour {

    void OnTriggerEnter(Collider Co)
    {
        if (Co.tag == "character")
        {
            Co.GetComponent<BaseRobot>().setMoveTowardsPoint(new Vector3(Co.transform.position.x, 0, Co.transform.position.z /Mathf.Abs(Co.transform.position.z)*120));
        }
    }

    //void OnTriggerStay(Collider Co)
    //{
    //    if (Co.tag == "character")
    //    {
    //        Co.GetComponent<BaseRobot>().setMoveTowardsPoint(new Vector3(Co.transform.position.x, 0, Co.transform.position.z / Mathf.Abs(Co.transform.position.z) * 110));
    //    }
    //}

    //void OnTriggerExit(Collider Co)
    //{
    //    if (Co.tag == "character")
    //    {
    //        Co.GetComponent<BaseRobot>().setMoveTowardsPoint(Co.transform.position);
    //    }
    //}
}
