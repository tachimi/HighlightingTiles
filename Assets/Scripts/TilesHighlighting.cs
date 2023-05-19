using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TilesHighlighting : MonoBehaviour
{
    private Renderer _lastHighlightedCube;
    private Color _originalColor;

    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out var hitInfo))
        {
            var currentCube = hitInfo.collider.GetComponent<Renderer>();

            if (hitInfo.collider.CompareTag("Grass") || hitInfo.collider.CompareTag("Bridge"))
            {
                if (currentCube != _lastHighlightedCube)
                {
                    if (_lastHighlightedCube != null)
                    {
                        _lastHighlightedCube.material.color = _originalColor;
                    }

                    _lastHighlightedCube = currentCube;
                    _originalColor = _lastHighlightedCube.material.color;

                    _lastHighlightedCube.material.color = Color.gray;
                }
            }
        }
        else
        {
            if (_lastHighlightedCube != null)
            {
                _lastHighlightedCube.material.color = _originalColor;
                _lastHighlightedCube = null;
            }
        }
    }
}