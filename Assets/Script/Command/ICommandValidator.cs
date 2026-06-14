using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICommandValidator
{
    bool CanExecute(Command.Management.Command command);
    string GetErrorMessage(Command.Management.Command command);
}