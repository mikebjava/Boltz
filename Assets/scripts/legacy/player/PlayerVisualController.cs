using UnityEngine;
using Assets.scripts;
using System;
using System.Collections;
//using UnityStandardAssets.ImageEffects;

public class PlayerVisualController : MonoBehaviour
{
    #region Editor Variables
    public Color noneElementalColor = Color.white;
    public Color waterElementalColor = Color.blue;
    public Color fireElementalColor = Color.red;
    public Color earthElementalColor = Color.green;
    public Color windElementalColor = new Color(0.854f, 0.639f, 1f);
    public bool damageIndicator = true;
    public float damageIndicatorStrength = 50f;
    #endregion

    private PlayerVitalsController vitalsController;
    private PlayerElementalController elementalController;
    private Camera cam;
    //private VignetteAndChromaticAberration vig;
    private SpriteRenderer sRenderer;
    private ParticleSystem motionPS;
    private ParticleSystem injuryPS;
    private Light glow;

    void Start()
    {
        vitalsController = GameController.Instance().playerBallInstance.GetComponent<PlayerVitalsController>() as PlayerVitalsController;
        elementalController = GameController.Instance().playerBallInstance.GetComponent<PlayerElementalController>() as PlayerElementalController;
        vitalsController.PlayerHurtEvent += new EventHandler(OnPlayerHurt);
        elementalController.ElementChangedEvent += new EventHandler(OnElementChanged);
        cam = GameController.Instance().playerInstance.transform.FindChild("Main Camera").gameObject.GetComponent<Camera>();
        //vig = cam.GetComponent<VignetteAndChromaticAberration>() as VignetteAndChromaticAberration;

        if (sRenderer == null)
        {
            sRenderer = GetComponent<SpriteRenderer>();
        }

        if (glow == null)
        {
            glow = GetComponentInChildren<Light>();
        }

        if (injuryPS == null)
        {
            injuryPS = gameObject.transform.FindChild("Injury FX").GetComponent<ParticleSystem>();
        }

        if (motionPS == null)
        {
            motionPS = gameObject.transform.FindChild("Elemental FX").GetComponent<ParticleSystem>();
        }
    }

    void Update()
    {
        //vig.chromaticAberration = Mathf.Lerp(vig.chromaticAberration, 0.2f, 0.1f);
    }

    public void OnPlayerHurt(object o, EventArgs e)
    {
        if (damageIndicator)
        {
            //vig.chromaticAberration = damageIndicatorStrength;
            injuryPS.Emit(30);
        }
    }

    public void OnElementChanged(object o, EventArgs e)
    {
        ColorizeElementalState();
    }

    private void ColorizeElementalState()
    {
        switch (elementalController.CurrentElement)
        {
            case ElementalType.None:
                sRenderer.material.color = noneElementalColor;
                motionPS.startColor = noneElementalColor;
                glow.color = noneElementalColor;
                break;
            case ElementalType.Fire:
                sRenderer.material.color = fireElementalColor;
                motionPS.startColor = fireElementalColor;
                glow.color = fireElementalColor;
                break;
            case ElementalType.Wind:
                sRenderer.material.color = windElementalColor;
                motionPS.startColor = windElementalColor;
                glow.color = windElementalColor;
                break;
            case ElementalType.Earth:
                sRenderer.material.color = earthElementalColor;
                motionPS.startColor = earthElementalColor;
                glow.color = earthElementalColor;
                break;
            case ElementalType.Water:
                sRenderer.material.color = waterElementalColor;
                motionPS.startColor = waterElementalColor;
                glow.color = waterElementalColor;
                break;
            default:
                sRenderer.material.color = Color.black;
                motionPS.startColor = Color.black;
                glow.color = Color.black;
                break;
        }
    }
}
