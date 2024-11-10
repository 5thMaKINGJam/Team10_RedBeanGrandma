using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] NaembiSpawner spawner;

    public void AddObj() {
        spawner.ShowNaembi();
    }
}
