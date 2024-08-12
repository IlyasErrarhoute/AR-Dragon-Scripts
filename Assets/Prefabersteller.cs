using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class Prefabersteller : MonoBehaviour
{
    [SerializeField] private GameObject drachenPrefab;
    [SerializeField] private Vector3 prefabOffset ;
    private GameObject drache;
    private ARTrackedImageManager aRTrackedImageManager;

    private void OnEnable()
    {
        aRTrackedImageManager = gameObject.GetComponent<ARTrackedImageManager>();
        aRTrackedImageManager.trackedImagesChanged += OnImageChanged;
    }

    private void OnImageChanged(ARTrackedImagesChangedEventArgs obj)
    {
        foreach (ARTrackedImage image in obj.added)
        {
            drache = Instantiate(drachenPrefab, image.transform);
            drache.transform.position += prefabOffset;
        }
    }
}
