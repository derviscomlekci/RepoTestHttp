using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CanvasManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _countTxt;
    public static CanvasManager Instance;

    private void Start()
    {
        if (Instance!=null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }


    public void UpdateTxt(string count)
    {
        _countTxt.text = count;
    }
}
