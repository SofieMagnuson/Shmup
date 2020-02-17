using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AbilityCoolDown : MonoBehaviour
{
    public string abilityButtonName_ = "Fire1";
    public Image darkMask_;
    public TextMeshProUGUI cooldownText_;

    [SerializeField] private Ability ability_;
    [SerializeField] private GameObject targetObject_;
    private Image buttonImage_;
    private AudioSource abilityAudio_;
    private float cooldownDuration_;
    private float nextReadyTime_;
    private float cooldownTimeLeft_;

    
    // Start is called before the first frame update
    void Start()
    {
        Initialize(ability_, targetObject_);
    }

    public void Initialize(Ability ability_in, GameObject target_object_in)
    {
        ability_ = ability_in;
        buttonImage_ = GetComponent<Image>();
        abilityAudio_ = GetComponent<AudioSource>();
        buttonImage_.sprite = ability_.sprite_;
        darkMask_.sprite = ability_.sprite_;
        ability_.Initialize(target_object_in);
        AbilityReady();
    }

    private void AbilityReady()
    {
        cooldownText_.enabled = false;
        darkMask_.enabled = false; 
    }

    private void Cooldown()
    {
        cooldownTimeLeft_ -= Time.deltaTime;
        cooldownText_.text = Mathf.Round(cooldownTimeLeft_).ToString();
        darkMask_.fillAmount = (cooldownTimeLeft_ / cooldownDuration_);

    }

    private void ButtonTriggered()
    {
        nextReadyTime_ = Time.time + cooldownDuration_;
        cooldownTimeLeft_ = cooldownDuration_;
        cooldownText_.enabled = true;
        darkMask_.enabled = true;

        abilityAudio_.clip = ability_.sound_;
        abilityAudio_.Play();
        ability_.TriggerAbility();
    }

    // Update is called once per frame
    void Update()
    {
        bool cooldownIsComplete_ = (Time.time > nextReadyTime_);
        if(cooldownIsComplete_)
        {
            AbilityReady();
            if(Input.GetButtonDown (abilityButtonName_))
            {
                ButtonTriggered();
            }
            else
            {
                Cooldown();
            }
        }
    }


}
