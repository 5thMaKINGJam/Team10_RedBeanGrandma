using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotStateSetter : MonoBehaviour
{
    private void SetActiveFalse()
    {
        foreach (Transform child in this.transform)
        { 
            child.gameObject.SetActive(false);
        }
    }

    public void SetBoilingState(int state)
    {
        SetActiveFalse();
        int idx = 0;
        if (state == 0) //none
        {
            idx = 0;
        }
        else if (state == 1)//mid
        {
            idx = Random.Range(1, 4);
        }
        else if (state == 2)//success
        {
            idx = 4;
        }
        else if (state == 3)//fail
        {
            idx = 5;
        }

        this.transform.GetChild(idx).gameObject.SetActive(true);
    }
}
