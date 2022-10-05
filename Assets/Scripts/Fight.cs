using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fight : MonoBehaviour
{
    #region Variables
    [SerializeField] private GameObject turnManager; //objeto que contiene el script para simular lucha por turnos
    #endregion

    #region Methods
    /// <summary>
    /// activa el objeto que tiene el script para la lucha.
    /// Desactiva este objeto
    /// </summary>
    public void goToFight() { 
        turnManager.SetActive(true);
        this.gameObject.SetActive(false);
    }
    #endregion
}
