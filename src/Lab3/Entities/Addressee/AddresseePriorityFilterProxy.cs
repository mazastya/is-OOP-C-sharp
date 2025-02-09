﻿using System;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.Models;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Addressee;

public class AddresseePriorityFilterProxy : IAddressee
{
    private readonly IAddressee _addressee;
    private readonly LevelOfImportance _levelOfImportance;

    public AddresseePriorityFilterProxy(
        IAddressee addressee,
        LevelOfImportance levelOfImportance)
    {
        _addressee = addressee;
        _levelOfImportance = levelOfImportance;
    }

    public void Receive(Message message)
    {
        ArgumentNullException.ThrowIfNull(message);
        if (message.LevelOfImportance >= _levelOfImportance)
        {
            _addressee.Receive(message);
        }
    }
}