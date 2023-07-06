using System;
using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Unity.VisualScripting;

public class ServerManager : MonoBehaviour
{
    private string a = "alperen";
    public static ServerManager Instance;

    private void Start()
    {
        if (Instance!=null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    public void IncreaseButton()
    {
        IncreaseCount();
    }
    
    public void SendPost()
    {
        GetCount();
    }

    private async Task IncreaseCount()
    {
        HttpClient xxx = new HttpClient();
        var serializeProduct = JsonConvert.SerializeObject(a);
        StringContent strcont = new StringContent(serializeProduct, Encoding.UTF8, "application/json");
        xxx.PostAsync("https://localhost:7159/api/Test/IncreaseCount", strcont);
    }

    
    public async Task  GetCount()
    {
        HttpClient xxx = new HttpClient();

        var result = await xxx.GetAsync("https://localhost:7159/api/Test");
        var responseBody = await result.Content.ReadAsStringAsync().ConfigureAwait(false);
        //DataInfo info = JsonUtility.FromJson<DataInfo>(responseBody);
        
        //CanvasManager.Instance.UpdateTxt(info.data);
        CanvasManager.Instance.UpdateTxt(responseBody);

        if (!result.IsSuccessStatusCode)
        {
            Debug.Log(result.StatusCode);
        }
        else
        {
            Debug.Log("Form upload complete!");
        }

    }
}

public class DataInfo
{
    public string data;
    public string success;
    public string message;
}
