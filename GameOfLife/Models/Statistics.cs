using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife.Models
{
    class Statistics
    {
        private int iterations;
        private int population;
        private int greatestPopulation;
        private int smallestPopulation;
        private int oldestCell;

        public int Iterations
        {
            get { return iterations; }
            set { iterations = value; }
        }

        public int Population
        {
            get { return population; }
            set { population = value; }
        }

        public int GreatestPopulation
        {
            get { return greatestPopulation; }
            set { greatestPopulation = value; }
        }

        public int SmallestPopulation
        {
            get { return smallestPopulation; }
            set { smallestPopulation = value; }
        }

        public int OldestCell
        {
            get { return oldestCell; }
            set { oldestCell = value; }
        }
    }
}
