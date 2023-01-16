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

        public int CoinSpinned;

        #endregion

        private void Start()
        {
            _uiSpinButton.onClick.AddListener(() =>
           {
               _uiSpinButton.interactable = false;
               _uiSpinButtonText.text = "Spinning";

               _pickerWheel.OnSpinStart(() =>
              {
                  Debug.Log("Spin Started");
              });

               _pickerWheel.OnSpinEnd(WheelPiece =>
               {
                   Debug.Log("Spin end: Label:" + WheelPiece.Label + " , Amount:" + WheelPiece.Amount);
                   CoinSpinned = WheelPiece.Amount;
                   CoreUISignals.Instance.onOpenPanel?.Invoke(UIPanelTypes.Win, 2);
               });

               _pickerWheel.Spin();
           });
        }
    }
}