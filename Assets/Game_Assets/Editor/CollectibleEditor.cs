using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Collectible))]
public class CollectibleEditor : Editor
{
    private bool clicked;
    private bool rotclicked = true;
    private bool floatclicked = true;

    public override void OnInspectorGUI()
    {
        Collectible collectible = (Collectible)target;

        if (GUILayout.Button("uitleg"))
        {
            if (clicked)
                clicked = false;
            else
                clicked = true;
        }
        
        if(collectible.GetComponent<Collider>() == null)
            EditorGUILayout.HelpBox("Je moet een collider toevoegen om dit te laten werken", MessageType.Info);

        if (clicked)
        {
            EditorGUILayout.HelpBox("Dit script bestuurt het opraapbare object. \nWanneer de speler binnen de collider loopt, dan zal dit script een particle effect afspelen en het object verwijderen. \nJe kunt de collectible laten draaien met de volgende rotatie knoppen en de snelheid", MessageType.Info);
        }

        if(GUILayout.Button("rotatie knoppen")) 
        {
            if (rotclicked)
                rotclicked = false;
            else
                rotclicked = true;
        }

        if(rotclicked)
        {
            EditorGUILayout.LabelField("collectible laten draaien");
            collectible.xaxis = EditorGUILayout.Toggle("x_rotatie", collectible.xaxis);
            collectible.yaxis = EditorGUILayout.Toggle("y_rotatie", collectible.yaxis);
            collectible.zaxis = EditorGUILayout.Toggle("z_rotatie", collectible.zaxis);
            collectible.speed = EditorGUILayout.Slider("draaisnelheid", collectible.speed, 1, 50);

        }

        if (GUILayout.Button("beweeg knoppen"))
        {
            if (floatclicked)
                floatclicked = false;
            else
                floatclicked = true;
        }


        if (floatclicked)
        {
            EditorGUILayout.LabelField("collectible op en neer bewegen");
            collectible.amplitude = EditorGUILayout.Slider("afstand", collectible.amplitude, 0, 10);
            collectible.frequency = EditorGUILayout.Slider("snelheid", collectible.frequency, 0, 10);
        }
    }
}
