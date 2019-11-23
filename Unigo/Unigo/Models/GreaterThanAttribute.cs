using System;

namespace Unigo.Models
{
    internal class GreaterThanAttribute : Attribute
    {
        private string v;

        public GreaterThanAttribute(string v)
        {
            this.v = v;
        }
    }
}