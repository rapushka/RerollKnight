using UnityEditor;

namespace Code
{
	public static class ForceRecompile
	{
		[MenuItem("Tools/Force Recompile Scripts %&r")]
		public static void ForceRecompileScripts()
		{
			EditorApplication.UnlockReloadAssemblies();

			EditorUtility.RequestScriptReload();
			AssetDatabase.Refresh();
		}

		[MenuItem("Tools/Unlock Reload Assemblies")]
		public static void UnlockAssemblies()
		{
			EditorApplication.UnlockReloadAssemblies();
		}
	}
}