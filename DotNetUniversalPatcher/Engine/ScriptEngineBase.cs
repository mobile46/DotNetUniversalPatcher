using DotNetUniversalPatcher.Models;
using System.Collections.Generic;

namespace DotNetUniversalPatcher.Engine
{
    internal abstract class ScriptEngineBase : IScriptEngine
    {
        public List<PatcherScript> LoadedScripts { get; } = new List<PatcherScript>();
        public PatcherScript CurrentScript { get; set; } = new PatcherScript();
        public bool IsLoadingError { get; set; }

        public abstract void LoadAndParseScripts();

        public abstract void ChangeScript();

        public abstract void Process();

        public abstract string[] GetSoftwareNames();
    }
}