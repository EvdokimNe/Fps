using UnityEngine;

namespace FPS.Scripts.AI.ChangeLogic
{
    [CreateAssetMenu(fileName = "JumpWaweData", menuName = "JumpWaweData", order = 1)]
    public class JumpWaweData : ScriptableObject
    {
        [SerializeField] public WaweData[] WawesData;
    }
}