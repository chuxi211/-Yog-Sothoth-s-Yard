using Command.Management;
using Data;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandInvoker
{
    private CommandDispatcher dispatcher;
    private CommandValidator validator;
    public CommandInvoker(CommandDispatcher dispatcher, CommandValidator validator)
    {
        this.dispatcher = dispatcher;
        this.validator = validator;
    }
    public void Execute(Command.Management.Command command)
    {
        if (!validator.CanExecute(
            command,
            out string error))
        {
            Debug.Log(error);
            return;
        }
        dispatcher.Dispatche(command);
    }
}