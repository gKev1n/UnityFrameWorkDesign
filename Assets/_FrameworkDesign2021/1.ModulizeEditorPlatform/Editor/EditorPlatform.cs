using FrameworkDesign2021;
using FrameworkDesign2021._2.ServiceLocator;
using FrameworkDesign2021._2.ServiceLocator.Default;
using UnityEditor;
using UnityEngine;

namespace _FrameworkDesign2021
{
    public class EditorModulizationPlatformEditor : EditorWindow
    {
        /// <summary>
        /// 用来缓存模块的容器
        /// </summary>
        private ModuleContainer mModuleContainer = null;

        /// <summary>
        /// 打开窗口
        /// </summary>
        [MenuItem("FrameworkDesign2021/0.EditorModulizationPlatform")]
        public static void Open()
        {
            var editorPlatform = GetWindow<EditorModulizationPlatformEditor>();

            editorPlatform.position = new Rect(
                Screen.width / 2,
                Screen.height * 2 / 3,
                600,
                500
            );

            // 组装 Container
            // var cache = new EditorPlatformModuleCache();
            // var factory = new EditorPlatformModuleFactory();
            var moduleType = typeof(IEditorPlatformModule);
            var cache = new DefaultModuleCache();
            var factory = new AssemblyModuleFactory(moduleType.Assembly, moduleType);

            editorPlatform.mModuleContainer = new ModuleContainer(cache, factory);

            editorPlatform.Show();
        }

        private void OnGUI()
        {
            // 获取全部模块
            var modules = mModuleContainer.GetAllModules<IEditorPlatformModule>();
            
            // 渲染
            foreach (var editorPlatformModule in modules)
            {
                // Debug.Log(editorPlatformModule);
                editorPlatformModule.OnGUI();
            }
        }
    }
}