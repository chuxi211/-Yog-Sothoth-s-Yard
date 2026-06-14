using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class MassacreValidator : ICommandValidator
{
    private Data.Time.Time time;
    public MassacreValidator(Data.Time.Time time)
    {
        this.time = time;
    }
    public bool CanExecute(Command.Management.Command command)
    {
        if(command is not Command.Management.MassacreCommand) return true;
        return time.TimePeriod == Data.Time.TimePeriod.Night;
    }

    public string GetErrorMessage(Command.Management.Command command)
    {
        return "Massacre can only be executed at night.";
    }
}
