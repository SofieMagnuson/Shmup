using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Ability : ScriptableObject
{
    public string name_ = "New ability";
    public Sprite sprite_;
    public AudioClip sound_;
    public float coolDown_ = 1f;

    public abstract void Initialize(GameObject obj_in_);
    public abstract void TriggerAbility();
}
