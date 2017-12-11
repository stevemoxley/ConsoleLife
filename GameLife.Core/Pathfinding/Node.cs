using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLife.Core.Pathfinding
{
    public class Node
    {
        public Node ParentNode { get; set; }

        public int X { get; set; }

        public int Y { get; set; }

        public float F { get; set; }

        public float G { get; set; }

        public float H { get; set; }

        public bool IsDiagonal { get; set; } = false;

        public override bool Equals(object obj)
        {
            if(obj is Node)
            {
                var node = (Node)obj;

                return this.X == node.X && this.Y == node.Y;
            }
            else
            {
                return false;
            }
        }

        public bool IsValid { get; set; } = true;

    }
}
