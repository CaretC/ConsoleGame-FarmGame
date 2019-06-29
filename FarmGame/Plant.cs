using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmGame
{
    abstract class Plant
    {
        // *************** Properties **********************
        public abstract int[] Position { get; set; }

        public abstract int State { get; set; }

        public abstract int FullGrownState { get; }

        public abstract int HarvestValue { get; }

        public abstract bool IsHoeable { get; }

        public abstract bool IsSawable { get; }

        // *************** Methods **********************
        public abstract void GrowPlant();

        public abstract void PrintPlant();

        public abstract void HarvestPlant();

        public bool IsFullGrown()
        {
            bool fullyGrown = false;

            if (State == FullGrownState)
            {
                fullyGrown = true;
            }

            return fullyGrown;
        }

        public abstract bool IsDebris();

    }
}
