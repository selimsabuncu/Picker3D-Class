using UnityEngine;
using Enums;
using Signals;

public class GameManager : MonoBehaviour
{
    #region Self Variables

    #region Serialized Variables

    [SerializeField] private GameStates states;

    #endregion

    #endregion

    private void Awake()
    {
        Application.targetFrameRate = 60;
    }

    private void OnEnable()
    {
        SubscribeEvents();
    }

    private void SubscribeEvents()
    {
        CoreGameSignals.Instance.onChangeGameState += OnChangeGameState;
    }

    private void UnSubscribeEvents()
    {
        CoreGameSignals.Instance.onChangeGameState -= OnChangeGameState;
    }

    private void OnDisable()
    {
        UnSubscribeEvents();
    }

    //[Button("Change State")]
    private void OnChangeGameState(GameStates state)
    {
        states = state;
    }

}
