using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPISocialLogin.Entities.Enums
{
    public class Provider
    {
        private Provider(string value) { Value = value; }

        public string Value { get; private set; }

        public static Provider GOOGLE { get { return new Provider("GOOGLE"); } }
        public static Provider FACEBOOK { get { return new Provider("FACEBOOK"); } }
        public static Provider TWITTER { get { return new Provider("TWITTER"); } }
        public static Provider VK { get { return new Provider("VK"); } }
        public static Provider MICROSOFT { get { return new Provider("MICROSOFT"); } }
        public static Provider AMAZON { get { return new Provider("AMAZON"); } }
    }
}
