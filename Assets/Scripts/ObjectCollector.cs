using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectCollector : MonoBehaviour
{
   private void OnTriggerEnter(Collider other) {

        string tag = other.tag;

        if (tag.Equals("GoodObjects"))
        {
            Debug.Log("good");
        }

        if (tag.Equals("BadObjects"))
        {
            Debug.Log("bad");
        }
    }




}
