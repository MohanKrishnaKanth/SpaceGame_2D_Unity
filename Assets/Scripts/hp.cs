using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class hp : MonoBehaviour {
    GameObject canv;
    GameObject canv2;
    private void Start()
    {
        canv = GameObject.Find("Canvas2");
        canv2 = GameObject.Find("Canvas");
    }

    public void hpmenu()
    {
        canv.transform.Find("hpmenu").gameObject.SetActive(true);
        canv2.transform.Find("options").gameObject.SetActive(false);
    }
    public void closehpmenu()
    {
        canv.transform.Find("hpmenu").gameObject.SetActive(false);
        canv2.transform.Find("options").gameObject.SetActive(true);
    }
}
