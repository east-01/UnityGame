using FishNet.Object;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FirstObjectNotifier : NetworkBehaviour {

    public static event Action<GameObject> OnFirstObjectSpawned;

    public override void OnStartClient() {
        base.OnStartClient();
        if (base.IsOwner) {
            NetworkObject nob = base.LocalConnection.FirstObject;
            if (nob == base.NetworkObject) {
                OnFirstObjectSpawned?.Invoke(gameObject);
            }
        }
    }

}
