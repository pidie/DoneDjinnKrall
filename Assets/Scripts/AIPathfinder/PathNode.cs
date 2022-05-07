namespace AIPathfinder
{
    public class PathNode : IHeapElement<PathNode>
    {
        public bool IsOrigin, IsTarget, IsPathable;
        public float FCost => GCost + HCost + Weight;
        public int GCost;
        public int HCost;
        public int Weight;
        public Tile Tile;
        public PathNode Parent;
        public PathNode[] Neighbors = {null, null, null, null};

        /// <summary> This overload is used only to initialize origin and target nodes. </summary>
        public PathNode(bool setAsOrigin, int distance, Tile t)
        {
            if (setAsOrigin)
            {
                IsOrigin = true;
                GCost = 0;
                HCost = distance;
            }
            else
            {
                IsTarget = true;
                GCost = distance;
                HCost = 0;
            }

            Tile = t;
            IsPathable = true;
        }

        public PathNode(int g, int h, Tile t)
        {
            GCost = g;
            HCost = h;
            Tile = t;
            IsPathable = true;
        }

        public void SetNeighbor(int index, PathNode node)
        {
            Neighbors[index] = node;
            node.Parent = node.IsOrigin ? null : this;
        }

        public int HeapIndex { get; set; }

        public int CompareTo(PathNode compareNode)
        {
            var compare = FCost.CompareTo(compareNode.FCost);
            if (compare == 0)
            {
                compare = HCost.CompareTo((compareNode.HCost));
            }

            return -compare;
        }
    }
}