using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager {
    public float CameraDistance = -12.5f;
    public float CameraHeight = 20;
    public float CameraRotation = 60;

    private static GameObject _targetObject;
    private GameObject _camera;

    public CameraManager(GameObject cameraPrefab)
    {
        _camera = GameObject.Instantiate(cameraPrefab);
    }

    public void Update()
    {
        _camera.transform.position = _targetObject.transform.position + new Vector3(0, CameraHeight, CameraDistance);
    }

    public static void ChangeCamera(Character caracter)
    {
        _targetObject = caracter.CharacterObject;     
    }
}
