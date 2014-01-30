using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCCalculator.Models
{
    public class Calculator
    {
        public double CurrentValue { get; set; }
        public bool FirstOperation { get; set; }
        public double PendingValue { get; set; }
        public string PendingAction { get; set; }

        public Calculator()
        {
            CurrentValue = 0.0D;
            FirstOperation = true;
            PendingValue = 0.0D;
            PendingAction = "";
        }

        public void Process(string key)
        {
            if (string.IsNullOrEmpty(PendingAction)) PendingAction = "";

            double number;
            if (double.TryParse(key, out number))
                ProcessNumber(number);
            else
                ProcessAction(key);
        }

        private void ProcessAction(string currentAction)
        {
            bool pendingOperation = (PendingAction.Length > 0);
            if ("/*-+=".IndexOf(currentAction) >= 0)
            {
                if (pendingOperation)
                    CurrentValue = DoCalculation(PendingAction, PendingValue, CurrentValue);

                FirstOperation = true;

                if (currentAction != "=")
                {
                    PendingAction = currentAction;
                    PendingValue = CurrentValue;
                }
                else
                {
                    PendingAction = "";
                    PendingValue = 0.0D;
                }
            }
            else
            {
                switch (currentAction)
                {
                    case "C":
                        // Reset calculator window and hidden fields
                        CurrentValue = 0.0D;
                        PendingAction = "";
                        PendingValue = 0.0D;
                        FirstOperation = true;
                        break;
                    case "CE":
                        // Clear error
                        CurrentValue = 0.0D;
                        FirstOperation = true;
                        break;
                    case "<-":
                        // Backspace - prevent leaving "bad" data in calculator window
                        // Not implemented
                        break;
                    case ".":
                        // Decimal point
                        // Not implemented
                        break;
                    case "+/-":
                        // Sign
                        CurrentValue *= -1;
                        break;
                }
            }
        }

        private void ProcessNumber(double number)
        {
            if (FirstOperation)
                CurrentValue = number;
            else
                CurrentValue = CurrentValue * 10.0 + number;

            FirstOperation = false;
        }

        private double DoCalculation(string action, double left, double right)
        {
            // Perform arithmetic calculations
            double result = 0.0;
            switch (action)
            {
                case "/":
                    // Prevent divide by zero
                    if (right != 0)
                        result = left / right;
                    else
                    {
                        // TODO: Handle divide by zero error
                    }
                    break;
                case "*":
                    result = left * right;
                    break;
                case "-":
                    result = left - right;
                    break;
                case "+":
                    result = left + right;
                    break;
            }
            return result;
        }
    }
}