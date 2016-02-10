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
using System;

namespace Twofold.Extensions
{
    public static class StringExtensions
    {
        /// <exception cref="ArgumentOutOfRangeException">beginIndex is greater than endIndex.</exception>
        /// <exception cref="ArgumentOutOfRangeException">endIndex is greater than string length.</exception>
        public static int IndexOf(this string value, int beginIndex, int endIndex, Func<char, bool> predicate)
        {
            if (beginIndex > endIndex) {
                throw new ArgumentOutOfRangeException("beginIndex", "Must be less equal than endIndex.");
            }
            if (endIndex > value.Length) {
                throw new ArgumentOutOfRangeException("endIndex", "endIndex must be less equal string length.");
            }
            var index = beginIndex;
            while (index < endIndex) {
                char ch = value[index];
                if (predicate(ch)) {
                    return index;
                }
                ++index;
            }
            return -1;
        }

        /// <exception cref="ArgumentOutOfRangeException">beginIndex is greater than endIndex.</exception>
        /// <exception cref="ArgumentOutOfRangeException">endIndex is greater than string length.</exception>
        public static int IndexOfNot(this string value, int beginIndex, int endIndex, Func<char, bool> predicate)
        {
            if (beginIndex > endIndex) {
                throw new ArgumentOutOfRangeException("beginIndex", "Must be less equal than endIndex.");
            }
            if (endIndex > value.Length) {
                throw new ArgumentOutOfRangeException("endIndex", "endIndex must be less equal string length.");
            }
            var index = beginIndex;
            while (index < endIndex) {
                char ch = value[index];
                if (!predicate(ch)) {
                    return index;
                }
                ++index;
            }
            return -1;
        }
    }
}
