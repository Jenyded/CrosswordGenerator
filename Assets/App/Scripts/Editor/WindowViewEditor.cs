using App.Scripts.Infrastructure.SimpleWindows.Window;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine.UIElements;

namespace App.Scripts.Editor
{
    [CustomEditor(typeof(WindowView))]
    public class WindowViewEditor : UnityEditor.Editor
    {
        public override VisualElement CreateInspectorGUI()
        {
            var root = new VisualElement();
            InspectorElement.FillDefaultInspector(root, serializedObject, this);

            var button = new Button(() =>
            {
                var windowView = (WindowView)target;
                WindowBehavior[] found = windowView.GetComponentsInChildren<WindowBehavior>(true);
                Undo.RecordObject(windowView, "Add Behaviors");
                windowView.AddBehaviors(found);
                serializedObject.Update();
                EditorUtility.SetDirty(windowView);
            })
            {
                text = "Find behaviors "
            };
            root.Add(button);

            return root;
        }
    }
}
