﻿using Bytes2you.Validation;
using MedicalSystem.Client.Common.Exceptions;
using MedicalSystem.Client.Core.Contracts;
using System;

namespace MedicalSystem.Client.Core
{
    public class Engine : IEngine
    {
        private const string TerminationCommand = "exit";

        private readonly IReader reader;
        private readonly IWriter writer;
        private readonly IParser parser;

        public Engine(IReader reader, IWriter writer, IParser commandParser)
        {
            Guard.WhenArgument(reader, "Reader provider").IsNull().Throw();
            Guard.WhenArgument(writer, "Writer provider").IsNull().Throw();
            Guard.WhenArgument(commandParser, "Engine Parser provider").IsNull().Throw();

            this.reader = reader;
            this.writer = writer;
            this.parser = commandParser;
        }

        public void Start()
        {
            while (true)
            {
                try
                {
                    var commandAsString = this.reader.ReadLine();

                    if (commandAsString == TerminationCommand)
                    {
                        this.writer.WriteLine("Program terminated.");
                        break;
                    }

                    var executionResult = this.parser.ProcessCommand(commandAsString);
                    this.writer.WriteLine(executionResult);
                }
                catch (UserValidationException ex)
                {
                    this.writer.WriteLine(ex.Message);
                }
                catch (DatabaseValidationException ex)
                {
                    this.writer.WriteLine(ex.Message);
                }
                catch (Exception ex)
                {
                    this.writer.WriteLine(ex.Message);
                }
            }
        }
    }
}
