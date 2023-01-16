using UnityEngine;
using EasyUI.PickerWheelUI;
using UnityEngine.UI;
using TMPro;
using Signals;
using Enums;

namespace Controllers.Wheel
{
    public class WheelController : MonoBehaviour
    {
        #region Self Variables

        [SerializeField] private Button _uiSpinButton;
        [SerializeField] private TextMeshProUGUI _uiSpinButtonText;

        [SerializeField] private PickerWheel _pickerWheel;

        #endregion

        private void Start()
        {
            _uiSpinButton.onClick.AddListener(() =>
           {
               _uiSpinButton.interactable = false;
               _uiSpinButtonText.text = "Spinning";

               _pickerWheel.OnSpinEnd(WheelPiece =>
               {
                   Debug.Log("Spin end: Label:" + WheelPiece.Label + " , Amount:" + WheelPiece.Amount);
                   PlayerPrefs.SetInt("spiningReward", WheelPiece.Amount);
                   CoreGameSignals.Instance.onLevelSuccessful?.Invoke();
               });

               _pickerWheel.Spin();
           });
        }
    }
}