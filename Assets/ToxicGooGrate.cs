using UnityEngine;
using System.Collections;

public class ToxicGooGrate : MonoBehaviour
{
    #region EditorVariables
    public int DripSpeed = 3000;
    public Transform[] DripLocations;
    public GameObject[] DropletPrefabs;
    public bool VariantDropletSize = true;
    public float LowRangeSize = 0.7f;
    public float HighRangeSize = 1.25f;
    #endregion

    private Cooldown dripCD;

    void Start()
    {
        dripCD = new Cooldown(DripSpeed);
    }

    void FixedUpdate()
    {
        dripCD.CooldownTime = DripSpeed;

        if (dripCD.Available())
        {
            if (DripLocations != null && DripLocations.Length > 0 && DropletPrefabs != null && DropletPrefabs.Length > 0)
            {
                GameObject randomDroplet = DropletPrefabs[UnityEngine.Random.Range(0, DropletPrefabs.Length)];
                Transform randomLocation = DripLocations[UnityEngine.Random.Range(0, DripLocations.Length)];

                GameObject droplet = Instantiate(randomDroplet, randomLocation.position, randomLocation.rotation) as GameObject;
                droplet.transform.localScale *= UnityEngine.Random.Range(LowRangeSize, HighRangeSize);
            }
        }
    }


}
