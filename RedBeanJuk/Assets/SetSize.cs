using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class SetSize : MonoBehaviour
{
    public Image[] items;

    void Start() {
        SetNativeSize();
    }

   private void SetNativeSize() {
        for (int i=0; i<items.Length; i++) {
            items[i].SetNativeSize();
        }
    }
}
