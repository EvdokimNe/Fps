using System.Collections;
using DG.Tweening;
using FPS.Scripts.AI.ChangeLogic;
using FPS.Scripts.Gameplay;
using Unity.FPS.AI;
using Unity.FPS.Game;
using UnityEngine;

namespace FPS.Scripts.Game.ChangeLogic
{
    public class StageTurretController : MonoBehaviour
    {
        [SerializeField] private Health _health;
        [SerializeField] private WeaponController _weaponController;
        [SerializeField] private EnemyTurret _enemyTurret;

        [SerializeField] private GameObject _baseHitBox;
        [SerializeField] private GameObject _gunHitBox;
        [SerializeField] private GameObject _gun;
        [SerializeField] private ParticleSystem _particleSystem;
        [SerializeField] private MeshRenderer _gunRenderer;

        [SerializeField] private Material _defaultMaterial;
        [SerializeField] private Material _redMaterial;

        [SerializeField] private Transform _eyePos;

        [SerializeField] private float _changeStageHpPercent;

        [SerializeField] private WaweController _waweController;

        [SerializeField] private JumpWaweData _jumpWaweData;

        [SerializeField] private Animator _animator;

        [SerializeField] private AttackData[] _attackDatas;

        [SerializeField] private int MinAttack = 2;
        [SerializeField] private int MaxAttack = 5;

        [SerializeField] private float DamageTime = 1f;

        [SerializeField] private SkinnedMeshRenderer _skinnedMeshRenderer;
        [SerializeField] private Material _defaultBodyMaterial;
        [SerializeField] private Material _redBodyMaterial;

        [SerializeField] private GameObject _wals;
        [SerializeField] private bool _needDownWals;
        [SerializeField] private float _walsDuration = 1f;
        [SerializeField] private float _walsY = -10f;
        [SerializeField] private Ease _ease = Ease.Linear;
        
        
        

        private Coroutine _coroutine;

        private bool _stateChanged;

        private void Start()
        {
            if (_health != null)
            {
                _health.OnDamaged += OnDamaged;
                _health.OnDie += OnDie;
            }

            _weaponController.StartReload = StartReload;
            _weaponController.EndReload = EndReload;

            _gunHitBox.gameObject.SetActive(false);
        }

        private void OnDie()
        {
            StopCoroutine(_coroutine);
        }

        private void EndReload()
        {
            _gunHitBox.gameObject.SetActive(false);
            _gunRenderer.material = _defaultMaterial;
        }

        private void StartReload()
        {
            _gunHitBox.gameObject.SetActive(true);
            _gunRenderer.material = _redMaterial;
        }

        private void OnDamaged(float v, GameObject arg1)
        {
            if (_health.GetRatio() < _changeStageHpPercent && !_stateChanged)
            {
                _stateChanged = true;
                _health.OnDamaged -= OnDamaged;
                _enemyTurret.SetWaitState();
                _gunHitBox.gameObject.SetActive(false);
                StartCoroutine(DestroyGun());
            }
        }

        private IEnumerator GenerateWawes()
        {
            var attackCount = Random.Range(MinAttack, MaxAttack + 1);

            for (int i = 0; i < attackCount; i++)
            {
                var randomData = _attackDatas[Random.Range(0, _attackDatas.Length)];

                //_enemyTurret.NeedLook = false;
                _animator.SetTrigger(randomData.TriggerName);
                
                yield return new WaitForSeconds(randomData.WaitAfterStartAnim);
                
                _enemyTurret.NeedLook = true;
                
                _waweController.StartCor(_jumpWaweData.WawesData);
                yield return new WaitForSeconds(randomData.WaitAfterStartWaves);
            }

            _coroutine = StartCoroutine(WaitDamage());
        }

        private IEnumerator WaitDamage()
        {
            Material[] mats = _skinnedMeshRenderer.materials;


            _baseHitBox.gameObject.SetActive(true);
            mats[0] = _redBodyMaterial;
            
            _skinnedMeshRenderer.materials = mats;
            
            yield return new WaitForSecondsRealtime(DamageTime);
            
            _coroutine = StartCoroutine(GenerateWawes());
            
            mats[0] = _defaultBodyMaterial;
            _skinnedMeshRenderer.materials = mats;
            _baseHitBox.gameObject.SetActive(false);
        }


        private IEnumerator DestroyGun()
        {
            _particleSystem.Play();

            if (_needDownWals)
            {
                _wals.transform.DOMove(new Vector3(_wals.transform.position.x, _walsY, _wals.transform.position.z), _walsDuration).SetEase(_ease);
            }
            
            yield return new WaitForSeconds(0.2f);
            _gun.gameObject.SetActive(false);
            _enemyTurret.TurretAimPoint = _eyePos;

            yield return new WaitForSeconds(0.2f);

            _coroutine = StartCoroutine(GenerateWawes());
        }
    }
}