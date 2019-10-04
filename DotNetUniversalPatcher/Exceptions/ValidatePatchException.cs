using System;

namespace DotNetUniversalPatcher.Exceptions
{
    internal class ValidatePatchException : Exception
    {
        internal ValidatePatchException(string message, int patchIndex) : base($"{message} -> Patch index: {patchIndex}")
        {
        }
    }
}