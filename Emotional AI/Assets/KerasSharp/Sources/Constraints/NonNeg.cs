﻿// Keras-Sharp: C# port of the Keras library
// https://github.com/cesarsouza/keras-sharp
//
// Based under the Keras library for Python. See LICENSE text for more details.
//
//    The MIT License(MIT)
//    
//    Permission is hereby granted, free of charge, to any person obtaining a copy
//    of this software and associated documentation files (the "Software"), to deal
//    in the Software without restriction, including without limitation the rights
//    to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
//    copies of the Software, and to permit persons to whom the Software is
//    furnished to do so, subject to the following conditions:
//    
//    The above copyright notice and this permission notice shall be included in all
//    copies or substantial portions of the Software.
//    
//    THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
//    IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
//    FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
//    AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
//    LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
//    OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
//    SOFTWARE.
//

namespace KerasSharp.Constraints
{
    using System.Runtime.Serialization;
    using static KerasSharp.Backends.Current;
    
    using KerasSharp.Engine.Topology;

    /// <summary>
    ///   Constrains the weights to be non-negative.
    /// </summary>
    /// 
    [DataContract]
    public class NonNeg : IWeightConstraint
    {

        /// <summary>
        /// Wires the constraint to the graph.
        /// </summary>
        /// <param name="w">The weights tensor.</param>
        /// <returns>The output tensor with the constraint applied.</returns>
        public Tensor Call(Tensor w)
        {
            return K.mul(w, K.cast(K.greater_equal(w, 0.0), K.floatx()));
        }
    }
}