﻿/* Twofold.Net
 * (C) Copyright 2016 HicknHack Software GmbH
 *
 * The original code can be found at:
 *     https://github.com/hicknhack-software/Twofold.Net
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *     http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

namespace Twofold.Interface.Compilation
{
    using System;
    using System.Collections.Generic;

    public abstract class AbstractCodeGenerator
    {
        private readonly ITemplateParser parser;

        public AbstractCodeGenerator(ITemplateParser parser)
        {
            this.parser = parser;
        }

        public void Generate(string sourceName, string text)
        {
            this.PreGeneration(sourceName, text);

            List<AsbtractRenderCommand> commands = parser.Parse(sourceName, text);
            foreach (var command in commands)
            {
                switch (command.Type)
                {
                    case RenderCommandTypes.OriginExpression:
                        this.Generate((OriginExpression)command);
                        break;

                    case RenderCommandTypes.OriginPragma:
                        this.Generate((OriginPragma)command);
                        break;

                    case RenderCommandTypes.OriginScript:
                        this.Generate((OriginScript)command);
                        break;

                    case RenderCommandTypes.OriginText:
                        this.Generate((OriginText)command);
                        break;

                    case RenderCommandTypes.TargetIndentation:
                        this.Generate((TargetIndentation)command);
                        break;

                    case RenderCommandTypes.TargetNewLine:
                        this.Generate((TargetNewLine)command);
                        break;

                    case RenderCommandTypes.TargetPopIndentation:
                        this.Generate((TargetPopIndentation)command);
                        break;

                    case RenderCommandTypes.TargetPushIndentation:
                        this.Generate((TargetPushIndentation)command);
                        break;

                    default:
                        throw new NotSupportedException($"CodeFragmentType '{command.Type.ToString()}' is not supported.");
                }
            }

            this.PostGeneration(sourceName, text);
        }

        protected virtual void PreGeneration(string sourceName, string text)
        {
        }

        protected virtual void PostGeneration(string sourceName, string text)
        {
        }

        protected abstract void Generate(OriginText command);

        protected abstract void Generate(OriginExpression command);

        protected abstract void Generate(OriginPragma command);

        protected abstract void Generate(OriginScript command);

        protected abstract void Generate(TargetNewLine command);

        protected abstract void Generate(TargetIndentation command);

        protected abstract void Generate(TargetPushIndentation command);

        protected abstract void Generate(TargetPopIndentation command);
    }
}