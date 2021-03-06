using System.Linq;
using KRPC.Service.Attributes;
using KRPC.Utils;
using System.Collections.Generic;

namespace KRPCSpaceCenter.Services.Parts
{
    [KRPCClass (Service = "SpaceCenter")]
    public sealed class PartResources : Equatable<PartResources>
    {
        readonly global::Part part;

        internal PartResources (global::Part part)
        {
            this.part = part;
        }

        public override bool Equals (PartResources obj)
        {
            return part == obj.part;
        }

        public override int GetHashCode ()
        {
            return part.GetHashCode ();
        }

        [KRPCProperty]
        public IList<string> Names {
            get {
                var names = new HashSet<string> ();
                foreach (PartResource resource in part.Resources)
                    names.Add (resource.resourceName);
                return names.ToList ();
            }
        }

        [KRPCMethod]
        public bool HasResource (string name)
        {
            foreach (PartResource resource in part.Resources)
                if (resource.resourceName == name)
                    return true;
            return false;
        }

        [KRPCMethod]
        public double Max (string name)
        {
            double amount = 0;
            foreach (PartResource resource in part.Resources) {
                if (resource.resourceName == name)
                    amount += resource.maxAmount;
            }
            return amount;
        }

        [KRPCMethod]
        public double Amount (string name)
        {
            double amount = 0;
            foreach (PartResource resource in part.Resources) {
                if (resource.resourceName == name)
                    amount += resource.amount;
            }
            return amount;
        }
    }
}
