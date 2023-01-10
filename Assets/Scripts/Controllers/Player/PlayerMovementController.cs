using Data.ValueObjects;
using Sirenix.OdinInspector;
using System;
using UnityEngine;

namespace Controllers.Player
{
    public class PlayerMovementController : MonoBehaviour
    {
        #region Self Variables

        #region Serialized Variables

        [SerializeField] private PlayerManager manager;
        [SerializeField] private new Rigidbody rigidbody;
        [SerializeField] private new Collider collider;

        #endregion

        #region Private Variables

        [ShowInInspector] private ScaleData _data;

        #endregion

        #endregion

        internal void OnReset()
        {

        }

        internal void GetMovementData(MovementData movementData)
        {
            throw new NotImplementedException();
        }
    }
}