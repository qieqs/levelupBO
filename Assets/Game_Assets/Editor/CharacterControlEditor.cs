using Codice.Client.BaseCommands;
using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using static Unity.VisualScripting.Member;

[CustomEditor(typeof(ThirdPersonController))]
public class CharacterControlEditor : Editor
{
    ThirdPersonController charactercontrol;
    bool clicked;
    public override void OnInspectorGUI()
    {
        charactercontrol = target as ThirdPersonController;
        EditorGUILayout.LabelField("Karakter Controle Script");

        if (GUILayout.Button("uitleg"))
        {
            if (clicked)
                clicked = false;
            else
                clicked = true;
        }

        if (clicked)
        {
            EditorGUILayout.HelpBox("Dit script bestuurt het karakter.\nHieronder kun je verschillende dingen veranderen zoals de loopsnelheid, de hoogte van de sprong en de hoeveelheid sprongen die het karakter kan maken\n speel met de knoppen hieronder en kijk wat voor invloed het heeft op de speler", MessageType.Info);
        }

        charactercontrol.MoveSpeed = EditorGUILayout.Slider("loopsnelheid", charactercontrol.MoveSpeed, 1, 50);
        charactercontrol.SprintSpeed = EditorGUILayout.Slider("sprintsnelheid", charactercontrol.SprintSpeed, 1, 50);
        charactercontrol.JumpHeight = EditorGUILayout.Slider("sprintsnelheid", charactercontrol.JumpHeight, 1, 50);
        charactercontrol.maxjump = EditorGUILayout.IntField("maximale hoeveelheid sprongen", charactercontrol.maxjump);
    }
}
