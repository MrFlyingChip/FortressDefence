using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetActiveFalseInTime : MonoBehaviour {

    public float seconds;

    private void OnEnable()
    {
        StartCoroutine(Timer());
    }

    IEnumerator Timer()
    {
        yield return new WaitForSeconds(seconds);
        gameObject.SetActive(false);
    }
}
