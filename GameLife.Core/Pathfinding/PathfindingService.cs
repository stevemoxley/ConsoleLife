using ConsoleLife.Framework;
using ConsoleLife.Framework.Components;
using GameLife.Core.Components;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLife.Core.Pathfinding
{
    public class PathfindingService
    {

        public List<Node> FindPath(PositionComponent positionComponent, PathfindingComponent pathfindingComponent)
        {

            List<Node> openList = new List<Node>();
            List<Node> closedList = new List<Node>();
            List<Node> path = new List<Node>();
            var nodes = GenerateNodeMap();

            var startingNode = nodes[positionComponent.X, positionComponent.Y];
            var targetNode = nodes[pathfindingComponent.TargetX, pathfindingComponent.TargetY];
            startingNode.G = 0;
            startingNode.F = startingNode.G + Heuristic(startingNode, targetNode);
            openList.Add(startingNode);

            while (openList.Count > 0)
            {
                var currentNode = openList.OrderBy(n => n.F).FirstOrDefault();

                if (currentNode.X == targetNode.X && currentNode.Y == targetNode.Y)
                {
                    return ConstructPath(currentNode);
                }

                openList.Remove(currentNode);
                closedList.Add(currentNode);

                foreach (var neighbor in GetNeighbors(currentNode, nodes))
                {
                    if (!closedList.Contains(neighbor))
                    {
                        var heuristic = Heuristic(neighbor, targetNode);
                        neighbor.F = neighbor.G + heuristic;
                        if (!openList.Contains(neighbor))
                        {
                            openList.Add(neighbor);
                        }
                        else
                        {
                            var openNeighbor = openList.Where(x => x.Equals(neighbor)).FirstOrDefault();
                            if (neighbor.G < openNeighbor.G)
                            {
                                openNeighbor.G = neighbor.G;
                                openNeighbor.ParentNode = neighbor.ParentNode;
                                nodes[openNeighbor.X, openNeighbor.Y].ParentNode = neighbor.ParentNode;
                            }
                        }
                    }
                }
            }

            return path;

        }

        private List<Node> GetNeighbors(Node node, Node[,] nodes)
        {
            List<Node> result = new List<Node>();

            //top
            int x = node.X;
            int y = node.Y - 1;
            if (IsValidNode(x, y, nodes))
            {
                var neighbor = new Node();
                neighbor.X = x;
                neighbor.Y = y;
                neighbor.G = node.G + 1;
                neighbor.ParentNode = node;
                result.Add(neighbor);
            }
            //bottom
            x = node.X;
            y = node.Y + 1;
            if (IsValidNode(x, y, nodes))
            {
                var neighbor = new Node();
                neighbor.X = x;
                neighbor.Y = y;
                neighbor.G = node.G + 1;
                neighbor.ParentNode = node;
                result.Add(neighbor);
            }
            //Left
            y = node.Y;
            x = node.X - 1;
            if (IsValidNode(x, y, nodes))
            {
                var neighbor = new Node();
                neighbor.X = x;
                neighbor.Y = y;
                neighbor.G = node.G + 1;
                neighbor.ParentNode = node;
                result.Add(neighbor);
            }
            //Right
            x = node.X + 1;
            y = node.Y;
            if (IsValidNode(x, y, nodes))
            {
                var neighbor = new Node();
                neighbor.X = x;
                neighbor.Y = y;
                neighbor.G = node.G + 1;
                neighbor.ParentNode = node;
                result.Add(neighbor);
            }

            //Top Right
            x = node.X + 1;
            y = node.Y - 1;
            if (IsValidNode(x, y, nodes))
            {
                var neighbor = new Node();
                neighbor.X = x;
                neighbor.Y = y;
                neighbor.G = node.G + 1.414f;
                neighbor.ParentNode = node;
                neighbor.IsDiagonal = true;
                result.Add(neighbor);
            }

            //Top Left
            x = node.X - 1;
            y = node.Y - 1;
            if (IsValidNode(x, y, nodes))
            {
                var neighbor = new Node();
                neighbor.X = x;
                neighbor.Y = y;
                neighbor.G = node.G + 1.414f;
                neighbor.ParentNode = node;
                neighbor.IsDiagonal = true;
                result.Add(neighbor);
            }

            //Bottom Right
            x = node.X + 1;
            y = node.Y + 1;
            if (IsValidNode(x, y, nodes))
            {
                var neighbor = new Node();
                neighbor.X = x;
                neighbor.Y = y;
                neighbor.G = node.G + 1.414f;
                neighbor.ParentNode = node;
                neighbor.IsDiagonal = true;
                result.Add(neighbor);
            }

            //Bottom Left
            x = node.X - 1;
            y = node.Y + 1;
            if (IsValidNode(x, y, nodes))
            {
                var neighbor = new Node();
                neighbor.X = x;
                neighbor.Y = y;
                neighbor.G = node.G + 1.414f;
                neighbor.ParentNode = node;
                neighbor.IsDiagonal = true;
                result.Add(neighbor);
            }



            return result;
        }

        private float Heuristic(Node currentNode, Node targetNode)
        {
            var dx = Math.Abs(currentNode.X - targetNode.X);
            var dy = Math.Abs(currentNode.Y - targetNode.Y);
            var heuristic = Math.Sqrt(dx * dx + dy * dy);
            return (float)heuristic;
        }

        private List<Node> ConstructPath(Node targetNode)
        {
            List<Node> result = new List<Node>();
            result.Add(targetNode);

            while (targetNode.ParentNode != null)
            {
                targetNode = targetNode.ParentNode;
                result.Add(targetNode);
            }
            result.Reverse();
            result.RemoveAt(0);

            return result;
        }

        private bool IsValidNode(int x, int y, Node[,] nodes)
        {
            var xLength = nodes.GetLength(0);
            var yLength = nodes.GetLength(1);
            if (x < xLength && y <  yLength && x >= 0 && y >= 0)
            {
                var node = nodes[x, y];
                if (node.IsValid)
                {
                    return true;
                }
            }

            return false;
        }

        private Node[,] GenerateNodeMap()
        {
            Node[,] result = new Node[Console.WindowWidth, Console.WindowHeight];
            var entities = Game.AllEntities.Where(e => e.HasComponent<PositionComponent>());

            foreach (var entity in entities)
            {
                var positionComponent = entity.GetComponent<PositionComponent>();
                Node node = new Node();
                node.X = positionComponent.X;
                node.Y = positionComponent.Y;

                if (entity.HasComponent<MoveableComponent>())
                {
                    var moveableComponent = entity.GetComponent<MoveableComponent>();
                    node.X = positionComponent.X + moveableComponent.MoveX;
                    node.Y = positionComponent.Y + moveableComponent.MoveY;
                }

                if (entity.HasComponent<ImpassableComponent>())
                {
                    node.IsValid = false;
                }

                result[node.X, node.Y] = node;
            }


            for (int x = 0; x < Console.WindowWidth; x++)
            {
                for (int y = 0; y < Console.WindowHeight; y++)
                {
                    var node = result[x, y];
                    if (node == null)
                    {
                        node = new Node();
                        node.X = x;
                        node.Y = y;
                        result[node.X, node.Y] = node;
                    }
                }
            }

            return result;

        }

    }
}
