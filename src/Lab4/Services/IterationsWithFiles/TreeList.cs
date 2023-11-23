﻿using System;
using System.ComponentModel;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.Context;
using Itmo.ObjectOrientedProgramming.Lab4.Models;
using Itmo.ObjectOrientedProgramming.Lab4.Models.TraversalDirectory;

namespace Itmo.ObjectOrientedProgramming.Lab4.Services.IterationsWithFiles;

public class TreeList(string pathFile, int maxDepth) : ICommand
{
    public FileResult Execute(IContext context)
    {
        ArgumentException.ThrowIfNullOrEmpty(pathFile);
        return context.FileSystem.ListDirectory(pathFile, maxDepth) is not null
            ? new FileResult(FileResultType.Success)
            : new FileResult(FileResultType.Failure);
    }
}