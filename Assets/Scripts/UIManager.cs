using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;
public class UIManager : MonoBehaviour
{
    [Header(" Panels ")]
    [SerializeField] private GameObject connectionPannel;
    [SerializeField] private GameObject waitingPannel;
    [SerializeField] private GameObject gamePannel;
    void Start()
    {
        ShowConnectionPannel();
    }
    void Update()
    {
    }
    private void ShowConnectionPannel()
    {
        connectionPannel.SetActive(true);
        waitingPannel.SetActive(false);
        gameObject.SetActive(false);
    }
    private void ShowWaitingPannel()
    {
        connectionPannel.SetActive(false);
        waitingPannel.SetActive(true);
        gameObject.SetActive(false);
    }
    private void ShowGamePannel()
    {
        connectionPannel.SetActive(false);
        waitingPannel.SetActive(false);
        gameObject.SetActive(true);
    }
    public void HostButtonCallback()
    {
        NetworkManager.Singleton.StartHost();
        ShowWaitingPannel();
    }
    public void ClientButtonCallback()
    {
        NetworkManager.Singleton.StartClient();
        ShowWaitingPannel();
    }
}

