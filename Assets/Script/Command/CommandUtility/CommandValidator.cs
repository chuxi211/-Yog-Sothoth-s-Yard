using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandValidator
{
    private List<ICommandValidator> commandValidators = new List<ICommandValidator>();
    public void Register(ICommandValidator validator)
    {
        commandValidators.Add(validator);
    }
    public bool CanExecute(Command.Management.Command command,out string error)
    {
        foreach(var  validator in commandValidators)
        {
            if (!validator.CanExecute(command))
            {
                error =validator.GetErrorMessage(command);
                return false;
            }
        }
        error = null;
        return true;
    }
}