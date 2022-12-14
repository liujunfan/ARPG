#if UNITY_EDITOR

using UnityEditor;

namespace Nono
{
    /// <summary>
    /// BaseWindow
    /// </summary>
    public abstract class BaseWindow : EditorWindow
    {
        protected virtual void OnEnable()
        {
            Undo.undoRedoPerformed += OnUndoRedoPerformed;
        }


        protected virtual void OnDisable()
        {
            Undo.undoRedoPerformed -= OnUndoRedoPerformed;
        }


        protected virtual void OnUndoRedoPerformed()
        {
            Repaint();
        }

    } // class BaseWindow

} 

#endif // UNITY_EDITOR