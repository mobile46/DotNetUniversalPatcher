using System;

namespace DotNetUniversalPatcher.Exceptions
{
    internal class ValidatePatchAndTargetException : Exception
    {
        internal ValidatePatchAndTargetException(string message, int patchIndex, int targetIndex) : base($"{message} -> Patch/Target index: {patchIndex}/{targetIndex}")
        {
        }
    }
}