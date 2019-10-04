using System;

namespace DotNetUniversalPatcher.Exceptions
{
    internal class PatcherException : Exception
    {
        internal PatcherException(string message, string fullName) : base($"{message} -> {fullName}")
        {
        }
    }
}