using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SamEbac.Core.Singleton;
using DG.Tweening;

public class GameManager : Singleton<GameManager>
{
    [Header("Animations")]
    public float duration = .2f;
    public float delay = .05f;
    public Ease ease = Ease.OutBack;

    [Header("Player")]
    public GameObject playerPrefabs;


    [Header("Enemies")]
    public List<GameObject> enemies;
     
    [Header("References")]
    public Transform StartPoint;
    
    private GameObject _currentPlayer;

    private void Start()
    {
        Init();
    }

    public void Init()
    {
        SpawnPlayer();

    }

    private void SpawnPlayer()
    {
        _currentPlayer = Instantiate(playerPrefabs);
        _currentPlayer.transform.position = StartPoint.transform.position;
        _currentPlayer.transform.DOScale(0, duration).SetEase(ease).From().SetDelay(delay);


    }

}
