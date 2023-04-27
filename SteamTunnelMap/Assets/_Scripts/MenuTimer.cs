using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;




enum MyEnum
{
    Menu,
    phase1,
    phase2,
    phase3
}
public class MenuTimer : MonoBehaviour
{
    public GameObject Phase0 = null;
    public GameObject Phase1 = null;
    public GameObject Phase2 = null;
    public GameObject Phase3 = null;
    private MyEnum phases = MyEnum.Menu;
    
    IEnumerator EnableNextPhase()
    {
        while (true)
        {
            yield return new WaitForSeconds(10.0f);
            switch (phases)
            {
                case MyEnum.Menu:
                    phases = MyEnum.phase1;
                    Phase0.SetActive(false);
                    Phase1.SetActive(true);
                    break;
                case MyEnum.phase1:
                    phases = MyEnum.phase2;
                    Phase1.SetActive(false);
                    Phase2.SetActive(true);
                    break;
                case MyEnum.phase2:
                    phases = MyEnum.phase3;
                    Phase2.SetActive(false);
                    Phase3.SetActive(true);
                    break;
                case MyEnum.phase3:
                    phases = MyEnum.Menu;
                    Phase3.SetActive(false);
                    Phase0.SetActive(true);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
    void Start()
    {
        StartCoroutine(EnableNextPhase());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
