using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using System.Linq;
using Signals;

namespace Controller.UI
{
    public class UIPanelController : MonoBehaviour
    {

        #region Self Variables

        #region Serialized Variables

        [SerializeField] private List<Transform> layers = new List<Transform>();

        #endregion

        #endregion

        private void OnEnable()
        {
            SubscribeEvents();
        }

        private void SubscribeEvents()
        {
            CoreUISignals.Instance.onOpenPanel += OnOpenPanel;
            CoreUISignals.Instance.onClosePanel += OnClosePanel;
            CoreUISignals.Instance.onCloseAllPanels += OnCloseAllPanels;
        }

        private void UnSubscribeEvents()
        {
            CoreUISignals.Instance.onOpenPanel -= OnOpenPanel;
            CoreUISignals.Instance.onClosePanel -= OnClosePanel;
            CoreUISignals.Instance.onCloseAllPanels -= OnCloseAllPanels;
        }

        private void OnDisable()
        {
            UnSubscribeEvents();
        }

        [Button("OpenPanel")]
        private void OnOpenPanel(Enums.UIPanelTypes type, int layerPos)
        {
            Instantiate(Resources.Load<GameObject>($"Screens/{type}Panel"), layers[layerPos]);
        }

        [Button("ClosePanel")]
        private void OnClosePanel(int layerPos)
        {
            if (layers[layerPos].transform.childCount > 0)
            { Destroy(layers[layerPos].GetChild(0).gameObject); }
        }

        [Button("OnCloseAllPanel")]
        private void OnCloseAllPanels()
        {
            foreach (var t in layers.Where(t => t.childCount > 0))
            {
                { Destroy(t.GetChild(0).gameObject); }
            }
        }
    }
}