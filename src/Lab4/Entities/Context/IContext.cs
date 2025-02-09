﻿using Itmo.ObjectOrientedProgramming.Lab4.Entities.FileSystem;
using Itmo.ObjectOrientedProgramming.Lab4.Models.TraversalDirectory;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.Context;

public interface IContext
{
    public string Path { get; }
    public IFileSystem FileSystem { get; }
    public ITree TreeTraversal { get; set; }
    public IStringBuildForTree StringBuildForTreeForTree { get; set; }

    bool ConnectToPath(string path, string mode);
    void ChangeCurrentPath(string path);
    IContext Clone();
}