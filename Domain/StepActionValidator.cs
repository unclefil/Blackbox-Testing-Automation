using System;
using System.Collections.Generic;

namespace Domain
{
    public class StepActionValidator
    {
        public static void ValidateCommand(string command)
        {
            if (string.IsNullOrWhiteSpace(command))
                throw new CommandCantBeNullOrWhiteSpace();

            if (!DomainConsts.Commands.Contains(command.ToUpper()))
                throw new InvalidCommand();
        }

        public static void ValidateFindMethod(string findMethod)
        {
            if (!DomainConsts.FindMethods.Contains(findMethod.ToUpper()))
                throw new InvalidFindMethod();
        }

        public static List<IStepAction> GetInvalidActions(List<ITestStep> steps)
        {
            List<IStepAction> invalidCommandLines = new List<IStepAction>();
            steps.ForEach(step =>
            {
                if (IsInvalidAction(step.Action))
                    invalidCommandLines.Add(step.Action);
            });

            return invalidCommandLines;
        }

        public static bool IsInvalidAction(IStepAction commandLine)
        {
            return (!DomainConsts.Commands.Contains(commandLine.Command)
                || (commandLine.IsElementDependent &&
                !DomainConsts.FindMethods.Contains(commandLine.FindMethod))
                );
        }


    }

    #region Exceptions
    public class InvalidFindMethod : Exception { }

    public class InvalidCommand : Exception { }

    public class CommandCantBeNullOrWhiteSpace : Exception { }
    #endregion
}
