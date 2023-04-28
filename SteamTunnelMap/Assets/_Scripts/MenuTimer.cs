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
    phase3,
    wean8,
    wean9,
    SteamTunnels,
    Skibo,
    NSH
}
public class MenuTimer : MonoBehaviour
{
    public GameObject Phase0 = null;
    public GameObject Phase1 = null;
    public GameObject Phase2 = null;
    public GameObject Phase3 = null;
    public GameObject Images = null;
    public List<GameObject> Wean8Images = new List<GameObject>();
    public List<GameObject> Wean9Images = new List<GameObject>();
    public List<GameObject> SteamTunnelsImages = new List<GameObject>();
    public List<GameObject> SkiboImages = new List<GameObject>();
    public List<GameObject> NSHImages = new List<GameObject>();
    
    private MyEnum phases = MyEnum.Menu;
    private MyEnum lastPhase = MyEnum.Menu;
    
    private int Ween8ImageLen = 0;
    private int Ween9ImageLen = 0;
    private int NSHImageLen = 0;
    private int SteamTunnelsImageLen = 0;
    private int SkiboImageLen = 0;
    private int CurrIndex = 0;
    IEnumerator EnableNextPhase()
    {
        while (true)
        {
            yield return new WaitForSeconds(10.0f);
            switch (phases)
            {
                case MyEnum.Menu:
                    lastPhase = phases;
                    phases = MyEnum.phase1;
                    Phase0.SetActive(false);
                    Phase1.SetActive(true);
                    break;
                case MyEnum.phase1:
                    //mall side
                    phases = MyEnum.wean8;
                    Phase1.SetActive(false);
                    switch (lastPhase)
                    {
                        case MyEnum.wean8:
                            Images.SetActive(true);
                            Wean9Images[CurrIndex].SetActive(true);
                            CurrIndex++;
                            phases = MyEnum.wean9;
                            break;
                        case MyEnum.wean9:
                            Images.SetActive(false);
                            phases = MyEnum.phase2;
                            break;
                        default:
                            Phase1.SetActive(false);
                            Images.SetActive(true);
                            phases = MyEnum.wean8;
                            break;
                    }
                    lastPhase = phases;
                    break;
                case MyEnum.phase2:
                    //NSH
                    lastPhase = phases;
                    phases = MyEnum.NSH;
                    Phase2.SetActive(false);
                    Images.SetActive(true);
                    NSHImages[CurrIndex].SetActive(true);
                    CurrIndex++;
                    break;
                case MyEnum.phase3:
                    //CFA
                    phases = MyEnum.SteamTunnels;
                    Phase3.SetActive(false);
                    //Phase0.SetActive(true);
                    Images.SetActive(true);
                    switch (lastPhase)
                    {
                        case MyEnum.NSH:
                            Images.SetActive(true);
                            SteamTunnelsImages[CurrIndex].SetActive(true);
                            CurrIndex++;
                            phases = MyEnum.SteamTunnels;
                            break;
                        case MyEnum.SteamTunnels:
                            Images.SetActive(true);
                            SkiboImages[CurrIndex].SetActive(true);
                            CurrIndex++;
                            phases = MyEnum.Skibo;
                            break;
                    }
                    lastPhase = phases;

                    break;
                case MyEnum.wean8:
                    if (CurrIndex < Ween8ImageLen)
                    {
                        Wean8Images[CurrIndex].SetActive(true);
                        if (CurrIndex > 0)
                        {
                            Wean8Images[CurrIndex - 1].SetActive(false);
                        }
                        CurrIndex++;
                    }
                    else
                    {
                        Wean8Images[CurrIndex - 1].SetActive(false);
                        CurrIndex = 0;
                        lastPhase = phases;
                        phases = MyEnum.phase1;
                        Images.SetActive(false);
                        Phase1.SetActive(true);
                    }
                    break;
                case MyEnum.wean9:
                    if (CurrIndex < Ween9ImageLen)
                    {
                        Wean9Images[CurrIndex].SetActive(true);
                        if (CurrIndex > 0)
                        {
                            Wean9Images[CurrIndex - 1].SetActive(false);
                        }
                        CurrIndex++;
                    }
                    else
                    {
                        Wean9Images[CurrIndex - 1].SetActive(false);
                        CurrIndex = 0;
                        lastPhase = phases;
                        phases = MyEnum.phase2;
                        Images.SetActive(false);
                        Phase2.SetActive(true);
                    }
                    break;
                case MyEnum.SteamTunnels:
                    if (CurrIndex < SteamTunnelsImageLen)
                    {
                        SteamTunnelsImages[CurrIndex].SetActive(true);
                        if (CurrIndex > 0)
                        {
                            SteamTunnelsImages[CurrIndex - 1].SetActive(false);
                        }
                        CurrIndex++;
                    }
                    else
                    {
                        SteamTunnelsImages[CurrIndex - 1].SetActive(false);
                        CurrIndex = 0;
                        lastPhase = phases;
                        phases = MyEnum.phase3;
                    }
                    break;
                case MyEnum.Skibo:
                    if (CurrIndex < SkiboImageLen)
                    {
                        SkiboImages[CurrIndex].SetActive(true);
                        if (CurrIndex > 0)
                        {
                            SkiboImages[CurrIndex - 1].SetActive(false);
                        }
                        CurrIndex++;
                    }
                    else
                    {
                        SkiboImages[CurrIndex - 1].SetActive(false);
                        CurrIndex = 0;
                        lastPhase = phases;
                        phases = MyEnum.Menu;
                        Images.SetActive(false);
                        Phase0.SetActive(true);
                    }
                    break;
                case MyEnum.NSH:
                    if (CurrIndex < NSHImageLen)
                    {
                        NSHImages[CurrIndex].SetActive(true);
                        if (CurrIndex > 0)
                        {
                            NSHImages[CurrIndex - 1].SetActive(false);
                        }
                        CurrIndex++;
                    }
                    else
                    {
                        NSHImages[CurrIndex - 1].SetActive(false);
                        CurrIndex = 0;
                        lastPhase = phases;
                        phases = MyEnum.phase3;
                        Images.SetActive(false);
                        Phase3.SetActive(true);
                    }
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
    void Start()
    {
        Ween8ImageLen = Wean8Images.Count;
        Ween9ImageLen = Wean9Images.Count;
        SteamTunnelsImageLen = SteamTunnelsImages.Count;
        SkiboImageLen = SkiboImages.Count;
        NSHImageLen = NSHImages.Count;
        StartCoroutine(EnableNextPhase());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
