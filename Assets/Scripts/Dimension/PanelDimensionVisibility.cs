using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelDimensionVisibility : MonoBehaviour
{
    void Start()
    {
        // Obtenemos la referencia al componente Transform del objeto padre
        Transform parentTransform = GetComponent<Transform>();

        // Cambiar el orden de los hijos
        int childIndexToMove = 2; // Índice del hijo que deseas mover
        int newSiblingIndex = 0; // Nuevo índice deseado para el hijo

        if (childIndexToMove < parentTransform.childCount)
        {
            Transform childTransform = parentTransform.GetChild(childIndexToMove);
            childTransform.SetSiblingIndex(newSiblingIndex);
        }
    }
}
