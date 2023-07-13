using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using PixelCrushers.DialogueSystem;

public class GeneratorConsole : MonoBehaviour
{
    [Header("Fuse + Console")]
    [SerializeField] private ShowUVCode _showUVCode;
    [SerializeField] public Item Fuse;
    [SerializeField] public ItemSlot Slot;
    [SerializeField] private GameObject _fuseOne;
    [SerializeField] private GameObject _fuseTwo;

    [SerializeField] private GameObject _firstCode;
    [SerializeField] private GameObject _secondCode;
    [SerializeField] private GameObject _firstLight;
    [SerializeField] private GameObject _secondLight;
    [SerializeField] private GameObject _firstElectricity;
    [SerializeField] private GameObject _secondElectricity;

    [Header("Sound")]
    [SerializeField] private AudioSource _audioSourceGenerator;
    [SerializeField] private AudioClip _audioClipStart;
    [SerializeField] private AudioClip _audioClipRunning;
    [SerializeField] private float _runningDelay;

    [SerializeField] private AudioSource _electroAudioSource;
    [SerializeField] private AudioClip _electricShot;


    [Header("Lights")]
    [SerializeField] private List<GameObject> _lights;

    private InventoryManager _inventoryManager;
    private MechanicStatusManager _mechanicStatusManager;

    public void Awake()
    {
        _firstCode.SetActive(false);
        _secondCode.SetActive(false);
        _firstLight.SetActive(false);
        _secondLight.SetActive(false);
    }

    private void Start()
    {
        _inventoryManager = Manager.Use<InventoryManager>();
        _mechanicStatusManager = Manager.Use<MechanicStatusManager>();
    }

    public void UseFuseInConsole()
    {
        if (_inventoryManager.CheckInvForFuse() && _fuseOne.activeSelf == false)
        {
            _fuseOne.SetActive(true);
            _firstElectricity.SetActive(true);
            _inventoryManager.InventoryItems.Remove(Fuse);
            Destroy(_inventoryManager.InventorySlots[0].gameObject);
            _inventoryManager.InventorySlots.Remove(_inventoryManager.InventorySlots[0]);
            _inventoryManager.RefreshUI();
            _firstCode.SetActive(true);
            _firstLight.SetActive(true);
            _electroAudioSource.clip = _electricShot;
            _electroAudioSource.Play();

            //_mechanicStatusManager.FuseOneInConsole = true;
            DialogueLua.SetVariable("FuseInConsole", true);


        }
        else if (_inventoryManager.CheckInvForFuse() && _fuseOne.activeSelf)
        {
            _fuseTwo.SetActive(true);
            _secondElectricity.SetActive(true);
            _inventoryManager.InventoryItems.Remove(Fuse);
            Destroy(_inventoryManager.InventorySlots[0].gameObject);
            _inventoryManager.InventorySlots.Remove(_inventoryManager.InventorySlots[0]);
            _showUVCode.ShowCode(_secondCode, _secondLight);

            _electroAudioSource.clip = _electricShot;
            _electroAudioSource.Play();

            foreach(GameObject light in _lights)
            {
                light.SetActive(true);
            }

            StartCoroutine(GeneratorSound());
            Debug.Log("Fuse vorhanden");
        }
        else
        {
            Debug.Log("Keine Fuse vorhanden");
        }
    }

    IEnumerator GeneratorSound()
    {
        _audioSourceGenerator.clip = _audioClipStart;
        _audioSourceGenerator.Play();
        yield return new WaitForSeconds(_runningDelay);
        _audioSourceGenerator.Stop();
        _audioSourceGenerator.loop = true;
        _audioSourceGenerator.clip = _audioClipRunning;
        _audioSourceGenerator.Play();
    }

    /*public int GetFuseUI()
    {
        if (_inventoryManager._keyOne.action.IsPressed())
        {
            return i = 0;
        }
        else if (_inventoryManager._keyTwo.action.IsPressed())
        {
            return i = 1;
        }
        else if (_inventoryManager._keyThree.action.IsPressed())
        {
            return i = 2;
        }
        else return -
    }*/
}
