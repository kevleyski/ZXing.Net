/*
 * Copyright 2008 ZXing authors
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *      http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

using System;
using com.google.zxing.aztec;
using NUnit.Framework;

using com.google.zxing.common;
using com.google.zxing.pdf417;

namespace com.google.zxing
{
   /// <summary>
   /// This is a quick and dirty way to get totals across all the positive black box tests. It is
   /// necessary because we spawn multiple processes when using the standard test-blackbox Ant target.
   /// It would be a shame to change that because it does help with performance. Perhaps we can find a
   /// way to unify these in the future.
   ///
   /// <author>dswitkin@google.com (Daniel Switkin)</author>
   /// </summary>
   [TestFixture]
   public sealed class AllPositiveBlackBoxTester
   {
      // This list has to be manually kept up to date. I don't know any automatic way to include every
      // subclass of AbstractBlackBoxTestCase, and furthermore to exclude subclasses of
      // AbstractNegativeBlackBoxTestCase which derives from it.
      private static AbstractBlackBoxTestCase[] TESTS = {
                                                           new AztecBlackBox1TestCase(),
                                                           new AztecBlackBox2TestCase(),
                                                           //new DataMatrixBlackBox1TestCase(),
                                                           //new DataMatrixBlackBox2TestCase(),
                                                           //new Code128BlackBox1TestCase(),
                                                           //new Code128BlackBox2TestCase(),
                                                           //new Code128BlackBox3TestCase(),
                                                           //new Code39BlackBox1TestCase(),
                                                           //new Code39ExtendedBlackBox2TestCase(),
                                                           //new Code39BlackBox3TestCase(),
                                                           //new EAN13BlackBox1TestCase(),
                                                           //new EAN13BlackBox2TestCase(),
                                                           //new EAN13BlackBox3TestCase(),
                                                           //new EAN13BlackBox4TestCase(),
                                                           //new EAN8BlackBox1TestCase(),
                                                           //new ITFBlackBox1TestCase(),
                                                           //new ITFBlackBox2TestCase(),
                                                           //new UPCABlackBox1TestCase(),
                                                           //new UPCABlackBox2TestCase(),
                                                           //new UPCABlackBox3ReflectiveTestCase(),
                                                           //new UPCABlackBox4TestCase(),
                                                           //new UPCABlackBox5TestCase(),
                                                           //new UPCEBlackBox1TestCase(),
                                                           //new UPCEBlackBox2TestCase(),
                                                           //new UPCEBlackBox3ReflectiveTestCase(),
                                                           new PDF417BlackBox1TestCase(),
                                                           new PDF417BlackBox2TestCase(),
                                                           //new QRCodeBlackBox1TestCase(),
                                                           //new QRCodeBlackBox2TestCase(),
                                                           //new QRCodeBlackBox3TestCase(),
                                                           //new QRCodeBlackBox4TestCase(),
                                                           //new QRCodeBlackBox5TestCase()
                                                        };

      [Test]
      public void All_Positive_Black_Box_Tests_Should_Pass()
      {
         long now = DateTime.Now.Ticks;
         SummaryResults results = new SummaryResults();

         foreach (AbstractBlackBoxTestCase test in TESTS)
         {
            results.Add(test.testBlackBoxCountingResults(false));
         }

         now = DateTime.Now.Ticks - now;
         Console.WriteLine(results + "\n  Total time: " + now + " ms");
      }
   }
}
