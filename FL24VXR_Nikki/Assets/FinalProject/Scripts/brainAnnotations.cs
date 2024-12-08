using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class brainAnnotations : MonoBehaviour
{
    [System.Serializable]
    public class Annotation
    {
        public string title;
        public string description;
        public Vector3 localPosition; // Changed to local position
        public GameObject annotationObject;
    }

    [Header("Annotation Settings")]
    public List<Annotation> annotations = new List<Annotation>();

    [Header("Prefab References")]
    public GameObject annotationPrefab;

    private void Start()
    {
        CreateAnnotations();
    }

    public void CreateAnnotations()
    {
        // Clear existing annotations
        foreach (var annotation in annotations)
        {
            if (annotation.annotationObject != null)
            {
                Destroy(annotation.annotationObject);
            }
        }
        annotations.Clear();

        // Add some sample annotations
        AddAnnotation("Sample Point 1", "First annotation description", new Vector3(0.5f, 0.5f, 0));
        AddAnnotation("Sample Point 2", "Second annotation description", new Vector3(-0.5f, 0.5f, 0));
    }

    public void AddAnnotation(string title, string description, Vector3 localPosition)
    {
        // Instantiate annotation as a child of this object
        GameObject newAnnotationObj = Instantiate(annotationPrefab, transform);

        // Position the annotation locally
        newAnnotationObj.transform.localPosition = localPosition;

        // Set up text components
        Text titleText = newAnnotationObj.transform.Find("TitleText")?.GetComponent<Text>();
        Text descriptionText = newAnnotationObj.transform.Find("DescriptionText")?.GetComponent<Text>();

        if (titleText != null)
            titleText.text = title;
        if (descriptionText != null)
            descriptionText.text = description;

        // Create annotation object and store
        Annotation annotation = new Annotation
        {
            title = title,
            description = description,
            localPosition = localPosition,
            annotationObject = newAnnotationObj
        };

        annotations.Add(annotation);
    }

    public void RemoveAnnotation(int index)
    {
        if (index >= 0 && index < annotations.Count)
        {
            Destroy(annotations[index].annotationObject);
            annotations.RemoveAt(index);
        }
    }
}
