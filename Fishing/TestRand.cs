using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestRand : MonoBehaviour
{
    public GameObject[] Fishes;
    public Transform spawnPos;
    void Start() {
        int fishID=Random.Range(0,Fishes.Length);
        var test=Instantiate(Fishes[fishID]) as GameObject;
        test.AddComponent<Fish>();
    }
}
