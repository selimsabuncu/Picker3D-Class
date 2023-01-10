using Data.ValueObjects;
using Data.UnityObjects;
using Sirenix.OdinInspector;
using UnityEngine;
using Controllers.Player;
using System;
using Signals;
using Keys;

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
        movementController.SetMovementData(_data.MovementData);
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
        InputSignals.Instance.onInputTaken += OnInputTaken;
        InputSignals.Instance.onInputReleased += OnInputReleased;
        InputSignals.Instance.onInputDragged += OnInputDragged;
        CoreGameSignals.Instance.onPlay += OnPlay;
        CoreGameSignals.Instance.onLevelSuccessful += OnLevelSuccessful;
        CoreGameSignals.Instance.onLevelFailed += OnLevelFailed;
        CoreGameSignals.Instance.onStageAreaReached += OnStageAreaReached;
        CoreGameSignals.Instance.onStageSuccessful += OnStageSuccessful;
        CoreGameSignals.Instance.onReset += OnReset;
    }

    private void UnSubscribeEvents()
    {
        InputSignals.Instance.onInputTaken -= OnInputTaken;
        InputSignals.Instance.onInputReleased -= OnInputReleased;
        InputSignals.Instance.onInputDragged -= OnInputDragged;
        CoreGameSignals.Instance.onPlay -= OnPlay;
        CoreGameSignals.Instance.onLevelSuccessful -= OnLevelSuccessful;
        CoreGameSignals.Instance.onLevelFailed -= OnLevelFailed;
        CoreGameSignals.Instance.onStageAreaReached -= OnStageAreaReached;
        CoreGameSignals.Instance.onStageSuccessful -= OnStageSuccessful;
        CoreGameSignals.Instance.onReset -= OnReset;
    }

    private void OnDisable()
    {
        UnSubscribeEvents();
    }

    private void OnPlay()
    {
        movementController.IsReadyToPlay(true);
    }

    private void OnInputTaken()
    {
        movementController.IsReadyToMove(true);
    }

    private void OnInputDragged(HorizontalInputParams inputParams)
    {
        movementController.UpdateInputValues(inputParams);
    }

    private void OnInputReleased()
    {
        movementController.IsReadyToMove(false);
    }

    private void OnLevelSuccessful()
    {
        movementController.IsReadyToPlay(false);
    }

    private void OnLevelFailed()
    {
        movementController.IsReadyToPlay(false);
    }
    private void OnStageSuccessful()
    {
        movementController.IsReadyToPlay(true);
    }

    private void OnStageAreaReached()
    {
        movementController.IsReadyToPlay(false);
    }

    private void OnReset()
    {
        movementController.OnReset();
        meshController.OnReset();
        physicsController.OnReset();
    }
}
