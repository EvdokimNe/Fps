using System.Collections;
using FPS.Scripts.AI.ChangeLogic;
using UnityEngine;

namespace FPS.Scripts.Gameplay
{
    public class WaweController : MonoBehaviour
    {
        [SerializeField] public DonutObject _donutObject;
        [SerializeField] public Transform _parent;

        public void StartCor(WaweData[] wawes)
        {
            StartCoroutine(StartWawes(wawes));
        }

        private IEnumerator StartWawes(WaweData[] wawes)
        {
            foreach (var wawe in wawes)
            {
                StartCoroutine(ControlWawe(wawe));

                if (wawe.TimeAfterWave > 0)
                {
                    yield return new WaitForSeconds(wawe.TimeAfterWave);
                }
            }
        }

        private IEnumerator ControlWawe(WaweData waweData)
        {
            var donutObject = Instantiate(_donutObject, _parent.transform);

            var y = donutObject.transform.localScale.y;
            donutObject.transform.localScale = new Vector3(waweData.MinSize, y, waweData.MaxSize);
            donutObject.gameObject.SetActive(true);

            donutObject.SetDamage(waweData.Damage);

            var time = 0f;

            while (time < 1)
            {
                var size = Mathf.Lerp(waweData.MinSize, waweData.MaxSize, Easing.GetX(waweData.Type, time));
                donutObject.transform.localScale = new Vector3(size, y, size);
                time += Time.deltaTime / waweData.Time;
                yield return null;
            }

            if (waweData.HasRevert)
            {
                donutObject.SetCanDamage(true);
                
                time = 0;

                while (time < 1)
                {
                    var size = Mathf.Lerp(waweData.MaxSize, waweData.MinSize, Easing.GetX(waweData.TypeRevert, time));
                    donutObject.transform.localScale = new Vector3(size, y, size);
                    time += Time.deltaTime / waweData.TimeRevert;
                    yield return null;
                }
            }


            donutObject.gameObject.SetActive(false);
            Destroy(donutObject.gameObject);
        }
    }
}