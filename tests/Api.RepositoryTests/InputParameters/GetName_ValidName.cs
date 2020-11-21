using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Api.RepositoryTests.InputParameters
{
    internal class GetName_ValidName : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { null };
            yield return new object[] { "" };
            yield return new object[] { "ανα" };
            yield return new object[] { "γιώρης" };
            yield return new object[] { "Πανα" };
            yield return new object[] { "Παναγιώρης" };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
