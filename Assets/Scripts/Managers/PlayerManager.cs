using Data.ValueObjects;
using Data.UnityObjects;
using Sirenix.OdinInspector;
using UnityEngine;
using Controllers.Player;
using System;

public class PlayerManager : MonoBehaviour
{
    #region Self Variables

    #region Serialized Variables

    [SerializeField] private PlayerMovementController movementController;
    [SerializeField] private PlayerPhysicsController physicsController;
    [SerializeField] private PlayerMeshController meshController;

    #endregion

    #region Private Variables

    [ShowInInspector] private PlayerData _data;

    #endregion

    #endregion


    private void Awake()
    {
        _data = GetPlayerData();
        SendDataToControllers();
    }

    private void SendDataToControllers()
    {
        movementController.GetMovementData(_data.MovementData);
        meshController.GetMeshData(_data.ScaleData);
    }

    private PlayerData GetPlayerData()
    {
        return Resources.Load<CD_Player>("Data/CD_Player").Data;
    }

    private void OnEnable()
    {
        SubscribeEvents();
    }

    private void SubscribeEvents()
    {
        CoreGameSignals.Instance.onReset += OnReset;
    }

    private void UnSubscribeEvents()
    {
        CoreGameSignals.Instance.onReset -= OnReset;
    }

    private void OnDisable()
    {
        UnSubscribeEvents();
    }

    private void OnReset()
    {
        movementController.OnReset();
        meshController.OnReset();
        physicsController.OnReset();
    }
}
