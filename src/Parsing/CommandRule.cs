﻿using System;
using Twofold.Api;

namespace Twofold.Parsing
{
    public class CommandRule : AbstractParserRule
    {
        public CommandRule(IMessageHandler messageHandler)
            : base(messageHandler)
        { }

        public override void Parse(string value, int beginIndex, int nonSpaceBeginIndex, int endIndex, ICodeGenerator codeGenerator)
        {
            throw new NotImplementedException();
        }
    }
}
