﻿using System;
using System.Collections.Generic;
using System.Text;
using WorkflowCore.Interface;
using WorkflowCore.Models;

namespace WorkflowCore.Sample12
{    
    public class PrintMessage : StepBody
    {
        public string Message { get; set; }

        public override ExecutionResult Run(IStepExecutionContext context)
        {
            Console.WriteLine(Message);
            return ExecutionResult.Next();
        }
    }
}
