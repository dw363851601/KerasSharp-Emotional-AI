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

namespace KerasSharp.Losses
{
    using KerasSharp.Engine.Topology;
    using System;
    using System.Runtime.Serialization;

    using static KerasSharp.Backends.Current;

    /// <summary>
    ///   Cosine Proximity loss.
    /// </summary>
    /// 
    [DataContract]
    public class CosineProximity : ILoss
    {
        public Tensor Call(Tensor expected, Tensor actual, Tensor sample_weight = null, Tensor mask = null)
        {
            if (sample_weight != null || mask != null)
                throw new NotImplementedException();

            using (K.name_scope("cosine_proximity"))
            {
                Tensor y_true = K.l2_normalize(expected, axis: -1);
                Tensor y_pred = K.l2_normalize(actual, axis: -1);
                return K.minus(K.mean(K.mul(expected, actual), axis: -1));
            }
        }
    }
}