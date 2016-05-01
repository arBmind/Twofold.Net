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

namespace Twofold.Interface.SourceMapping
{
    using System.Collections.Generic;
    using System.Text;

    public class SourceMap
    {
        public class Mapping
        {
            public readonly TextPosition Generated;
            public readonly TextFilePosition Source;

            public Mapping(TextPosition generated, TextFilePosition source)
            {
                this.Generated = generated;
                this.Source = source;
            }

            public override string ToString()
            {
                return $"{this.Generated.ToString()}, {this.Source.ToString()}";
            }
        }

        List<Mapping> Mappings = new List<Mapping>();

        public void AddMapping(TextPosition generated, TextFilePosition source)
        {
            this.Mappings.Add(new Mapping(generated, source));
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            foreach (var mapping in this.Mappings)
            {
                sb.AppendLine(mapping.ToString());
            }
            return sb.ToString();
        }
    }
}