#if UNITY_EDITOR

using UnityEngine;
using UnityEditor;

namespace Nono
{
    public class EditorPathResources : ScriptableAssetSingleton<EditorPathResources>
    {
        public Texture2D moveToolPan;
        public Texture2D moveTool3D;
        public Texture2D RotateTool;
        public Texture2D addNodeForward;
        public Texture2D addNodeBack;
        public Texture2D removeNode;


        [MenuItem("Assets/Create/Editor/Paths Editor Resources")]
        static void CreateAsset()
        {
            CreateOrSelectAsset();
        }

    } // EditorResources

}

#endif