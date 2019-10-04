using DotNetUniversalPatcher.Models;
using System.Collections.Generic;

namespace DotNetUniversalPatcher.Engine
{
    internal interface IScriptEngine
    {
        List<PatcherScript> LoadedScripts { get; }
        PatcherScript CurrentScript { get; set; }
        bool IsLoadingError { get; set; }

        void LoadAndParseScripts();

        void ChangeScript();

        void Process();

        string[] GetSoftwareNames();
    }
}