using UnityEngine;

namespace GamePrototype.Scripts.StaticData
{
    [CreateAssetMenu(menuName = "StaticData/Player/PlayerConfig", fileName = "new PlayerConfig", order = 0)]
    public class PlayerConfig : ScriptableObject
    {
        public PlayerTypeId PlayerTypeId;
        public GameObject Prefab;
        public float ShootForce;
    }


    public enum PlayerTypeId
    {
        Default
    }
}