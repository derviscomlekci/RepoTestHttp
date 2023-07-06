using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Button _increaseButton;
    private int count = 0;
    private void Start()
    {
        _increaseButton.onClick.AddListener(UpdateText);
        ServerManager.Instance.SendPost();
    }

    private void UpdateText()
    {
        //CanvasManager.Instance.UpdateTxt(++count);
    }
}
