using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangedSwordController : MonoBehaviour
{
    private GameObject sword;
    private ChangedDray dray;

    void Start()
    {
        sword = transform.Find("Sword").gameObject;
        dray = transform.parent.GetComponent<ChangedDray>();

        // Deactivate the sword
        sword.SetActive(false);
    }

    void Update()
    {
        transform.rotation = Quaternion.Euler(0, 0, 90 * dray.facing);
        sword.SetActive(dray.mode == ChangedDray.eMode.attack);
    }
}
