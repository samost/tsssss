using System;
using System.Collections.Generic;
using Data;
using Tools;
using UnityEngine;
using Zenject;

public class LevelGenerator : MonoBehaviour
{
    [Header("Param")]
    [SerializeField]
    private GenerationParam _generationParam;

    [Header("Ref")]
    [SerializeField]
    private GameObject _rightPlatformPrefab;

    [SerializeField]
    private GameObject _leftPlatformPrefab;

    [SerializeField]
    private GameObject _backgroundObject;


    private Queue<PlatformsRow> _createdPlatforms;

    [Inject]
    private RocketMovement _rocketMovement;

    private int _buildIndex;

    private void Start()
    {
        GenerateRows();
    }

    private void Update()
    {
        UpdateBackPosition();

        TryRebuild();
    }

    private void TryRebuild()
    {
        if (_rocketMovement.transform.position.y - _createdPlatforms.Peek().posY >= _generationParam.deltaToRebuild)
        {
            PlatformsRow regeneratedRow = _createdPlatforms.Dequeue();
            regeneratedRow.Rebuild(_generationParam.platformOffsetY * _buildIndex,
                ChanceGenerator.HasChance(_generationParam.chanceToChangedRow));
            _createdPlatforms.Enqueue(regeneratedRow);
            _buildIndex++;
        }
    }

    private void GenerateRows()
    {
        _createdPlatforms = new Queue<PlatformsRow>();
        for (int i = 0; i < _generationParam.rowsInstancesCount; i++)
        {
            GameObject left = Instantiate(_leftPlatformPrefab,
                new Vector3(-_generationParam.platformDefaultDeltaX, _generationParam.platformOffsetY * i,
                    _generationParam.platformDefaultZ), Quaternion.identity);
            GameObject right = Instantiate(_rightPlatformPrefab,
                new Vector3(_generationParam.platformDefaultDeltaX, _generationParam.platformOffsetY * i,
                    _generationParam.platformDefaultZ), Quaternion.identity);


            PlatformsRow row = new PlatformsRow(left, right, _generationParam.platformDefaultDeltaX);
            row.Rebuild(_generationParam.platformOffsetY * i, ChanceGenerator.HasChance(_generationParam.chanceToChangedRow));
            _createdPlatforms.Enqueue(row);
            _buildIndex = i;
        }
    }


    private void UpdateBackPosition()
    {
        Vector3 backPos = _backgroundObject.transform.position;
        backPos.y = _rocketMovement.transform.position.y;
        _backgroundObject.transform.position = backPos;
    }
}