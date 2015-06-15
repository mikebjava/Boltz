
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;


public class PlayerVisualController : MonoBehaviour
{

    private PlayerVitalsController vitals;

    void Start()
    {
        vitals = gameObject.GetComponent<PlayerVitalsController>() as PlayerVitalsController;
        vitals.Damaged += OnPlayerDamaged;
    }

    private void OnPlayerDamaged(object sender, DamagedEventArgs e)
    {
        // TODO: Add player visual effects for being damaged
    }

}

