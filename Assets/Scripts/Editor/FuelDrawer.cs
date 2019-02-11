using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Fuel))]
public class FuelDrawer : Editor
{
    public override void OnInspectorGUI()
    {
        Fuel fuel = target as Fuel;

        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.PrefixLabel("Fuel:");

        var label = string.Format("{0:0.00}", fuel.Amount);
        GUILayout.Label(label, GUILayout.Width(45));

        GUILayout.Label("/", GUILayout.Width(10));

        var max_property = serializedObject.FindProperty("max");
        EditorGUILayout.PropertyField(max_property, GUIContent.none, true, GUILayout.MaxWidth(75));
        EditorGUILayout.EndHorizontal();

        serializedObject.ApplyModifiedProperties();
        Repaint();
    }
}
