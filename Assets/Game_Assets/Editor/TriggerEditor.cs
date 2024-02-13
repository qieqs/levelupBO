using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.ProBuilder.Shapes;
using static UnityEngine.Rendering.VirtualTexturing.Debugging;

[CustomEditor(typeof(TriggerAnimation))]
public class TriggerEditor : Editor
{
    TriggerAnimation triggers;
    bool clicked;
    public Animator source;
    int animationnumbers;

    private Animator[] animators;
    private List<Animator> animations;
    public override void OnInspectorGUI()
    {
        triggers = target as TriggerAnimation;

        if (GUILayout.Button("uitleg"))
        {
            if (clicked)
                clicked = false;
            else
                clicked = true;
        }

        if (clicked)
        {
            EditorGUILayout.HelpBox("Dit script is een trigger \nWanneer de speler in contact komt met de collider, dan zal er 1 of meer animaties worden afgespeeld. \nJe kunt zelf een nieuw slot toevoegen en deze koppelen aan een animator van een object in de sc�ne. Je kunt er dus meerdere tegelijkertijd aanzetten", MessageType.Info);
        }


        EditorGUILayout.LabelField("voeg een box toe om een animatie aan te linken");
        GUILayout.BeginHorizontal("box");
        if (GUILayout.Button("+"))
        {
            animations.Add(source);
        }
        if (GUILayout.Button("-"))
        {
            if(animations.Count > 0)
                animations.RemoveAt(animationnumbers);
        }
        GUILayout.EndHorizontal();


        EditorGUI.BeginChangeCheck();
        animations = triggers.animatorslist;
        if (animations.Count > 0)
        {
            for (int i = 0; i < animations.Count; i++)
            {
                animations[i] = EditorGUILayout.ObjectField(animations[i], typeof(Animator), true) as Animator;
            }
        }
        if (EditorGUI.EndChangeCheck())
        {
            Undo.RecordObject(triggers, "Move Point");
            EditorUtility.SetDirty(triggers);
            triggers.animatorslist = animations;
        }
    }
}
