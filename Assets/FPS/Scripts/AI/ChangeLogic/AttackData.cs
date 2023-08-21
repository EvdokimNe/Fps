using UnityEngine;

namespace FPS.Scripts.AI.ChangeLogic
{
    [CreateAssetMenu(fileName = "AttackData", menuName = "AttackData", order = 1)]
    public class AttackData : ScriptableObject
    {
        public string TriggerName = "Jump";
        public float WaitAfterStartAnim = 1f;
        public JumpWaweData WaweData;
        public float WaitAfterStartWaves = 5f;
    }
}