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
    public class ExpressionCommand : AsbtractRenderCommand
    {
        public readonly TextSpan BeginSpan;
        public readonly TextSpan ExpressionSpan;
        public readonly TextSpan EndSpan;

        public ExpressionCommand(FileLine line, TextSpan beginSpan, TextSpan expressionSpan, TextSpan endSpan)
            : base(RenderCommands.Expression, line)
        {
            this.BeginSpan = beginSpan;
            this.ExpressionSpan = expressionSpan;
            this.EndSpan = endSpan;
        }
    }
}