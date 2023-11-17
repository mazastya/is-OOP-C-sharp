﻿using System;
using System.Collections.Generic;
using System.IO;
using Itmo.ObjectOrientedProgramming.Lab4.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.FileSystem;

public class FileSystem : IFileSystem
{
    public bool Connect(string path, string? mode)
    {
        ArgumentException.ThrowIfNullOrEmpty(path);
        return File.Exists(path);
    }

    public void Disconnect()
    {
    }

    public void ChangeDirectory(string path)
    {
        string newPath = Path.Combine(Directory.GetCurrentDirectory(), path);
        if (!File.Exists(newPath))
        {
            throw new ArgumentException(newPath);
        }
    }

    public IEnumerable<string> ListDirectory(string path, int depth)
    {
        return Directory.EnumerateFileSystemEntries(path);
    }

    public string? FileShow(string path, string mode)
    {
        ArgumentException.ThrowIfNullOrEmpty(path);
        ArgumentException.ThrowIfNullOrEmpty(mode);

        if (File.Exists(path))
        {
            return File.ReadAllText(path);
        }
        else
        {
            return string.Empty;
        }
    }

    public FileResult FileMove(string sourcePath, string destinationPath)
    {
        ArgumentException.ThrowIfNullOrEmpty(sourcePath);
        ArgumentException.ThrowIfNullOrEmpty(destinationPath);
        try
        {
            File.Move(sourcePath, destinationPath);
            return new FileResult(FileResultType.Success);
        }
        catch (FileNotFoundException exception)
        {
            Console.WriteLine(exception);
            return new FileResult(FileResultType.Failure);
        }
    }

    public FileResult FileCopy(string sourcePath, string destinationPath)
    {
        ArgumentException.ThrowIfNullOrEmpty(sourcePath);
        ArgumentException.ThrowIfNullOrEmpty(destinationPath);
        try
        {
            File.Copy(sourcePath, destinationPath);
            return new FileResult(FileResultType.Success);
        }
        catch (FileNotFoundException exception)
        {
            Console.WriteLine(exception);
            return new FileResult(FileResultType.Failure);
        }
    }

    public FileResult FileDelete(string path)
    {
        ArgumentException.ThrowIfNullOrEmpty(path);
        try
        {
            File.Delete(path);
            return new FileResult(FileResultType.Success);
        }
        catch (FileNotFoundException exception)
        {
            Console.WriteLine(exception);
            return new FileResult(FileResultType.Failure);
        }
    }

    public FileResult FileRename(string path, string newFileName)
    {
        ArgumentException.ThrowIfNullOrEmpty(path);
        ArgumentException.ThrowIfNullOrEmpty(newFileName);
        try
        {
            File.Move(
                path,
                Path.Combine(Directory.GetParent(path)?.FullName ?? throw new InvalidOperationException(), newFileName),
                true);
            return new FileResult(FileResultType.Success);
        }
        catch (FileNotFoundException exception)
        {
            Console.WriteLine(exception);
            return new FileResult(FileResultType.Failure);
        }
    }
}