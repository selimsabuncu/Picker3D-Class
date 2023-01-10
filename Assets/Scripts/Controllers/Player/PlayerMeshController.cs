using Data.ValueObjects;
using Sirenix.OdinInspector;
using System;
using UnityEngine;

namespace Controllers.Player
{
    public class PlayerMeshController : MonoBehaviour
    {
        #region Self Variables

        #region Serialized Variables

        [SerializeField] private PlayerManager manager;
        [SerializeField] private Renderer renderer;

        #endregion

        #region Private Variables

        [ShowInInspector] private ScaleData _data;


        #endregion

        #endregion
        internal void OnReset()
        {

        }
    }
}