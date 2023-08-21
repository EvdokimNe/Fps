using System;

namespace FPS.Scripts.AI.ChangeLogic
{
    [Serializable]
    public class WaweData
    {
         public float MinSize = 2f;
         public float MaxSize = 5f;
         public float Time = 1f;
         public float TimeRevert = 1f;
         public float Damage = 10f;
         public float TimeAfterWave = 0f;
         public InterpolationType Type = InterpolationType.Linear;
         public InterpolationType TypeRevert = InterpolationType.Linear;
         public bool HasRevert;
    }
}