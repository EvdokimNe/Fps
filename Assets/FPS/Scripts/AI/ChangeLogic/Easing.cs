using System;

namespace FPS.Scripts.AI.ChangeLogic
{
    public enum InterpolationType
    {
        Linear,
        InQuad,
        OutQuad,
        InOutQuad,
        InCubic,
        OutCubic,
        InOutCubic,
        InQuart,
        OutQuart,
        InOutQuart,
        InQuint,
        OutQuint,
        InOutQuint,
        InSine,
        OutSine,
        InOutSine,
        InExpo,
        OutExpo,
        InOutExpo,
        InCirc,
        OutCirc,
        InOutCirc,
        InElastic,
        OutElastic,
        InOutElastic,
        InBack,
        OutBack,
        InOutBack,
        InBounce,
        OutBounce,
        InOutBounce
    }


    public static class Easing
    {
        public static float GetX(InterpolationType type, float x)
        {
            switch (type)
            {
                case InterpolationType.Linear:
                    return Linear(x);
                case InterpolationType.InQuad:
                    return InQuad(x);
                case InterpolationType.OutQuad:
                    return OutQuad(x);
                case InterpolationType.InOutQuad:
                    return InOutQuad(x);
                case InterpolationType.InCubic:
                    return InCubic(x);
                case InterpolationType.OutCubic:
                    return OutCubic(x);
                case InterpolationType.InOutCubic:
                    return InOutCubic(x);
                case InterpolationType.InQuart:
                    return InQuart(x);
                case InterpolationType.OutQuart:
                    return OutQuart(x);
                case InterpolationType.InOutQuart:
                    return InOutQuart(x);
                case InterpolationType.InQuint:
                    return InQuint(x);
                case InterpolationType.OutQuint:
                    return OutQuint(x);
                case InterpolationType.InOutQuint:
                    return InOutQuint(x);
                case InterpolationType.InSine:
                    return InSine(x);
                case InterpolationType.OutSine:
                    return OutSine(x);
                case InterpolationType.InOutSine:
                    return InOutSine(x);
                case InterpolationType.InExpo:
                    return InExpo(x);
                case InterpolationType.OutExpo:
                    return OutExpo(x);
                case InterpolationType.InOutExpo:
                    return InOutExpo(x);
                case InterpolationType.InCirc:
                    return InCirc(x);
                case InterpolationType.OutCirc:
                    return OutCirc(x);
                case InterpolationType.InOutCirc:
                    return InOutCirc(x);
                case InterpolationType.InElastic:
                    return InElastic(x);
                case InterpolationType.OutElastic:
                    return OutElastic(x);
                case InterpolationType.InOutElastic:
                    return InOutElastic(x);
                case InterpolationType.InBack:
                    return InBack(x);
                case InterpolationType.OutBack:
                    return OutBack(x);
                case InterpolationType.InOutBack:
                    return InOutBack(x);
                case InterpolationType.InBounce:
                    return InBounce(x);
                case InterpolationType.OutBounce:
                    return OutBounce(x);
                case InterpolationType.InOutBounce:
                    return InOutBounce(x);
                default:
                    throw new ArgumentException("Invalid interpolation type", nameof(type));
            }
        }

        public static float Linear(float t) => t;

        public static float InQuad(float t) => t * t;
        public static float OutQuad(float t) => 1 - InQuad(1 - t);

        public static float InOutQuad(float t)
        {
            if (t < 0.5) return InQuad(t * 2) / 2;
            return 1 - InQuad((1 - t) * 2) / 2;
        }

        public static float InCubic(float t) => t * t * t;
        public static float OutCubic(float t) => 1 - InCubic(1 - t);

        public static float InOutCubic(float t)
        {
            if (t < 0.5) return InCubic(t * 2) / 2;
            return 1 - InCubic((1 - t) * 2) / 2;
        }

        public static float InQuart(float t) => t * t * t * t;
        public static float OutQuart(float t) => 1 - InQuart(1 - t);

        public static float InOutQuart(float t)
        {
            if (t < 0.5) return InQuart(t * 2) / 2;
            return 1 - InQuart((1 - t) * 2) / 2;
        }

        public static float InQuint(float t) => t * t * t * t * t;
        public static float OutQuint(float t) => 1 - InQuint(1 - t);

        public static float InOutQuint(float t)
        {
            if (t < 0.5) return InQuint(t * 2) / 2;
            return 1 - InQuint((1 - t) * 2) / 2;
        }

        public static float InSine(float t) => (float)-Math.Cos(t * Math.PI / 2);
        public static float OutSine(float t) => (float)Math.Sin(t * Math.PI / 2);
        public static float InOutSine(float t) => (float)(Math.Cos(t * Math.PI) - 1) / -2;

        public static float InExpo(float t) => (float)Math.Pow(2, 10 * (t - 1));
        public static float OutExpo(float t) => 1 - InExpo(1 - t);

        public static float InOutExpo(float t)
        {
            if (t < 0.5) return InExpo(t * 2) / 2;
            return 1 - InExpo((1 - t) * 2) / 2;
        }

        public static float InCirc(float t) => -((float)Math.Sqrt(1 - t * t) - 1);
        public static float OutCirc(float t) => 1 - InCirc(1 - t);

        public static float InOutCirc(float t)
        {
            if (t < 0.5) return InCirc(t * 2) / 2;
            return 1 - InCirc((1 - t) * 2) / 2;
        }

        public static float InElastic(float t) => 1 - OutElastic(1 - t);

        public static float OutElastic(float t)
        {
            float p = 0.3f;
            return (float)Math.Pow(2, -10 * t) * (float)Math.Sin((t - p / 4) * (2 * Math.PI) / p) + 1;
        }

        public static float InOutElastic(float t)
        {
            if (t < 0.5) return InElastic(t * 2) / 2;
            return 1 - InElastic((1 - t) * 2) / 2;
        }

        public static float InBack(float t)
        {
            float s = 1.70158f;
            return t * t * ((s + 1) * t - s);
        }

        public static float OutBack(float t) => 1 - InBack(1 - t);

        public static float InOutBack(float t)
        {
            if (t < 0.5) return InBack(t * 2) / 2;
            return 1 - InBack((1 - t) * 2) / 2;
        }

        public static float InBounce(float t) => 1 - OutBounce(1 - t);

        public static float OutBounce(float t)
        {
            float div = 2.75f;
            float mult = 7.5625f;

            if (t < 1 / div)
            {
                return mult * t * t;
            }
            else if (t < 2 / div)
            {
                t -= 1.5f / div;
                return mult * t * t + 0.75f;
            }
            else if (t < 2.5 / div)
            {
                t -= 2.25f / div;
                return mult * t * t + 0.9375f;
            }
            else
            {
                t -= 2.625f / div;
                return mult * t * t + 0.984375f;
            }
        }

        public static float InOutBounce(float t)
        {
            if (t < 0.5) return InBounce(t * 2) / 2;
            return 1 - InBounce((1 - t) * 2) / 2;
        }
    }
}