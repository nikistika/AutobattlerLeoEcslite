using UnityEngine;

namespace _Project.Scripts.ScriptableObjects.Characters
{
    public class CharacterConfig : ScriptableObject
    {
        [field: SerializeField, Min(0)] public int Heath { get; private set; }
        [field: SerializeField, Min(0)] public int DamageMin { get; private set; }
        [field: SerializeField, Min(0)] public int DamageMax { get; private set; }
        [field: SerializeField, Min(0)] public float CooldownAttackMin { get; private set; }
        [field: SerializeField, Min(0)] public float CooldownAttackMax { get; private set; }
    }
}