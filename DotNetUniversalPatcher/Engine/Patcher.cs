using dnlib.DotNet;
using dnlib.DotNet.Emit;
using dnlib.DotNet.Writer;
using DotNetUniversalPatcher.Exceptions;
using DotNetUniversalPatcher.Extensions;
using DotNetUniversalPatcher.Models;
using DotNetUniversalPatcher.Utilities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace DotNetUniversalPatcher.Engine
{
    internal class Patcher : IDisposable
    {
        public MethodDef Method { get; set; }
        public IList<Instruction> Instructions { get; set; }

        internal readonly ModuleDefMD Module;

        private readonly string _file;
        private readonly bool _keepOldMaxStack;
        private readonly List<string> _exceptionHandlersIndices = new List<string>();

        internal Patcher(string file, bool keepOldMaxStack)
        {
            _file = file;
            Module = ModuleDefMD.Load(file);
            _keepOldMaxStack = keepOldMaxStack;
        }

        internal void Patch(Target target)
        {
            if (target.Instructions != null)
            {
                PatchAndClear(target);
            }
            else if (target.Instructions == null)
            {
                throw new PatcherException("No Instructions specified", target.FullName);
            }
        }

        internal void PatchAndClear(Target target)
        {
            Method.Body.ExceptionHandlers.Clear();
            Instructions.Clear();

            for (int i = 0; i < target.Instructions.Length; i++)
            {
                Instructions.Insert(i, target.Instructions[i]);
            }
        }

        internal void Insert(Target target)
        {
            if (target.Indices != null && target.Instructions != null)
            {
                if (target.Indices.Count == target.Instructions.Length)
                {
                    for (int i = 0; i < target.Indices.Count; i++)
                    {
                        if (target.Indices[i].ToString().Contains(Constants.RangeExpressionSeparator))
                        {
                            string[] startAndEnd = Regex.Split(target.Indices[i].ToString(), Constants.RangeExpressionRegexPattern);

                            int start = startAndEnd[0].ToInt();
                            int end = startAndEnd[1].ToInt();

                            if (startAndEnd.Length == 2 && start <= end)
                            {
                                uint offset = 0;

                                for (int j = start; j <= end; j++)
                                {
                                    Instructions.Insert(j, Instruction.Create(OpCodes.Nop));

                                    Instructions[j].OpCode = target.Instructions[i].OpCode;

                                    if (Instructions[j].Operand != null)
                                    {
                                        Instructions[j].Operand = target.Instructions[i].Operand;
                                    }

                                    offset += (uint)Instructions[j].GetSize();
                                    Instructions[j].Offset = offset;
                                }
                            }
                            else
                            {
                                throw new PatcherException("Index Range format is incorrect (Correct format is startIndex...endIndex)", target.FullName);
                            }
                        }
                        else
                        {
                            Instructions.Insert(target.Indices[i].ToString().ToInt(), target.Instructions[i]);
                        }
                    }
                }
                else
                {
                    throw new PatcherException("Instructions and Indices count must be equal", target.FullName);
                }
            }
            else if (target.Instructions == null)
            {
                throw new PatcherException("No Instructions specified", target.FullName);
            }
            else if (target.Indices == null)
            {
                throw new PatcherException("No Indices specified", target.FullName);
            }
        }

        internal void Replace(Target target)
        {
            if (target.Indices != null && target.Instructions != null)
            {
                if (target.Indices.Count == target.Instructions.Length)
                {
                    for (int i = 0; i < target.Indices.Count; i++)
                    {
                        if (target.Indices[i].ToString().Contains(Constants.RangeExpressionSeparator))
                        {
                            string[] startAndEnd = Regex.Split(target.Indices[i].ToString(), Constants.RangeExpressionRegexPattern);

                            int start = startAndEnd[0].ToInt();
                            int end = startAndEnd[1].ToInt();

                            if (startAndEnd.Length == 2 && start <= end)
                            {
                                uint offset = 0;

                                for (int j = start; j <= end; j++)
                                {
                                    Instructions[j].OpCode = target.Instructions[i].OpCode;

                                    if (Instructions[j].Operand != null)
                                    {
                                        Instructions[j].Operand = target.Instructions[i].Operand;
                                    }

                                    offset += (uint)Instructions[j].GetSize();
                                    Instructions[j].Offset = offset;
                                }
                            }
                            else
                            {
                                throw new PatcherException("Index Range format is incorrect (Correct format is startIndex...endIndex)", target.FullName);
                            }
                        }
                        else
                        {
                            Instructions[target.Indices[i].ToString().ToInt()] = target.Instructions[i];
                        }
                    }
                }
                else
                {
                    throw new PatcherException("Instructions and Indices count must be equal", target.FullName);
                }
            }
            else if (target.Indices == null)
            {
                throw new PatcherException("No Indices specified", target.FullName);
            }
            else if (target.Instructions == null)
            {
                throw new PatcherException("No instructions specified", target.FullName);
            }
        }

        internal void Remove(Target target)
        {
            if (target.Indices != null)
            {
                foreach (string index in target.Indices.OrderByDescending(x => x))
                {
                    if (index.Contains(Constants.RangeExpressionSeparator))
                    {
                        string[] startAndEnd = Regex.Split(input: index, Constants.RangeExpressionRegexPattern);

                        int start = startAndEnd[0].ToInt();
                        int end = startAndEnd[1].ToInt();

                        if (startAndEnd.Length == 2 && start <= end)
                        {
                            var range = Enumerable.Range(start, end + 1 - start).OrderByDescending(x => x);

                            foreach (int j in range)
                            {
                                Instructions.RemoveAt(j);
                            }
                        }
                        else
                        {
                            throw new PatcherException("Index Range format is incorrect (Correct format is startIndex...endIndex)", target.FullName);
                        }
                    }
                    else
                    {
                        Instructions.RemoveAt(int.Parse(index));
                    }
                }
            }
            else
            {
                throw new PatcherException("No Indices specified", target.FullName);
            }
        }

        internal void EmptyBody(Target target)
        {
            target.Instructions = new[] { Instruction.Create(OpCodes.Ret) };
            PatchAndClear(target);
        }

        internal void ReturnBody(Target target, bool trueOrFalse)
        {
            if (trueOrFalse)
            {
                target.Instructions = new[]
                {
                    Instruction.Create(OpCodes.Ldc_I4_1),
                    Instruction.Create(OpCodes.Ret)
                };
            }
            else
            {
                target.Instructions = new[]
                {
                    Instruction.Create(OpCodes.Ldc_I4_0),
                    Instruction.Create(OpCodes.Ret)
                };
            }

            PatchAndClear(target);
        }

        internal void Save(bool backup)
        {
            string tempFile = $"{_file}.tmp";
            string backupFile = $"{_file}.bak";

            if (Module.IsILOnly)
            {
                if (_keepOldMaxStack)
                {
                    Module.Write(tempFile, new ModuleWriterOptions(Module)
                    {
                        MetadataOptions = { Flags = MetadataFlags.KeepOldMaxStack }
                    });
                }
                else
                {
                    Module.Write(tempFile);
                }
            }
            else
            {
                if (_keepOldMaxStack)
                {
                    Module.NativeWrite(tempFile, new NativeModuleWriterOptions(Module, false)
                    {
                        MetadataOptions =
                        {
                            Flags = MetadataFlags.KeepOldMaxStack
                        }
                    });
                }
                else
                {
                    Module.NativeWrite(tempFile);
                }
            }

            Module?.Dispose();

            if (backup)
            {
                if (!File.Exists(backupFile))
                {
                    File.Move(_file, backupFile);
                }
                else
                {
                    Logger.Info($"Backup file already exists -> {backupFile}");
                }
            }

            File.Delete(_file);
            File.Move(tempFile, _file);
        }

        internal IMethod FindMethod(string fullName)
        {
            foreach (var module in Module.Assembly.Modules)
            {
                foreach (var type in module.GetTypes())
                {
                    foreach (var method in type.Methods)
                    {
                        if (string.Equals(method.FullName, fullName, StringComparison.InvariantCultureIgnoreCase))
                        {
                            return method;
                        }
                    }
                }
            }

            LoadCustomModule(ref fullName, out ModuleDefMD customModule);

            foreach (var module in customModule.Assembly.Modules)
            {
                foreach (var type in module.GetTypes())
                {
                    foreach (var method in type.Methods)
                    {
                        if (string.Equals(method.FullName, fullName, StringComparison.InvariantCultureIgnoreCase))
                        {
                            return Module.Import(method);
                        }
                    }
                }
            }

            throw new PatcherException("Method not found", fullName);
        }

        internal IField FindField(string fullName)
        {
            foreach (var module in Module.Assembly.Modules)
            {
                foreach (var type in module.GetTypes())
                {
                    foreach (var field in type.Fields)
                    {
                        if (string.Equals(field.FullName, fullName, StringComparison.InvariantCultureIgnoreCase))
                        {
                            return field;
                        }
                    }
                }
            }

            LoadCustomModule(ref fullName, out ModuleDefMD customModule);

            foreach (var module in customModule.Assembly.Modules)
            {
                foreach (var type in module.GetTypes())
                {
                    foreach (var field in type.Fields)
                    {
                        if (string.Equals(field.FullName, fullName, StringComparison.InvariantCultureIgnoreCase))
                        {
                            return Module.Import(field);
                        }
                    }
                }
            }

            throw new PatcherException("Field not found", fullName);
        }

        internal IType FindType(string fullName)
        {
            foreach (var module in Module.Assembly.Modules)
            {
                foreach (var type in module.GetTypes())
                {
                    if (string.Equals(type.FullName, fullName, StringComparison.InvariantCultureIgnoreCase))
                    {
                        return type;
                    }
                }
            }

            LoadCustomModule(ref fullName, out ModuleDefMD customModule);

            foreach (var module in customModule.Assembly.Modules)
            {
                foreach (var type in module.GetTypes())
                {
                    if (string.Equals(type.FullName, fullName, StringComparison.InvariantCultureIgnoreCase))
                    {
                        return Module.Import(type);
                    }
                }
            }

            throw new PatcherException("Type not found", fullName);
        }

        internal IMemberRef FindMethodFieldOrType(string fullName)
        {
            foreach (var module in Module.Assembly.Modules)
            {
                foreach (var type in module.GetTypes())
                {
                    if (string.Equals(type.FullName, fullName, StringComparison.InvariantCultureIgnoreCase))
                    {
                        return type;
                    }

                    foreach (var method in type.Methods)
                    {
                        if (string.Equals(method.FullName, fullName, StringComparison.InvariantCultureIgnoreCase))
                        {
                            return method;
                        }
                    }

                    foreach (var field in type.Fields)
                    {
                        if (string.Equals(field.FullName, fullName, StringComparison.InvariantCultureIgnoreCase))
                        {
                            return field;
                        }
                    }
                }
            }

            LoadCustomModule(ref fullName, out ModuleDefMD customModule);

            foreach (var module in customModule.Assembly.Modules)
            {
                foreach (var type in module.GetTypes())
                {
                    if (string.Equals(type.FullName, fullName, StringComparison.InvariantCultureIgnoreCase))
                    {
                        return Module.Import(type);
                    }

                    foreach (var method in type.Methods)
                    {
                        if (string.Equals(method.FullName, fullName, StringComparison.InvariantCultureIgnoreCase))
                        {
                            return Module.Import(method);
                        }
                    }

                    foreach (var field in type.Fields)
                    {
                        if (string.Equals(field.FullName, fullName, StringComparison.InvariantCultureIgnoreCase))
                        {
                            return Module.Import(field);
                        }
                    }
                }
            }

            throw new PatcherException("Method, Field or Type not found", fullName);
        }

        internal void LoadCustomModule(ref string fullName, out ModuleDefMD customModule)
        {
            customModule = null;

            if (fullName.Contains(Constants.DefaultSeparator))
            {
                string[] custom = fullName.Split(Constants.DefaultSeparator);

                if (custom.Length == 2)
                {
                    if (!File.Exists(custom[0]))
                    {
                        custom[0] = Type.GetType(custom[0], false, true)?.Module.FullyQualifiedName;
                    }

                    customModule = ModuleDefMD.Load(custom[0]);
                    fullName = custom[1];
                }
            }
            else
            {
                customModule = ScriptEngineHelpers.MscorelibModule;
            }
        }

        internal void BackupExceptionHandlersIndices()
        {
            foreach (var exception in Method.Body.ExceptionHandlers)
            {
                _exceptionHandlersIndices.Add($"{Instructions.IndexOf(exception.TryStart)}|{Instructions.IndexOf(exception.TryEnd)}|{Instructions.IndexOf(exception.HandlerStart)}|{Instructions.IndexOf(exception.HandlerEnd)}|{Instructions.IndexOf(exception.FilterStart)}");
            }
        }

        internal void FixOffsets()
        {
            uint offset = 0;

            foreach (var instruction in Instructions)
            {
                instruction.Offset = offset;
                offset += (uint)instruction.GetSize();
            }
        }

        internal void FixBranches()
        {
            foreach (var instruction in Instructions)
            {
                switch (instruction.OpCode.OperandType)
                {
                    case OperandType.InlineBrTarget:
                    case OperandType.ShortInlineBrTarget:
                        var operand = (Instruction)instruction.Operand;

                        if (operand != null)
                        {
                            instruction.Operand = GetInstruction(operand.Offset);
                        }
                        break;

                    case OperandType.InlineSwitch:
                        if (instruction.Operand is Instruction[] instructions)
                        {
                            var array = new Instruction[instructions.Length];

                            for (int j = 0; j < instructions.Length; j++)
                            {
                                array[j] = GetInstruction(instructions[j].Offset);
                            }

                            instruction.Operand = array;
                        }
                        break;
                }
            }
        }

        internal void FixExceptionHandlers()
        {
            for (var i = Method.Body.ExceptionHandlers.Count - 1; i >= 0; i--)
            {
                string[] indices = _exceptionHandlersIndices[i].Split('|');

                var exception = Method.Body.ExceptionHandlers[i];

                exception.TryStart = GetInstruction(int.Parse(indices[0]));
                exception.TryEnd = GetInstruction(int.Parse(indices[1]));

                exception.HandlerStart = GetInstruction(int.Parse(indices[2]));
                exception.HandlerEnd = GetInstruction(int.Parse(indices[3]));

                exception.FilterStart = GetInstruction(int.Parse(indices[0]));

                if (exception.TryStart == null || exception.TryEnd == null || exception.HandlerStart == null || exception.HandlerEnd == null)
                {
                    Method.Body.ExceptionHandlers.RemoveAt(i);
                }
            }
        }

        internal Instruction GetInstruction(uint offset)
        {
            var instruction = Instructions.First(x => x.Offset == offset);

            if (instruction != null)
            {
                return instruction;
            }

            throw new Exception($"Instruction not found at offset {offset}");
        }

        internal Instruction GetInstruction(int index)
        {
            if (index > -1 && index < Instructions.Count)
            {
                return Instructions[index];
            }

            return null;
        }

        internal Instruction GetInstruction(Target target, int index)
        {
            if (index > -1 && index < target.Instructions.Length)
            {
                return target.Instructions[index];
            }

            return null;
        }

        public void Dispose()
        {
            Module?.Dispose();
        }
    }
}