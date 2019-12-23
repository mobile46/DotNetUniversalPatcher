using DotNetUniversalPatcher.Models;
using System.Collections.Generic;

namespace DotNetUniversalPatcher.Engine
{
    internal abstract class ScriptEngineBase : IScriptEngine
    {
        public List<PatcherScript> LoadedScripts { get; set; }
        public PatcherScript CurrentScript { get; set; }
        public bool IsLoadingError { get; set; }

        public abstract void LoadAndParseScripts();

        public abstract void ChangeScript();

        public abstract void Process();

        public abstract string[] GetSoftwareNames();
    }
}