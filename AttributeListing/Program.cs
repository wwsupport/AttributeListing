using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArchestrA.GRAccess;

namespace AttributeListing
{
    class Program
    {
        static void Main(string[] args)
        {
            string nodeName = Environment.MachineName;
            string galaxyName = "MyTestGalaxy";

            GRAccessApp grAccess = new GRAccessAppClass();

            IGalaxies gals = grAccess.QueryGalaxies(nodeName);

            IGalaxy galaxy = gals[galaxyName];

            galaxy.Login("", "");

            string[] tagnames = { "$MyTemplate" };

            IgObjects queryResult = galaxy.QueryObjectsByName(EgObjectIsTemplateOrInstance.gObjectIsTemplate, ref tagnames);

            ITemplate myTemplate = (ITemplate)queryResult[1];

            IAttributes attrs = myTemplate.ConfigurableAttributes;

            foreach (IAttribute attr in attrs)
            {
                Console.WriteLine("Attribute Name: {0} Data Type {1}", attr.Name, attr.DataType.ToString());
            }

            galaxy.Logout();

        }
    }
}
